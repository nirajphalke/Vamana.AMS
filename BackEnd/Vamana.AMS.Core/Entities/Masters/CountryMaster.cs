using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class CountryMaster: BaseEntity
{
    [Key]
    public int CountryId { get; set; } = default!;
    public string CountryName { get; set; } = default!;
    // Navigation property
    //public ICollection<StateMaster> States { get; set; } = new List<StateMaster>();
}
