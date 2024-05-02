using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trello.Models
{
    public class Register
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [EmailAddress]   
        public string? Email { get; set; }
        public string? Password { get; set; }
        [NotMapped]
        public string Token { get; set; } = string.Empty;
    }
}
