using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class SemesterMaster: BaseEntity
{
    [Key]
    public int SemesterId { get; set; }
    public string SemesterShortName { get; set; } = string.Empty;
    public string SemesterLongName { get; set; } = string.Empty;
}
