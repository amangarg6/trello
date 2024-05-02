using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trello.Data;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Repository
{
    public class RegisterRepo:IRegisterRepo
    {
        private readonly ApplicationDbcontext _context;
        private readonly AppSettings _appSettings;

        public RegisterRepo(ApplicationDbcontext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;

        }

        public Register Authenticate(string username, string password)
        {
            var userInDb = _context.registers.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (userInDb == null) return null;
            // Create a JSON Web Token (JWT) for the authenticated user.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userInDb.Id.ToString())               
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userInDb.Token = tokenHandler.WriteToken(token);
            // Clear the password for security.
            userInDb.Password = "";
            return userInDb;
        }

        public ICollection<Register> GetUser()
        {
            return _context.registers.ToList();
        }

        public Register GetUser(int userid)
        {
            return _context.registers.Find(userid);
        }

        public bool IsUniqueUser(string username)
        {
            var userInDb = _context.registers.FirstOrDefault(u => u.UserName == username);
            if (userInDb == null) return true;
            return false;
        }

        public Register Register(Register userDetail)
        {
            // Set the user's role, typically 'user.'
            //userDetail.Role = "user";
            _context.registers.Add(userDetail);
            _context.SaveChanges();
            return userDetail;
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}
