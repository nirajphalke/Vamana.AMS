using Vamana.AMS.Core.Entities.Students;
using Vamana.AMS.Core.Interfaces;
using Vamana.AMS.Infrastructure.Data;

namespace Vamana.AMS.Infrastructure.Repositories;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentDbContext context) : base(context) { }
}
