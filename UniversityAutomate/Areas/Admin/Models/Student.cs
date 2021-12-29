using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UniversityAutomate.Areas.Admin.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display(Name = "ФИО")]
        public string StudentName { get; set; }
        [Display(Name = "День рождения")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Заработная плата")]
        public double Bursary { get; set; }
        [Display(Name = "Премия")]
        public double? Bonus { get; set; }
        [Display(Name = "Город")]

        public int? CityID { get; set; }
        [ValidateNever]
        [Display(Name = "Город")]
        public City City { get; set; }

        [Display(Name = "Группа")]
        public int GroupID { get; set; }
        [ValidateNever]
        [Display(Name = "Группа")]
        public Group Group { get; set; }
    }
}
