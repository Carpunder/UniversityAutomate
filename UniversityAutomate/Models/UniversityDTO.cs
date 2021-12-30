using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using UniversityAutomate.Areas.Admin.Models;

namespace UniversityAutomate.Models
{
    public class UniversityDTO
    {
        [ValidateNever]
        [Display(Name = "Город")]
        public string CityName { get; set; }
        [Display(Name = "Название")]
        public string UniversityName { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [ValidateNever]
        [Display(Name = "Группы")]
        public List<Group> Groups { get; set; }
    }
}
