using System.ComponentModel.DataAnnotations.Schema;

namespace trello.Models
{
    public class Open
    {
        public int Id { get; set; }    
        public string? Comment { get; set; }
  
        public int? CardId { get; set; }
        public Card? Card { get; set; }


    }
}
