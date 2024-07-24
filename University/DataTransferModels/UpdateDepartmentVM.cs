namespace University.DataTransferModels
{
    public class UpdateDepartmentVM
    {
        public long DepartmentId { get; set; }

        public string DepartmentName { get; set; } = "";
        public string Description { get; set; } = "";

        public long UniversityId { get; set; }
    }
}
