using System.ComponentModel.DataAnnotations.Schema;

namespace trello.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ListId { get; set; }
        [ForeignKey("ListId")]
        public List? list { get; set; }
    }
}
