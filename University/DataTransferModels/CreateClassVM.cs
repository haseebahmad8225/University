using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataTransferModels
{
    public class CreateClassVM
    {
        public long DepartmentId { get; set; }
        public long teacherId { get; set; }
        public string Subject { get; set; } = "";
        public string ClassStartTime { get; set; } = "";
        public string ClassEndTime { get; set; } = "";
    }
}
