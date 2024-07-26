namespace University.DataTransferModels
{
    public class UpdateTeacherScheduleVM
    {
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public long DepartmentId { get; set; }
        public string Subject { get; set; } = "";
        public string Shift { get; set; } = "";
        public string Timing { get; set; } = "";
    }
}
