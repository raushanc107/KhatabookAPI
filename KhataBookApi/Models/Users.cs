using System.ComponentModel.DataAnnotations;

namespace KhataBookApi.Models
{
    public class Users :BaseModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }= "user";
    }


    public class UserRegisterDto
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only contain letters")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 8 and 100 characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }

    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 8 and 100 characters", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#]).{8,}$",
            ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one number, and one special character")]
        public string Password { get; set; }

    }


}
