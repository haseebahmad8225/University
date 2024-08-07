using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.Model
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string UserName { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Email { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Password { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Token { get; set; } = "";
    }
}
