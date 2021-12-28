using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniversityAutomate.Areas.Admin.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime Birthday { get; set; }
        public double Bursary { get; set; }
        public double? Bonus { get; set; }

        public int? CityID { get; set; }
        [ValidateNever]
        public City City { get; set; }

        public int GroupID { get; set; }
        [ValidateNever]
        public Group Group { get; set; }
    }
}
