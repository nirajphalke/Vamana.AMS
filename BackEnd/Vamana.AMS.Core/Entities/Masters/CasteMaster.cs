using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class CasteMaster: BaseEntity
{
    [Key]
    public int CasteId { get; set; }
    public int CategoryId { get; set; }
    public string CasteName { get; set; } = string.Empty;
    // Navigation property
    public CategoryMaster? Category { get; set; } = default!;
}

