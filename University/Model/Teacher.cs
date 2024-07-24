using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Model
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeacherId { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string FirstName { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")] 
        public string LastName { get; set; } = "";


        [Column(TypeName = "NVARCHAR(50)")]
        
        public string Subject { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")] 
        public string JoiningDate { get; set; } = "";

        public long DepartmentId { get; set; } 

        [Column(TypeName = "NVARCHAR(50)")]
        public string Phone { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]

        public string CNIC { get; set; } = "";


        [Column(TypeName = "NVARCHAR(50)")]
        public string Email { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string City { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string State { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]

        public string Country { get; set; } = "";

    }
}
