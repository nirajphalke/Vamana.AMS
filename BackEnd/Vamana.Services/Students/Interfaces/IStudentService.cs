using Vamana.AMS.Core.Entities.Students;
using Vamana.AMS.Core.Models.Students;

namespace Vamana.AMS.Services.Students.Interfaces;

public interface IStudentService
{
    Task<StudentModel> AddStudentAsync(StudentModel model);
}
