using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Students;

[Table("Students")]
public class Student
{
    [Key]
    public int StudentId { get; set; }

    public int? TitleId { get; set; }

    [StringLength(24)]
    public string? EnrollmentNo { get; set; }

    [StringLength(24)]
    public string? RegistrationNo { get; set; }

    [StringLength(48)]
    public string? StudentName { get; set; }

    [StringLength(64)]
    public string? StudentNameInLocal { get; set; }

    [StringLength(64)]
    public string? StudentEmailId { get; set; }

    [StringLength(48)]
    public string? FatherName { get; set; }

    [StringLength(24)]
    public string? StudentMobileNo { get; set; }

    [StringLength(24)]
    public string? FatherMobileNo { get; set; }

    [StringLength(48)]
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

    [StringLength(12)]
    public string? ApplicationId { get; set; }

    [StringLength(12)]
    public string? MeritNo { get; set; }

    [StringLength(12)]
    public string? Score { get; set; }

    [Column(TypeName = "decimal(18,0)")]
    public decimal? TotalApplicableFees { get; set; }

    public bool IsScholarship { get; set; } = false;

    public int? ScholarshipTypeId { get; set; }
    public int? ScholarshipModeId { get; set; }

    [Column(TypeName = "decimal(18,0)")]
    public decimal? ScholarshipPercentage { get; set; }

    public bool IsFeeInstallment { get; set; } = false;

    public int? InstallmentTypeId { get; set; }
    public DateTime? FirstInstallmentDueDate { get; set; }
    public DateTime? SecondInstallmentDueDate { get; set; }

    public int? CreatedBy { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public int? OrganizationId { get; set; }

    [StringLength(64)]
    public string? IPAddress { get; set; }

    [StringLength(128)]
    public string? MACAddress { get; set; }
}
