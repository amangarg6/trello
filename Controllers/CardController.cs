using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trello.Models;
using trello.Repository;
using trello.Repository.IRepository;

namespace trello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardrepo _cardrepo;
        public CardController(ICardrepo cardrepo)
        {
            _cardrepo = cardrepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boards = await _cardrepo.GetCard();
            return Ok(boards);
        }

        [HttpGet("{boardid:int}")]
        public async Task<IActionResult> GetCard(int boardid)
        {
            var board = await _cardrepo.GetCard(boardid);
            if (board == null) return NotFound();
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromForm] Card Card)
        {
            if (Card == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(Card);
            await _cardrepo.CreateCard(Card);
            await _cardrepo.save();
            return Ok(Card);//200 ok response
        }

        [HttpGet]
        [Route("card")]
        public async Task<IActionResult> GetCardsByListId(int id)
        {
            var cards = await _cardrepo.GetCardByListId(id);

            if (cards == null || !cards.Any())
            {
                return NotFound("No lists found for the specified Board ID");
            }
            return Ok(cards);
        }

        [HttpPut("{cardId}/moveto/{listId}")]
        public async Task<IActionResult> MoveCardToList(int cardId, int listId)
        {
            try
            {               
                await _cardrepo.MoveCardToList(cardId, listId);
                return Ok(new { Message = "Card moved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error moving card: {ex.Message}" });
            }
        }
    }
}
