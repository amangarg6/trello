using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trello.Models;

namespace trello.Controllers
{
    [Route("api/trello")]
    [ApiController]
    public class TrelloController : ControllerBase
    {
        private static List<Board> boards = new List<Board>();

        [HttpGet]
        public ActionResult<IEnumerable<Board>> GetBoards()
        {
            return Ok(boards);
        }

        [HttpPost]
        public ActionResult<Board> CreateBoard([FromBody] Board board)
        {
            board.Id = boards.Count + 1;
            boards.Add(board);
            return CreatedAtAction(nameof(GetBoards), new { id = board.Id }, board);
        }
    }
}
