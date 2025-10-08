using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        //.empty to start empty then choose form the dropdown menu
        public string Role { get; set; } = string.Empty;
    }
}
