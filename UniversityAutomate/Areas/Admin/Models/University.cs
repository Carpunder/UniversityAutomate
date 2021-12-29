using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.Models
{
    public class University
    {
        public int UniversityID { get; set; }
        [Display(Name = "Название")]
        public string UniversityName { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Город")]

        public int CityID { get; set; }
        [ValidateNever]
        [Display(Name = "Город")]
        public City City { get; set; }

        [ValidateNever]
        [Display(Name = "Группы")]
        public List<Group> Groups { get; set; }
    }
}
