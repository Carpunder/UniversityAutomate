namespace UniversityAutomate.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public int UniversityID { get; set; }
        public University University { get; set; }

        public List<Student> Students { get; set; }
    }
}
