namespace UniversityAutomate.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime Birthday { get; set; }
        public double Bursary { get; set; }
        public double? Bonus { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }

        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
