using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class NationalityMaster: BaseEntity
{
    [Key]
    public int NationalityId { get; set; }
    public string NationalityName { get; set; } = string.Empty;
}
