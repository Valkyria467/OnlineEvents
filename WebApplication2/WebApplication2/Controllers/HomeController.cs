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
            return Ok(DBO.Event.ToList());
        }
    }
}