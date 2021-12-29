using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.Models
{
    public class City
    {
        public int CityID { get; set; }
        [Display(Name = "Название")]
        public string CityName { get; set; }
        [Display(Name = "Население")]
        public int Population { get; set; }

        [ValidateNever]
        [Display(Name = "Университеты")]
        public List<University> Universities { get; set; }

        [ValidateNever]
        [Display(Name = "Студенты")]
        public List<Student> Students { get; set; }
    }
}
