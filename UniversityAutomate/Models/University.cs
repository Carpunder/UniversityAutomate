using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniversityAutomate.Models
{
    public class University
    {
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string Address { get; set; }

        public int CityID { get; set; }
        [ValidateNever]
        public City City { get; set; }

        [ValidateNever]
        public List<Group> Groups { get; set; }
    }
}
