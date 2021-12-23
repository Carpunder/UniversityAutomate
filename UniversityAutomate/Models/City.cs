using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniversityAutomate.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }

        [ValidateNever]
        public List<University> Universities { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }
    }
}
