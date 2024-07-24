using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Model
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DepartmentId { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string DepartmentName { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string Description { get; set; } = "";
        [ForeignKey("UniversityId")]
        public UniversityDetails? University { get; set; }
        public long UniversityId { get; set; } 
    }
}
