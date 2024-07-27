using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.Model
{
    public class UniversityDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UniversityId { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; } = "";
        [Column(TypeName = "NVARCHAR(50)")]
        public string Location { get; set; } = "";
        public int EstablishedYear { get; set; }
    }
}
