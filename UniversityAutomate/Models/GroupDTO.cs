using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Models
{
    public class GroupDTO
    {
        [ValidateNever]
        [Display(Name = "Название")]
        public string UniversityName { get; set; }

        [Display(Name = "Группа")]
        public string GroupName { get; set; }

        [ValidateNever]
        [Display(Name = "Студенты")]
        public List<StudentDTO> Students { get; set; }
    }
}
