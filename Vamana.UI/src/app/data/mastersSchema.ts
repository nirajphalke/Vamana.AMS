import { MasterMeta, MasterField }  from '../interfaces/masters';

export const masters: MasterMeta[] = [
    {
      key: 'admissioncategory',
      title: 'Admission Category',
      fields: [
        { name: 'CategoryId', label: 'Id', type: 'number', visible: false },
        { name: 'CategoryName', label: 'Name', type: 'string', visible: true, required: true },
        { name: 'CategoryLongName', label: 'Long Name', type: 'string', visible: true, required: true },
        { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
      ]
    },
    {
      key: 'caste',
      title: 'Caste',
      fields: [
        { name: 'CasteId', label: 'Caste Id', type: 'number', visible: false },
        { name: 'CategoryId', label: 'Category', type: 'number', fkTo: 'admissioncategory', visible: true, text: 'CategoryName', required: true },
        { name: 'CasteName', label: 'Caste Name', type: 'string', visible: true, required: true },
        { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
      ]
    },
  {
    key: 'nationality',
    title: 'Nationality',
    fields: [
      { name: 'NationalityId', label: 'Id', type: 'number', visible: false },
      { name: 'NationalityName', label: 'Nationality', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'religion',
    title: 'Religion',
    fields: [
      { name: 'ReligionId', label: 'Id', type: 'number', visible: false },
      { name: 'ReligionName', label: 'Religion', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'bloodgroup',
    title: 'Blood Group',
    fields: [
      { name: 'BloodGroupId', label: 'Id', type: 'number', visible: false },
      { name: 'BloodGroupName', label: 'Blood Group', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'admissionBatch',
    title: 'Admission Batch',
    fields: [
      { name: 'AdmissionBatchId', label: 'Id', type: 'number', visible: false },
      { name: 'AdmissionBatchName', label: 'Batch Name', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'country',
    title: 'Country',
    fields: [
      { name: 'CountryId', label: 'Id', type: 'number', visible: false },
      { name: 'CountryName', label: 'Country', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'state',
    title: 'State',
    fields: [
      { name: 'StateId', label: 'Id', type: 'number', visible: false },
      { name: 'CountryId', label: 'Country', type: 'number', fkTo: 'country', visible: true, required: true, text: 'CountryName' },
      { name: 'StateName', label: 'State', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'district',
    title: 'District',
    fields: [
      { name: 'DistrictId', label: 'Id', type: 'number', visible: false },
      { name: 'StateId', label: 'State', type: 'number', fkTo: 'state', visible: true, required: true, text: 'StateName' },
      { name: 'DistrictName', label: 'District', type: 'string', visible: true, required: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true }
    ]
  },
  {
    key: 'city',
    title: 'City',
    fields: [
      { name: 'CityId', label: 'Id', type: 'number', visible: false },
      { name: 'DistrictId', label: 'District', type: 'number', fkTo: 'district', visible: true, required: true, text: 'DistrictName' },
      { name: 'StateId', label: 'State', type: 'number', fkTo: 'state', visible: false },
      { name: 'CityName', label: 'City', type: 'string', visible: true, required: true, },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true, required: true, }
    ]
  },
  {
    key: 'month',
    title: 'Month',
    fields: [
      { name: 'MonthId', label: 'Id', type: 'number', visible: false },
      { name: 'MonthName', label: 'Month', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'year',
    title: 'Year',
    fields: [
      { name: 'YearId', label: 'Id', type: 'number', visible: false },
      { name: 'YearName', label: 'Year', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'title',
    title: 'Title',
    fields: [
      { name: 'TitleId', label: 'Id', type: 'number', visible: false },
      { name: 'TitleName', label: 'Title', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'admissionCategory',
    title: 'Admission Category',
    fields: [
      { name: 'AdmissionCategoryId', label: 'Id', type: 'number', visible: false },
      { name: 'AdmissionCategoryName', label: 'Admission Category', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'gender',
    title: 'Gender',
    fields: [
      { name: 'GenderId', label: 'Id', type: 'number', visible: false },
      { name: 'GenderName', label: 'Gender', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'handicapType',
    title: 'Handicap Type',
    fields: [
      { name: 'HandicapTypeId', label: 'Id', type: 'number', visible: false },
      { name: 'HandicapTypeName', label: 'Handicap Type', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'addressType',
    title: 'Address Type',
    fields: [
      { name: 'AddressTypeId', label: 'Id', type: 'number', visible: false },
      { name: 'AddressTypeName', label: 'Address Type', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'designation',
    title: 'Designation',
    fields: [
      { name: 'DesignationId', label: 'Id', type: 'number', visible: false },
      { name: 'DesignationName', label: 'Designation', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'employeeType',
    title: 'Employee Type',
    fields: [
      { name: 'EmployeeTypeId', label: 'Id', type: 'number', visible: false },
      { name: 'EmployeeTypeName', label: 'Employee Type', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  },
  {
    key: 'status',
    title: 'Status',
    fields: [
      { name: 'StatusId', label: 'Id', type: 'number', visible: false },
      { name: 'StatusName', label: 'Status', type: 'string', visible: true },
      { name: 'IsActive', label: 'Active', type: 'boolean', visible: true }
    ]
  }
];
