namespace KhataBookApi.Models
{
    public class Booking : BaseModel
    {
        public int userid { get; set; }
        public int carid { get; set; }
        public int cityid { get; set; }

        public int subscriptiontenure { get; set; }
        public double monthlyFees { get; set; }

        public int taxPercentage { get; set; }
        public double taxAmount {get;set;}

        public double bookingCharge { get; set; }
        public double processingFees { get; set; }
        public double depositAmount { get; set; }
        public double totalPayableAmount { get; set; }


    }
}
