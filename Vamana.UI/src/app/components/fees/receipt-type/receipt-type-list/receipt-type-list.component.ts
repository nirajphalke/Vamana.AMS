import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ColDef, GridOptions, GridReadyEvent } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';

import { ReceiptTypeAddComponent } from '../receipt-type-add/receipt-type-add.component';
import { SliderComponent } from "src/app/common/slider.component";
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MasterService } from 'src/app/services/master.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { IconButtonRendererComponent } from 'src/app/common/icon-button-renderer.component';

@Component({
    selector: 'app-receipt-type-list',
    templateUrl: './receipt-type-list.component.html',
    styleUrls: ['./receipt-type-list.component.scss'],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatSelectModule,
        MatCheckboxModule,
        MatButtonModule,
        AgGridAngular,
        SliderComponent
    ]
})
export class ReceiptTypeListComponent implements OnInit {
    isSliderOpen = false;
    sliderComponent: any = null;
    sliderData: any = null;

    gridOptions: GridOptions<any> = {
        autoSizeStrategy: {
            type: "fitGridWidth",
            defaultMinWidth: 100,
        },
        onRowDoubleClicked: this.onRowDoubleClickedHandler.bind(this),
         rowSelection: {
            mode: 'singleRow',
            checkboxes: false,
            enableClickSelection: true, // Enable selection by clicking rows
        }
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
    gridData: any[] = [];
    form!: FormGroup;
    editingId: number | null = null;
    displayedColumns: string[] = [];
    isLoading:boolean = false;

    constructor(
        private ms: MasterService,
        private fb: FormBuilder
    ) {
    }


    ngOnInit(): void {
        this.buildGridColumns();
        this.loadGridData();
    }

    // Load receipt types from the service
    private loadGridData() {
        this.isLoading = true; 
        //this.gridApi.setGridOption('loading', true); 
        // this.ms.getReceiptTypes().subscribe(data => {
        //     this.gridData = data;
        // });

        this.ms.getReceiptTypes(true).subscribe({
            next: (data) => {
                this.gridData = data;
            },
            complete: () => {
                this.isLoading = false;
            }
        });
    }

    private buildGridColumns() {
        const gridFields = [
            { name: 'ReceiptTypeId', label: 'Receipt Type Id', type: 'number', visible: false },
            { name: 'ReceiptTypeName', label: 'Receipt Type', type: 'string', visible: true },
            { name: 'ReceiptCodeName', label: 'Receipt Code', type: 'string', visible: true },
            { name: 'ReceiptBelongsToName', label: 'Receipt Belongs To', type: 'string', visible: true },
            { name: 'AccountNo', label: 'Account No', type: 'string', visible: true },
            //{ name: 'LinkWithAccounts', label: 'Link With Accounts', type: 'boolean', visible: true },
            { name: 'IsAdmissionType', label: 'Is Admission Type', type: 'boolean', visible: true },
            //{ name: 'IsLateFineApplicable', label: 'Is Late Fine Applicable', type: 'boolean', visible: true },
           // { name: 'ShowInStudentLogin', label: 'Show In Student Login', type: 'boolean', visible: true },
            //{ name: 'IsOnlineVisibility', label: 'Is Online Visibility', type: 'boolean', visible: true },
            //{ name: 'IsActive', label: 'Is Active', type: 'boolean', visible: true },
        ];

        this.colDefs = gridFields
            .filter(f => f.visible) // only keep visible columns
            .map<ColDef>(f => ({
                headerName: f.label,
                field: f.name,
                sortable: true,
                filter: true,
                valueFormatter: params => {
                    if (f.type === 'boolean') {
                        return params.value == true ? 'Yes' : 'No';
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

    openAddForm() {
        this.sliderComponent = ReceiptTypeAddComponent;
        this.isSliderOpen = true;
        this.sliderData = null;
    }

    onGridReady(params: any) {
        this.gridApi = params.api;
        this.gridColumnApi = params.columnApi;
    }

    onSliderClosed(result: any) {
        this.isSliderOpen = false;
        if (result && result === 'saved') {
            this.loadGridData();
        }
    }

    edit(row: any) {
        this.sliderComponent = ReceiptTypeAddComponent;
        this.isSliderOpen = true;
        this.sliderData = { dataRow: row };
    }

    onRowDoubleClickedHandler(event: any) {
        this.edit(event.node.data);
    }

    refresh() {
        this.loadGridData();
    }
}