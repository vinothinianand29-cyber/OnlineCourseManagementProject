using Microsoft.EntityFrameworkCore;

namespace OnlineCourseManagementProject.Models.Database
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }

        public DbSet<CourseDetails> CourseDatas { get; set; }
    }
}
