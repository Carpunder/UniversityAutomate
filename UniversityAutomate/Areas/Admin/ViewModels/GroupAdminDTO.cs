using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.ViewModels
{
    public class GroupAdminDTO
    {
        public int GroupID { get; set; }
        [Display(Name = "Название")]
        public string GroupName { get; set; }
        [ValidateNever]
        [Display(Name = "Университет")]
        public string UniversityName { get; set; }
    }
}
