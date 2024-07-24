using Application.DataTransferModels.ResponseModels;

namespace University.DataTransferModels
{
    public class CreateStudentVM
    {
        public long TeacherId { get; set; }

        public string StudentName { get; set; } = "";
        public string FatherName { get; set; } = "";
        public int Age { get; set; }
        public string CNIC { get; set; } = "";
        public string DOB { get; set; } = "";
        public string Religion { get; set; } = "";
        public string AdmissionDate { get; set; } = "";
        public long DepartmentId { get; set; }
        public string Semester { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public bool IsActive { get; set; } = true;

    }
}
