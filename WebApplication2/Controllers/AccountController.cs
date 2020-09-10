using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using WebApplication2.Classes;
using Microsoft.AspNetCore.Authorization;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult RegisterUser([FromBody]string logpas)
        {
            var passwrods = logpas.Split(';');
            var user = new User();
            user.LoginUser = passwrods[0];
            user.PasswordUser = passwrods[1];
            user.NameUser = passwrods[2];
            user.Surname = passwrods[3];
            user.RoleUser = 1;
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordUser));
            var hashedpass = new StringBuilder();
            var dbo = new OnlineEventsContext();
            foreach (var byt in hash)
            {
                hashedpass.Append(byt.ToString("X2"));
            }
            user.PasswordUser = hashedpass.ToString();
            dbo.User.Update(user);//если user.id==0 То запись добавится в бд если нет то изменится
            dbo.SaveChanges();
            return Ok();
        }
        [Authorize]
        public IActionResult Check()
        {
            var DBO = new OnlineEventsContext();
            if (!string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                if(DBO.User.Where(c=>c.LoginUser==User.Identity.Name).FirstOrDefault().RoleUser==3)
                {
                    return Ok("Admin");
                }else
                return Ok(User.Identity.Name);
            }
            else {
                return BadRequest();
            }
        }
    [Authorize]
    public IActionResult GetEvents()
    {
            var dbo = new OnlineEventsContext();

        if (!string.IsNullOrWhiteSpace(User.Identity.Name))
        {
                var events = dbo.EventUsers.Where(c => c.IdUser == dbo.User.Where(j => j.LoginUser == User.Identity.Name).First().IdUser).Select(c=>c.IdEventNavigation).ToList();
            return Ok(events);
        }
        else
        {
            return BadRequest();
        }
    }
    [Authorize]
        public IActionResult GetFio()
        {

            if (!string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                var DBO = new OnlineEventsContext();
                var user = DBO.User.Where(c => c.LoginUser == User.Identity.Name).FirstOrDefault();
                user.PasswordUser = "";
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Login([FromBody]string logpas)
        {
            var logpasParse = logpas.Split(';');
            var sha256 = SHA256.Create();
            var Token = new TokenClass();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(logpasParse[1]));
            var dbo = new OnlineEventsContext();
            var hashedpass = new StringBuilder();
            foreach (var byt in hash)
            {
                hashedpass.Append(byt.ToString("X2"));
            }
            logpasParse[1] = hashedpass.ToString();
            
            if (dbo.User.Where(c => c.LoginUser == logpasParse[0] && c.PasswordUser == logpasParse[1]).Count() > 0)
            {
                return Ok(Token.Token(logpasParse[0], logpasParse[1]));
            }
            else
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
        }
    }
}