using System.ComponentModel.DataAnnotations;

namespace Vamana.AMS.Core.Entities.Masters;

public class SessionMaster : BaseEntity
{
    [Key]
    public int SessionId { get; set; }
    public string SessionName { get; set; } = string.Empty;
    public string SessionLongName { get; set; } = string.Empty;

}
