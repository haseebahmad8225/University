namespace University.DataTransferModels
{
    public class UpdateTeacherVM
    {
        public long TeacherId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Subject { get; set; } = "";
        public string JoiningDate { get; set; } = "";
        public long DepartmentId { get; set; }
        public string Phone { get; set; } = "";
        public string CNIC { get; set; } = "";
        public string Email { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
    }
}