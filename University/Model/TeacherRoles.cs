using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.Model
{
    public class TeacherRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TeacherId { get; set; }

        public long DepartmentId { get; set; }

        public string Role { get; set; } = "";
    }
}
