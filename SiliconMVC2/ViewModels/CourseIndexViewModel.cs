using Infrastructure.Models;

namespace SiliconMVC2.ViewModels;

public class CourseIndexViewModel
{
    public IEnumerable<CoursesModel> Courses { get; set; } = [];
}
