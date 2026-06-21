using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class ScholarshipTypeMaster : BaseEntity
{
    [Key]
    public int ScholarshipTypeId { get; set; }
    public string ScholarshipTypeName { get; set; } = string.Empty;
}
