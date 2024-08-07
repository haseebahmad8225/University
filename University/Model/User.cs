using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace University.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Email { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Password { get; set; } = "";
        private string HashPassword { get; set; } = "";
    }
}
