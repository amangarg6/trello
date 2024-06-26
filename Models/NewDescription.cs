﻿using System.ComponentModel.DataAnnotations.Schema;

namespace trello.Models
{
    public class NewDescription
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? CardId { get; set; }
        public Card? Card { get; set; }
    }
}
