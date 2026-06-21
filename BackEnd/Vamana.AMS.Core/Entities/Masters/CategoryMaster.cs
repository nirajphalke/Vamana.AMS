using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class CategoryMaster: BaseEntity
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryShortName { get; set; } = string.Empty;
    public string CategoryLongName { get; set; } = string.Empty;
    // Navigation property
    public ICollection<CasteMaster> Castes { get; set; } = new List<CasteMaster>();
}
