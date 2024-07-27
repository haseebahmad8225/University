namespace University.Model
{
    public class TeacherQualification
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public string Degree { get; set; } = "";
        public string StartYear { get; set; } = "";
        public string EndYear { get; set; } = "";
    }
}
