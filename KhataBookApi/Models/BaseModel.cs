using System;
using System.ComponentModel.DataAnnotations;

namespace KhataBookApi.Models
{
	public class BaseModel
	{
		[Key]
		public int id { get; set; }

		public DateTime cretedon { get; set; } = DateTime.UtcNow;

		public DateTime? updatedon { get; set; }

		public bool isActive { get; set; } = true;

		public bool isDeleted { get; set; } = false;
	}
}

