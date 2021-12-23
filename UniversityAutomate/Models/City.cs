namespace UniversityAutomate.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }

        public List<University> Universities { get; set; }

        public List<Student> Students { get; set; }
    }
}
