using Microsoft.EntityFrameworkCore;
using Vamana.AMS.Core.Entities.Students;

namespace Vamana.AMS.Infrastructure.Data;
 
public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");
            entity.HasKey(e => e.StudentId);
        });
    }
}
