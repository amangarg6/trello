using System.Collections.Generic;

namespace trello.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public enum Visibility
        {
          Public,
          Private,
          Workspace
        }
        public Visibility  visibility { get; set; }
    }
}

