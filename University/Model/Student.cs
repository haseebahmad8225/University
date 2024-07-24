using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace University.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long StudentId { get; set; }
        [ForeignKey("TeacherId")]
        public long TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string StudentName { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string FatherName { get; set; } = "";

        public int Age { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]

        public string CNIC { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string DOB { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")] 
        public string Religion { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string AdmissionDate { get; set; } = "";
        public long DepartmentId { get; set; }


        [Column(TypeName = "NVARCHAR(50)")]

        public string Semester { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string Email { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string Phone { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string City { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string State { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]

        public string Country { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
}
