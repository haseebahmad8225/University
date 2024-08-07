using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.Model
{
    public class SignUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SignUpId { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string FirstName { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string LastName { get; set; } = "";

        [Column(TypeName = "NVARCHAR(50)")]
        public string UserName { get; set; } = "";

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Email { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string PhoneNumber { get; set; } = "";
    }
}
