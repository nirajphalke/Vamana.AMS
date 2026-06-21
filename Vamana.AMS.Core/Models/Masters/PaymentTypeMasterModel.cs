namespace Vamana.AMS.Core.Models.Masters;

public class PaymentTypeMasterModel: BaseMasterModel
{
    public int PaymentTypeId { get; set; } = default!;
    public string PaymentTypeName { get; set; } = string.Empty;
}
