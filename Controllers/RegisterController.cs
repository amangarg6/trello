using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trello.Models;
using trello.Models.View_Models;
using trello.Repository.IRepository;

namespace trello.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepo _registerRepo;
        public RegisterController(IRegisterRepo registerRepo)
        {
            _registerRepo = registerRepo;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register userdetails)
        {
            if (ModelState.IsValid)
            {
                var isuniqueuser = _registerRepo.IsUniqueUser(userdetails.UserName);
                if (!isuniqueuser) return BadRequest("user in use !!");
                var userinfo = _registerRepo.Register(userdetails);
                if (userinfo == null) return BadRequest();
            }
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] LoginVM userVM)
        {
            if ( _registerRepo.IsUniqueUser(userVM.UserName)) return BadRequest("Please Register");
            var userAuthorize = _registerRepo.Authenticate(userVM.UserName, userVM.Password);
            if (userAuthorize == null) return NotFound("Invalid Attempt");
            return Ok(userAuthorize);
        }
        
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _registerRepo.GetUser();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _registerRepo.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
