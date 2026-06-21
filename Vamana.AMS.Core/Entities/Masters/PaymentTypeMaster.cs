using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class PaymentTypeMaster : BaseEntity
{
    [Key]
    public int PaymentTypeId { get; set; }
    public string PaymentTypeName { get; set; } = string.Empty;

}
