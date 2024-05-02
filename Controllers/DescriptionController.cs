using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trello.Models;
using trello.Repository;
using trello.Repository.IRepository;

namespace trello.Controllers
{
    [Route("api/description")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionrepo _descriptionrepo;
        public DescriptionController(IDescriptionrepo descriptionrepo)
        {
            _descriptionrepo = descriptionrepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var descriptions = await _descriptionrepo.GetDescription();
            return Ok(descriptions);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDescription( NewDescription Description)
        {
            if (Description == null) return NotFound();
            if (!ModelState.IsValid) return BadRequest(Description);
            await _descriptionrepo.CreateDescription(Description);
            await _descriptionrepo.save();
            return Ok(Description);
        }
        [HttpGet]
        [Route("descriptions")]
        public async Task<IActionResult> GetDescriptionBycardId(int id)
       {
            var descriptions = await _descriptionrepo.GetDescriptionBycardId(id);

            if (descriptions == null || !descriptions.Any())
            {
                return NotFound("No lists found for the specified Card ID");
            }

            return Ok(descriptions);
        }
    }
}
                                                     