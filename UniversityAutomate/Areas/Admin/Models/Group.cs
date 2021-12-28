using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniversityAutomate.Areas.Admin.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public int UniversityID { get; set; }
        [ValidateNever]
        public University University { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }
    }
}
