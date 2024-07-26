using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.Model
{
    public class TeacherSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public long DepartmentId { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Subject { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Shift { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Timing { get; set; } = "";
    }
}
