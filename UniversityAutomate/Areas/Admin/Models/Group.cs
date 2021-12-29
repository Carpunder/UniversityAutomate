using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        [Display(Name = "Название")]
        public string GroupName { get; set; }
        [Display(Name = "Университет")]

        public int UniversityID { get; set; }
        [ValidateNever]
        [Display(Name = "Университет")]
        public University University { get; set; }

        [ValidateNever]
        [Display(Name = "Студенты")]
        public List<Student> Students { get; set; }
    }
}
