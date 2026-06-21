import { OnInit, Component, EventEmitter, Output, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, FormsModule, ValidationErrors } from '@angular/forms';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { catchError, forkJoin, of } from 'rxjs';
import { MasterService } from 'src/app/services/master.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    selector: 'app-receipt-type-add',
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatCardModule,
        MatInputModule,
        MatSelectModule,
        MatCheckboxModule,
        MatButtonModule,
        MatSlideToggleModule
    ],
    templateUrl: './receipt-type-add.component.html',
    styleUrls: ['./receipt-type-add.component.scss'],
})
export class ReceiptTypeAddComponent implements OnInit {
    @Output() onClose = new EventEmitter<string>();
    receiptForm!: FormGroup;
    mode: string = 'Add';
    lookups: { [key: string]: any[] } = {};
    private _snackBar = inject(MatSnackBar);

    constructor(private fb: FormBuilder, private ms: MasterService) {
    }

    ngOnInit(): void {
        this.receiptForm = this.fb.group({
            receiptTypeName: ['', Validators.required],
            receiptCodeId: ['', [Validators.required, this.notZeroValidator]],
            receiptBelongsTo: ['', [Validators.required, this.notZeroValidator]],
            accountNo: ['', Validators.required],
            linkWithAccounts: [false],
            isAdmissionType: [false], // default inactive
            isLateFineApplicable: [false],
            showInStudentLogin: [false],
            isOnlineVisibility: [false],
            isActive: [true]
        });

        this.loadLookups();

        if (this['dataRow'] && this['dataRow'].ReceiptTypeId && this['dataRow'].ReceiptTypeId > 0) {
            const patchData = {
                receiptTypeId: this['dataRow'].ReceiptTypeId,
                receiptTypeName: this['dataRow'].ReceiptTypeName,
                receiptCodeId: this['dataRow'].ReceiptCodeId,
                receiptBelongsTo: this['dataRow'].ReceiptBelongsTo,
                accountNo: this['dataRow'].AccountNo,
                linkWithAccounts: this['dataRow'].LinkWithAccounts,
                isAdmissionType: this['dataRow'].IsAdmissionType,
                isLateFineApplicable: this['dataRow'].IsLateFineApplicable,
                showInStudentLogin: this['dataRow'].ShowInStudentLogin,
                isOnlineVisibility: this['dataRow'].IsOnlineVisibility,
                isActive: this['dataRow'].IsActive
            };
            this.receiptForm.patchValue(patchData);
        }
    }

    onSave(): void {
        if (!this.receiptForm.valid) {
            this.receiptForm.markAllAsTouched();
            return;
        }
        const id = this['dataRow'] && this['dataRow'].ReceiptTypeId && this['dataRow'].ReceiptTypeId > 0 ? this['dataRow'].ReceiptTypeId : 0;
        const payload = { receiptTypeId: id, ...this.receiptForm.value };

        if (id > 0) {
            this.ms.updateReceiptType(id, payload).subscribe({
                    next: () => {
                        this._snackBar.open('Record Saved!!', '', {
                            duration: 4000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top'
                        });
                        this.receiptForm.reset();
                        this.onClose.emit('saved');
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
        else {
            this.ms.postReceiptType(payload).subscribe({
                    next: () => {
                        this._snackBar.open('Record Saved!!', '', {
                            duration: 4000,
                            horizontalPosition: 'right',
                            verticalPosition: 'top'
                        });
                        this.receiptForm.reset();
                        this.onClose.emit('saved');
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

    onCancel(): void {
        // this.receiptForm.reset({
        //     linkWithAccounts: false,
        //     isAdmissionType: false,
        //     isLateFineApplicable: false,
        //     showInStudentLogin: false,
        //     isOnlineVisibility: false
        // });
        this.onClose.emit();
    }

    loadLookups(): void {
        const lookupKeys = [ 'receiptcode', 'receiptbelongsto' ];
        const lookupRequests = lookupKeys.map(key => {
            const obs$ = this.ms.getLookup(key);
            return (obs$ ?? of([])).pipe(
                catchError(err => {
                    console.error(`Error loading '${key}':`, err);
                    return of([]);
                })
            );
        });

        forkJoin(lookupRequests).subscribe({
            next: (results) => {
                lookupKeys.forEach((key, index) => this.lookups[key] = results[index] || []);
            },
            error: (err) => {
                // should not occur because individual requests catch errors, but keep fallback
                console.error('Error loading lookups', err);
            }
        });
    }

    private notZeroValidator(control: AbstractControl): ValidationErrors | null {
        return control.value === 0 ? { notZero: true } : null;
    }
}
