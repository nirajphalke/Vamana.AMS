import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { AbstractControl, FormGroup, ReactiveFormsModule, ValidationErrors } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MasterService } from '../../services/master.service';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatSnackBar } from '@angular/material/snack-bar';

import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';

import { IconButtonRendererComponent } from '../../common/icon-button-renderer.component';

import { MasterMeta } from 'src/app/interfaces/masters';
import { masters as masterData } from '../../data/mastersSchema';


@Component({
    selector: 'app-master-manager',
    templateUrl: './master-manager.component.html',
    styleUrls: ['./master-manager.component.scss'],
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule,
        MatButtonModule,
        MatTableModule,
        MatIconModule,
        MatPaginatorModule,
        MatSortModule,
        MatCardModule,
        MatChipsModule,
        AgGridAngular
    ]
})
export class MasterManagerComponent implements OnInit {
    private _snackBar = inject(MatSnackBar);
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    @ViewChild(MatSort) sort!: MatSort;

    masters: MasterMeta[] = masterData;
    selected!: MasterMeta;
    items: any[] = [];
    dataSource = new MatTableDataSource<any>([]);
    lookups: { [key: string]: any[] } = {};
    form!: FormGroup;
    editingId: number | null = null;
    displayedColumns: string[] = [];

    gridOptions: GridOptions<any> = {
        autoSizeStrategy: {
            type: "fitGridWidth",
            defaultMinWidth: 100,
        },
    };
    colDefs: ColDef[] = []
    defaultColDef: ColDef = { sortable: true, filter: true, resizable: true } as ColDef;
    private gridApi: any;
    private gridColumnApi: any;
    autoSizeStrategy: any = {
        type: "fitGridWidth",
        defaultMinWidth: 100,
        columnLimits: [
            {
                colId: "country",
                minWidth: 900,
            },
        ],
    };

    constructor(
        private ms: MasterService,
        private fb: FormBuilder
    ) {
    }

    onGridReady(params: any) {
        this.gridApi = params.api;
        this.gridColumnApi = params.columnApi;
        // Show built-in loading overlay
        this.gridApi.setGridOption('loading', true)
        // Hide overlay when data is loaded
        this.gridApi.setGridOption('loading', false)
    }

    ngOnInit(): void {
        this.selectMaster(this.masters[0]);
    }

    selectMaster(meta: MasterMeta) {
        this.selected = meta;
        // this.updateDisplayedColumns();
        this.loadAll();

        // Load lookups for foreign key fields
        for (const f of meta.fields.filter((x) => x.fkTo)) {
            this.ms.getLookup(f.fkTo!).subscribe({
                next: (data) => {
                    //data.unshift({ id: 0, text: 'Select' });
                    this.lookups[f.name] = data;
                },
                error: (err) => {
                    console.error('selectMaster Error:', err);
                    this._snackBar.open('Error. Please try again.', '', {
                        duration: 3000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top'
                    });
                }
            });
        }
        this.buildForm();
        this.buildGridColumns();
    }

    private buildGridColumns() {
        if (!this.selected) {
            return;
        }
        // this.colDefs = this.selected.fields
        //   .filter((f) => f.visible)
        //   .map((f) => ({ 
        //     field: f.name, 
        //     headerName: f.label
        //   } as ColDef));

        this.colDefs = this.selected.fields
            .filter(f => f.visible) // only keep visible columns
            .map<ColDef>(f => ({
                headerName: f.label,
                field: f.name,
                sortable: true,
                filter: true,
                rowGroup: true,
                valueFormatter: params => {
                    // if (f.type === 'boolean') {
                    //   return params.value == true ? 'Yes' : 'No';
                    // }
                    if (f.fkTo) {
                        return params.data ? params.data[f.text] : '';
                    }
                    return params.value ?? '';
                }
            }));

        // actions column with renderer (use framework component by key)
        this.colDefs.push(
            {
                headerName: 'Action',
                cellRenderer: IconButtonRendererComponent,
                cellRendererParams: {
                    icon: 'edit', // Pass specific icon name if needed
                    // pass a callback that calls the component method
                    onClick: (row: any) => this.edit(row)
                },
                width: 100,
                sortable: false,
                filter: false,
            } as ColDef);
    }

    buildForm() {
        const group: any = {};

        for (const f of this.selected.fields) {
            const validators = [];

            // required validation
            if (f.required) {
                validators.push(Validators.required);
            }

            if (f.fkTo) {
                // Start at "Select" (id = 0) and apply validators
                group[f.name] = [0, [Validators.required, this.notZeroValidator]];
                validators.push(this.notZeroValidator);  // 👈 add custom validator
            }

            // type-specific validation
            if (f.type === 'email') {
                validators.push(Validators.email);
            }
            if (f.type === 'number') {
                validators.push(Validators.pattern(/^[0-9]+$/));
            }

            if (f.type === 'boolean') {
                group[f.name] = [true, validators];
            } else {
                group[f.name] = [null, validators];
            }
        }

        this.form = this.fb.group(group);
        this.editingId = null;
    }

    loadAll() {
        this.items = [];
        this.dataSource.data = this.items;
        this.ms.getMaster(this.selected.key).subscribe({
            next: (data) => {
                this.items = data || [];
                this.dataSource.data = this.items;
            },
            error: (err) => {
                console.error('loadAll Error:', err);
                this._snackBar.open('Error. Please try again.', '', {
                    duration: 3000,
                    horizontalPosition: 'right',
                    verticalPosition: 'top'
                });
            }
        });
    }

    private notZeroValidator(control: AbstractControl): ValidationErrors | null {
        return control.value === 0 ? { notZero: true } : null;
    }

    // private updateDisplayedColumns() {
    //   if (this.selected?.fields) {
    //     this.displayedColumns = this.selected.fields.map((f: any) => f.name);
    //     this.displayedColumns.push('actions'); // add Actions column
    //   }
    // }

    // // Optional: method to filter table
    // applyFilter(event: Event) {
    //   const filterValue = (event.target as HTMLInputElement).value;
    //   this.dataSource.filter = filterValue.trim().toLowerCase();
    // }

    edit(item: any) {
        this.editingId = item[this.selected.fields[0].name];
        this.form.patchValue(item);
    }

    cancel() {
        this.buildForm();
    }

    save() {
        if (this.form.invalid) {
            this.form.markAllAsTouched();
            return;
        }

        const idField = this.selected.fields[0].name;
        const payload = { ...this.form.value };
        const id = payload[idField];

        if (id && id > 0 && this.editingId) {
            this.ms.update(this.selected.key, id, payload).subscribe({
                next: () => {
                    this._snackBar.open('Record Saved!!', '', {
                        duration: 4000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top'
                    });
                    this.loadAll();
                    this.buildForm();
                },
                error: (error) => {
                    if (error.status === 409) {
                        this._snackBar.open(error.error, '', {
                            duration: 5000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top'
                        });
                    } else {
                        this._snackBar.open('Failed to save record. Please try again.', '', {
                            duration: 5000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top'
                        });
                    }
                }
            });
        } else {
            payload[idField] = 0;
            this.ms.create(this.selected.key, payload).subscribe({
                next: () => {
                    this._snackBar.open('Record Saved!!', '', {
                        duration: 4000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top'
                    });
                    this.loadAll();
                    this.buildForm();
                },
                error: (error) => {
                    if (error.status === 409) {
                        this._snackBar.open(error.error, '', {
                            duration: 5000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top'
                        });
                    } else {
                        this._snackBar.open('Failed to save record. Please try again.', '', {
                            duration: 5000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top'
                        });
                    }
                }
            });
        }
    }

    remove(item: any) {
        const id = item[this.selected.fields[0].name];
        if (!confirm('Delete?')) return;
        this.ms.delete(this.selected.key, id).subscribe(() => this.loadAll());
    }
}
