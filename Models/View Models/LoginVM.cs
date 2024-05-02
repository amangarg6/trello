using System.ComponentModel.DataAnnotations;

namespace trello.Models.View_Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
