namespace UniversityAutomate.Models
{
    public class University
    {
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public string Address { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }

        public List<Group> Groups { get; set; }
    }
}
