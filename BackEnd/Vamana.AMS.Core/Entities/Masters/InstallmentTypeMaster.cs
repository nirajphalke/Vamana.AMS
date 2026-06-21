using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class InstallmentTypeMaster: BaseEntity
{
    [Key]
    public int InstallmentTypeId { get; set; }
    public string InstallmentTypeName { get; set; } = string.Empty;
}

