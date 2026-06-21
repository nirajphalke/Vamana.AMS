using AutoMapper;
using Vamana.AMS.Core.Entities.Students;
using Vamana.AMS.Core.Interfaces;
using Vamana.AMS.Core.Models.Students;
using Vamana.AMS.Infrastructure.Data;
using Vamana.AMS.Services.Students.Interfaces;

namespace Vamana.AMS.Services.Students;

public class StudentService(IStudentRepository repo, StudentDbContext context, IMapper mapper) : IStudentService
{
    private readonly IStudentRepository _repo = repo;
    private readonly StudentDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<StudentModel> AddStudentAsync(StudentModel model)
    {
        var entity = _mapper.Map<Student>(model);
        _context.Set<Student>().Add(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<StudentModel>(entity);
    }

    //// Read (Get by Id)  
    //public async Task<Student?> GetStudentByIdAsync(int studentId)  
    //{  
    //    return await _context.Set<Student>().FindAsync(studentId);  
    //}  

    //// Read (Get all)  
    //public async Task<List<Student>> GetAllStudentsAsync()  
    //{  
    //    return await _context.Set<Student>().ToListAsync();  
    //}  

    //// Update  
    //public async Task<bool> UpdateStudentAsync(Student student)  
    //{  
    //    var existing = await _context.Set<Student>().FindAsync(student.StudentId);  
    //    if (existing == null)  
    //        return false;  

    //    _context.Entry(existing).CurrentValues.SetValues(student);  
    //    await _context.SaveChangesAsync();  
    //    return true;  
    //}  

    //// Delete  
    //public async Task<bool> DeleteStudentAsync(int studentId)  
    //{  
    //    var student = await _context.Set<Student>().FindAsync(studentId);  
    //    if (student == null)  
    //        return false;  

    //    _context.Set<Student>().Remove(student);  
    //    await _context.SaveChangesAsync();  
    //    return true;  
    //}  
}
