namespace University.DataTransferModels
{
    public class UpdateUniversityVM
    {
        public long UniversityId { get; set; }
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
        public int EstablishedYear { get; set; }


    }
}
