using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class GenderMaster: BaseEntity
{
    [Key]
    public int GenderId { get; set; }
    public string GenderName { get; set; } = string.Empty!;
}

