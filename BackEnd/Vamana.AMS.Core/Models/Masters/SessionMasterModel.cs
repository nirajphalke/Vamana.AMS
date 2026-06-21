namespace Vamana.AMS.Core.Models.Masters;

public class SessionMasterModel : BaseMasterModel
{
    public int SessionId { get; set; } = default!;
    public string SessionName { get; set; } = string.Empty;
    public string SessionLongName { get; set; } = string.Empty;

}
