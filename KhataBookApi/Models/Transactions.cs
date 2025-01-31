using System;
namespace KhataBookApi.Models
{
	public class Transactions:BaseModel
	{
		public int kid { get; set; }
		public double amount { get; set; }
		public string description { get; set; }
		public TransactionType type { get; set; }

	}
}

