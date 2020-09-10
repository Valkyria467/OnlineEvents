using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult GetEvent()
        {
            var DBO = new OnlineEventsContext();
            var result = DBO.Event.Where(c => c.DateEvent > DateTime.Now).Where(c => c.Access == true).ToList();
            return Ok(result);
        }
        public IActionResult GetNAEvent()
        {
            var DBO = new OnlineEventsContext();
            var result = DBO.Event.Where(c => c.DateEvent > DateTime.Now).Where(c => c.Access == false).ToList();
            return Ok(result);
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult OnEvents([FromBody] string id)
        {
            var DBO = new OnlineEventsContext();
            var user = DBO.User.Where(c => c.LoginUser == User.Identity.Name).FirstOrDefault();

            if (DBO.EventUsers.Where(c => c.IdEvent == Convert.ToInt32(id)).Count() != DBO.Event.Where(c => c.IdEvent == Convert.ToInt32(id)).FirstOrDefault().Amount)
            {
                if (DBO.EventUsers.Where(c => c.IdEvent == Convert.ToInt32(id)).Where(c => c.IdUser == user.IdUser).Count() == 0)
                {
                    var eu = new EventUsers();
                    eu.IdEvent = Convert.ToInt32(id);
                    eu.IdUser = DBO.User.Where(c => c.LoginUser == User.Identity.Name).FirstOrDefault().IdUser;
                    DBO.EventUsers.Add(eu);
                    DBO.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult OnRemoveEvents([FromBody] string id)
        {
            var DBO = new OnlineEventsContext();
            var user = DBO.User.Where(c => c.LoginUser == User.Identity.Name).FirstOrDefault();
            var events = DBO.EventUsers.Where(c => c.IdEvent == Convert.ToInt32(id) && c.IdUser == user.IdUser).FirstOrDefault();
            DBO.EventUsers.Remove(events);
            DBO.SaveChanges();
            var list = DBO.EventUsers.Where(c => c.IdEvent == Convert.ToInt32(id) && c.IdUser == user.IdUser).ToList();
            return Ok(list);
        }
        public IActionResult AcceptEvent([FromBody]string id)
        {
            var DBO = new OnlineEventsContext();
            var Event = DBO.Event.Where(c => c.IdEvent == Convert.ToInt32(id)).FirstOrDefault();
            if (Event != null)
                Event.Access = true;
            else
                return BadRequest();
            DBO.SaveChanges();
            var result = DBO.Event.Where(c => c.DateEvent > DateTime.Now).Where(c => c.Access == true).ToList();
            return Ok(result);
        }
        public IActionResult DeclineEvent([FromBody]string id)
        {
            var DBO = new OnlineEventsContext();
            var events=DBO.Event.Where(c=>c.IdEvent== Convert.ToInt32(id)).FirstOrDefault();
            DBO.Event.Remove(events);
            DBO.SaveChanges();
            var result = DBO.Event.Where(c => c.DateEvent > DateTime.Now).Where(c => c.Access == false).ToList();
            return Ok(result);
        }
        public IActionResult GetPlaces()
        {
            var DBO = new OnlineEventsContext();
            return Ok(DBO.Place.ToList());
        }
        public IActionResult GetType()
        {
            var DBO = new OnlineEventsContext();
            return Ok(DBO.TypeEvent.ToList());
        }
        public IActionResult GetLeader()
        {
            var DBO = new OnlineEventsContext();
            return Ok(DBO.Leader.ToList());
        }
        public IActionResult GetPhoto()
        {
            var DBO = new OnlineEventsContext();
            return Ok(DBO.Photo.ToList());
        }
        public IActionResult GetDecor()
        {
            var DBO = new OnlineEventsContext();
            return Ok(DBO.Decor.ToList());
        }
        public IActionResult GetEventFromID([FromBody] int id)
        {
            var DBO = new OnlineEventsContext();
            return Ok(DBO.Event.Where(c => c.IdEvent == id).ToList());
        }
    }
}