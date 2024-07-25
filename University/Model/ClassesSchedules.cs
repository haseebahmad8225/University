using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Model
{
    public class ClassesSchedules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClassId { get; set; }
        public long DepartmentId { get; set; }
        public long TeacherId { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Subject { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]

        public string ClassStartTime { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]

        public string ClassEndTime { get; set; } = ""; 
    }
}
