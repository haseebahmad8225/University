using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Model
{
    public class TeacherStudentAsign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TeacherId { get; set; }
        public long studentId { get; set; }
    }
}
