using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class StateMaster: BaseEntity
{
    [Key]
    public int StateId { get; set; }
    public int CountryId { get; set; }
    public string StateName { get; set; } = string.Empty;
    // Navigation property
    public CountryMaster Country { get; set; } = default!;
    public ICollection<DistrictMaster> Districts { get; set; } = new List<DistrictMaster>();

}
