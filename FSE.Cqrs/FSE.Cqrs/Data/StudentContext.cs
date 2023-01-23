using Microsoft.EntityFrameworkCore;

namespace FSE.Cqrs.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[] {
                new Student(){ Name="Fatih",Age=26,Surname="Er",Id=1},
                new Student(){Name="Suleyman",Age=26,Surname="Er",Id=2}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
