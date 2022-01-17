using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.ViewModels
{
    public class StudentAdminDTO
    {
        public int StudentID { get; set; }
        [Display(Name = "ФИО")]
        public string StudentName { get; set; }
        [Display(Name = "День рождения")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Display(Name = "Заработная плата")]
        public double Bursary { get; set; }
        [Display(Name = "Премия")]
        public double? Bonus { get; set; }
        [Display(Name = "Город")]
        public string CityName { get; set; }
        [Display(Name = "Университет")]
        public string UniversityName { get; set; }
        [Display(Name = "Группа")]
        public string GroupName { get; set; }
    }
}
