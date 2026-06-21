using Microsoft.AspNetCore.Mvc;
using Vamana.AMS.Core.Models.Students;
using Vamana.AMS.Services.Students.Interfaces;

namespace Vamana.AMS.Api.Controllers.Students;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService, ILogger<StudentController> logger) : ControllerBase
{
    const int USERID = 1;
    const int ORGANIZATIONID = 1;
    const string MACADDRESS = "00-14-22-01-23-45";
    const string IPADDRESS = "";
    private readonly IStudentService _studentService = studentService;
    private readonly ILogger<StudentController> _logger = logger;


    [HttpPost("add")]
    public async Task<IActionResult> AddStudent([FromBody] StudentModel studentModel)
    {
        try
        {
            _logger.LogInformation("GET request received for StudentController:AddStudent");
            studentModel.CreatedBy = USERID;
            studentModel.CreatedDate = DateTime.Now;
            studentModel.ModifiedDate = null;
            studentModel.IPAddress = IPADDRESS;
            studentModel.OrganizationId = ORGANIZATIONID;
            studentModel.MACAddress = MACADDRESS;
            
            var result = await _studentService.AddStudentAsync(studentModel);
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("StudentController:AddStudent: " + ex.Message);
            // Log the exception (not shown here for brevity)
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}
