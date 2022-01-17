using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.ViewModels
{
    public class UniversityAdminDTO
    {
        public int UniversityID { get; set; }
        [Display(Name = "Название")]
        public string UniversityName { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Город")]
        public string CityName { get; set; }
    }
}
