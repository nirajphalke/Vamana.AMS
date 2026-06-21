export interface Student {
    studentId: number;                     // Primary Key
    studentName: string;
    fatherName: string;
    studentEmailId:string;
    // row 2
    studentMobileNo: string;
    parentMobileNo: string;
    dob: Date;                              // Student Date of Birth - ISO date string
    genderId: number,
    // row 3
    nationalityId: number;
    districtId: number;
    stateId: number;
    cityId: number;
    // row 4
    instituteId: number;
    degreeId: number;
    branchId: number;
    semesterId: number;
    // row 5
    admissionThroughId: number;
    admissionTypeId: number;
    admissionYearId: number;       // admission year - 1,2,3.. ??
    admissionBatchId: number;
    // row 6
    doe: Date;                              // Date of Entry
    admissionCategoryId: number;
    paymentTypeId: number;
    receiptTypeId: number;
    // row 7
    seesionId: number;
    applicationId: string;
    meritNo: string;
    score: string;
    totalApplicableFees: number;
    // row 8
    isScholarship: boolean;
    scholarshipTypeId: number;
    scholarshipModeId: number;
    scholarshipPercentage: number;
    // row 9
    isFeeInstallment: boolean;
    installmentTypeId: number;
    firstInstallmentDueDate: Date;
    secondInstallmentDueDate: Date;
 
    createdBy?: number;
    createdDate?: string;
    modifiedBy?: number;
    modifiedDate?: string;
    organizationId?: number;
    ipAddress?: string;
    macAddress?: string;
}
