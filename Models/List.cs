using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace trello.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? BoardId { get; set; }
        [ForeignKey("BoardId")]
        public Board? board { get; set; }
        public int? CardId { get; set; }
        [ForeignKey("CardId")]
        public Card? Card { get; set; }

    }
}
