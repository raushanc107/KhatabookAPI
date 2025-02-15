namespace KhataBookApi.Models
{
    public class Cars :BaseModel
    {
        public string imageURL { get; set; }
        public string carName { get; set; }
        public string fuelType { get; set; }
        public string TransmissionType { get; set; }
        public bool isHybrid { get; set; } = false;
        public bool isNew { get; set; }
        public string Segments { get; set; }
        public string brand { get; set; }

    }
}
