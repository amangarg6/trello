using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trello.Models;
using trello.Repository;
using trello.Repository.IRepository;

namespace trello.Controllers
{
    [Route("api/open")]
    [ApiController]
    public class OpenController : ControllerBase
    {
        private readonly IOpenrepo _open;
        public OpenController(IOpenrepo open)
        {
            _open = open;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var opens = await _open.GetOpen();
            return Ok(opens);
        }

        //[HttpGet("{OpenId:int}")]
        //public async Task<IActionResult> GetOpen(int OpenId)
        //{
        //    var open = await _open.GetOpen(OpenId);
        //    if (open == null) return NotFound();
        //    return Ok(open);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateOpen([FromForm] Open open)
        {
            if (open == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(open);
            await _open.CreateOpen(open);
            await _open.save();
            return Ok(open);
        }
        [HttpGet]
        [Route("open")]
        public async Task<IActionResult> GetOpenByCardId(int id)
        {
            var opens = await _open.GetOpenByCardId(id);

            if (opens == null || !opens.Any())
            {
                return NotFound("No lists found for the specified Board ID");
            }

            return Ok(opens);
        }
    }
}
