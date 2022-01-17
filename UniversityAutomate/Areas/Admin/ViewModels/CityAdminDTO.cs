using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.ViewModels
{
    public class CityAdminDTO
    {
        public int CityID { get; set; }
        [Display(Name = "Название")]
        public string CityName { get; set; }
        [Display(Name = "Население")]
        public int Population { get; set; }
        
    }
}