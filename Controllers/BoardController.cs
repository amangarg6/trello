using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Controllers
{
    [Route("api/board")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardrepo _boardrepo;
        public BoardController(IBoardrepo boardrepo)
        {
            _boardrepo = boardrepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boards = await _boardrepo.GetBoard();
            return Ok(boards);
        }
        [HttpGet("{boardId:int}")]
        public async Task<IActionResult> GetBoard(int boardId)
        {
            var board = await _boardrepo.GetBoard(boardId);
            if (board == null) return NotFound();
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromForm]Board board )
        {
            if (board == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(board);
            await _boardrepo.CreateBoard(board);
            await _boardrepo.save();
            return Ok(board);
        }
        [HttpGet("details/{boardId}")]
        public async Task<IActionResult> GetBoardDetailsById(string boardId)
        {
            try
            {
                var boardDetails = await _boardrepo.GetBoardDetailsByIdAsync(boardId);

                if (boardDetails == null)
                {
                    return NotFound(); // or handle as needed
                }

                return Ok(boardDetails);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBoard([FromForm] Board board)
        {
            if (board == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(board);
            await _boardrepo.UpdateBoard(board);
            await _boardrepo.save();
            return Ok(board);
        }

        [HttpDelete("{boardid:int}")]
        public async Task<IActionResult> DeleteBoard(int boardid)
        {
            if (!await _boardrepo.GetBoardExists(boardid)) return NotFound();
            var board = await _boardrepo.GetBoard(boardid);
            if (board == null) return NotFound();
            if (!await _boardrepo.DeleteBoard(board))
            {
                ModelState.AddModelError("", $"something went wrong while Delete Employee:{board.Title}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(new { Status = "Success", Message = "Employee Delete successfully!" });
        }

    }
}
