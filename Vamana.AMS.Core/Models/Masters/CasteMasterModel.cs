namespace Vamana.AMS.Core.Models.Masters;

public class CasteMasterModel: BaseMasterModel
{
    public int CasteId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CasteName { get; set; } = string.Empty;
}

