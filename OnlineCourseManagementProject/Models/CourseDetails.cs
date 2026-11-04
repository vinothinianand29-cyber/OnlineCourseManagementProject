using System.ComponentModel.DataAnnotations;

namespace OnlineCourseManagementProject.Models
{
    public class CourseDetails
    {
       [Key] public int CourseId { get; set; }

       [Required] public string? CourseName { get; set; }

        [Required] public string? Duration { get; set; }

        [Required] public double Fee { get; set; }

        [Required] public string? Trainer {  get; set; }

        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
