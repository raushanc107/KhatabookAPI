namespace KhataBookApi.Models
{
    public class RentalDetails :BaseModel
    {
        public int carid { get; set; }
        public int cityId { get; set; }
        public double amount { get; set; }
        public double tax { get; set; }
        public double discount { get; set; }

        public int availablein { get; set; }


    }
}
