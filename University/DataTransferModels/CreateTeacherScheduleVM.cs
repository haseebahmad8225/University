namespace University.DataTransferModels
{
    public class CreateTeacherScheduleVM
    {
        public long TeacherId { get; set; }
        public long DepartmentId { get; set; }
        public string Subject { get; set; } = "";
        public string Shift { get; set; } = "";
        public string Timing { get; set; } = "";
    }
}
