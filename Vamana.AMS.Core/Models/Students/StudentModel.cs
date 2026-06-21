
namespace Vamana.AMS.Core.Models.Students;

public class StudentModel
{
    public int StudentId { get; set; }
    public int? TitleId { get; set; }
    public string? EnrollmentNo { get; set; }
    public string? RegistrationNo { get; set; }
    public string? StudentName { get; set; }
    public string? StudentNameInLocal { get; set; }
    public string? StudentEmailId { get; set; }
    public string? FatherName { get; set; }
    public string? StudentMobileNo { get; set; }
    public string? FatherMobileNo { get; set; }
    public string? FatherEmailId { get; set; }
    public DateTime? DOB { get; set; }
    public int? GenderId { get; set; }
    public int? NationalityId { get; set; }
    public int? DistrictId { get; set; }
    public int? StateId { get; set; }
    public int? CityId { get; set; }
    public int? InstituteId { get; set; }
    public int? DegreeId { get; set; }
    public int? BranchId { get; set; }
    public int? SemesterId { get; set; }
    public int? AdmissionThroughId { get; set; }
    public int? AdmissionTypeId { get; set; }
    public int? YearId { get; set; }
    public int? AdmissionBatchId { get; set; }
    public DateTime? DOE { get; set; }
    public int? AdmissionCategoryId { get; set; }
    public int? PaymentTypeId { get; set; }
    public int? ReceiptTypeId { get; set; }
    public int? SessionId { get; set; }
    public string? ApplicationId { get; set; }
    public string? MeritNo { get; set; }
    public string? Score { get; set; }
    public decimal? TotalApplicableFees { get; set; }
    public bool IsScholarship { get; set; } = false;
    public int? ScholarshipTypeId { get; set; }
    public int? ScholarshipModeId { get; set; }
    public decimal? ScholarshipPercentage { get; set; }
    public bool IsFeeInstallment { get; set; } = false;
    public int? InstallmentTypeId { get; set; }
    public DateTime? FirstInstallmentDueDate { get; set; }
    public DateTime? SecondInstallmentDueDate { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? OrganizationId { get; set; }
    public string? IPAddress { get; set; }
    public string? MACAddress { get; set; }
}
