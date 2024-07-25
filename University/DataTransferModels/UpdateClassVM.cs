using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataTransferModels
{
    public class UpdateClassVM
    {
        public long ClassId { get; set; }
        public long DepartmentId { get; set; }
        public long teacherId { get; set; }
        public string Subject { get; set; } = "";
        public string ClassStartTime { get; set; } = "";
        public string ClassEndTime { get; set; } = "";
    }
}