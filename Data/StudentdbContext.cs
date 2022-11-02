using LoginAndCRUDCoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAndCRUDCoreProject.Data
{
    public class StudentdbContext : DbContext
    {
        public StudentdbContext(DbContextOptions<StudentdbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
