using System;
using System.ComponentModel.DataAnnotations;

namespace KhataBookApi.Models
{
	public class Khata :BaseModel
	{

        public int userid { get; set; }
		public string name { get; set; }

        
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? email { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Contact number must be a 10-digit number starting with 6, 7, 8, or 9.")]
        public string? contactnumber { get; set; }

    }
}

