import { Component, inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { Student } from '../../interfaces/Student';
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
import { CommonModule } from '@angular/common';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatRadioModule } from '@angular/material/radio';
import { MasterService } from 'src/app/services/master.service';
import { catchError, forkJoin, Observable, of, tap } from 'rxjs';



@Component({
    selector: 'app-student-admission',
    templateUrl: './student-admission.component.html',
    styleUrls: ['./student-admission.component.scss'],
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
        MatDatepickerModule,
        MatRadioModule
    ],
    providers: [provideNativeDateAdapter()],
})
export class StudentAdmissionComponent implements OnInit {
    studentForm: FormGroup;
    lookups: { [key: string]: any[] } = {};
    private _snackBar = inject(MatSnackBar);

    constructor(private fb: FormBuilder, private ms: MasterService) {
    }

    ngOnInit(): void {
        this.studentForm = this.fb.group({
            // row 1
            studentName: ['', [Validators.required, Validators.maxLength(200)]],
            fatherName: ['', [Validators.maxLength(200)]],
            studentEmailId: ['', [Validators.required, Validators.email]],
            // row 2
            studentMobileNo: ['', [Validators.required, Validators.pattern(/^[0-9+\-()\s]{7,20}$/)]],
            fatherMobileNo: ['', [Validators.required, Validators.pattern(/^[0-9+\-()\s]{7,20}$/)]],
            dob: ['', Validators.required],
            genderId: ['1', Validators.required],   // default to Male
            // row 3
            nationalityId: ['', [Validators.required, this.notZeroValidator]],
            stateId: ['', [Validators.required, this.notZeroValidator]],
            districtId: ['', [Validators.required, this.notZeroValidator]],
            cityId: ['', [Validators.required, this.notZeroValidator]],
            // row 4
            instituteId: ['', [Validators.required, this.notZeroValidator]],
            degreeId: ['', [Validators.required, this.notZeroValidator]],
            branchId: ['', [Validators.required, this.notZeroValidator]],
            semesterId: ['', [Validators.required, this.notZeroValidator]],
            // row 5
            admissionThroughId: ['', [Validators.required, this.notZeroValidator]],
            admissionTypeId: ['', [Validators.required, this.notZeroValidator]],
            admissionYearId: ['', [Validators.required, this.notZeroValidator]],
            admissionBatchId: ['', [Validators.required, this.notZeroValidator]],
            // row 6
            doe: ['', Validators.required],                     // Date of Entry
            admissionCategoryId: ['', [Validators.required, this.notZeroValidator]],      // for now caterory only
            paymentTypeId: ['', [Validators.required, this.notZeroValidator]],
            receiptTypeId: ['', [Validators.required, this.notZeroValidator]],
            // row 7
            seesionId: ['', [Validators.required, this.notZeroValidator]],
            applicationId: [],
            meritNo: [],
            score: [],
            totalApplicableFees: [],
            // row 8
            isScholarship: ['1'],
            scholarshipTypeId: ['', [Validators.required, this.notZeroValidator]],
            scholarshipModeId: ['', [Validators.required, this.notZeroValidator]],
            scholarshipPercentage: ['', Validators.required],
            // row 9
            isFeeInstallment: ['1'],
            installmentTypeId: ['', [Validators.required, this.notZeroValidator]],
            firstInstallmentDueDate: ['', Validators.required],
            secondInstallmentDueDate: ['', Validators.required],
   
        });

        this.loadLookups();
    }

    get f() {
        return this.studentForm.controls;
    }

    loadLookups(): void {
        const lookupKeys = [
            'admissionbatch', 'admissioncategory', 'admissionthrough', 'admissiontype', 'admissionyear',
            'bloodgroup', 'branch', 'caste', 
            'city', 'country', 'degree', 'district',
            'gender', 'institute', 'nationality', 'paymenttype',
            'receipttype', 'scholarshipmode', 'scholarshiptype', 'semester',
            'session', 'state', 'installmenttype'
        ];

        const lookupRequests = lookupKeys.map(key => {
            console.log('Loading lookup for:', key);
            const obs$ = this.ms.getLookup(key);
            console.log('Observable returned:', obs$);
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


    onSubmit(): void {
        console.log('Form Submitted', this.studentForm.invalid);
        if (this.studentForm.invalid) {
            this.studentForm.markAllAsTouched();
            return;
        }

        const student: Student = {
            studentId: 0,
            ...this.studentForm.value,
            isScholarship:
                this.studentForm.value.isScholarship === '1' ||
                this.studentForm.value.isScholarship === 1 ||
                this.studentForm.value.isScholarship === true,
            isFeeInstallment:
                this.studentForm.value.isFeeInstallment === '1' ||
                this.studentForm.value.isFeeInstallment === 1 ||
                this.studentForm.value.isFeeInstallment === true
            };

        console.log('Submitted Student:', student);
        this.ms.postStudent(student).subscribe({
                next: () => {
                    this._snackBar.open('Record Saved!!', '', {
                        duration: 4000,
                        horizontalPosition: 'right',
                        verticalPosition: 'top'
                    });
                    this.studentForm.reset();
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

      private notZeroValidator(control: AbstractControl): ValidationErrors | null {
        console.log('Validating control with value:', control.value);
        return control.value === 0 ? { notZero: true } : null;
    }

}