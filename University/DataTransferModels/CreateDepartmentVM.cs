namespace University.DataTransferModels
{
    public class CreateDepartmentVM
    {
        public string DepartmentName { get; set; } = "";
        public string Description { get; set; } = "";

        public long UniversityId { get; set; }
    }
}
