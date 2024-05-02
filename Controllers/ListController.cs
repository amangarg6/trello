using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trello.Models;
using trello.Repository;
using trello.Repository.IRepository;

namespace trello.Controllers
{
    [Route("api/list")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListrepo _listrepo;
        public ListController(IListrepo listrepo)
        {
            _listrepo = listrepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boards = await _listrepo.GetList();
            return Ok(boards);
        }
        [HttpGet("{boardId:int}")]
        public async Task<IActionResult> GetList(int boardId)
        {
            var board = await _listrepo.GetList(boardId);
            if (board == null) return NotFound();
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromForm] List list)
        {
            if (list == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(list);
            await _listrepo.CreateList(list);
            await _listrepo.save();
            return Ok(list);
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetListsByBoardId(int id)
        {
            var lists = await _listrepo.GetListByBoardId(id);

            if (lists == null || !lists.Any())
            {
                return NotFound("No lists found for the specified Board ID");
            }

            return Ok(lists);
        }
    }
}
