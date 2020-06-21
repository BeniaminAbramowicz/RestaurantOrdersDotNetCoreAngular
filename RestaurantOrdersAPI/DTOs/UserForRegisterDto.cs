using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersAPI.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must contain between 8 and 20 characters")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}