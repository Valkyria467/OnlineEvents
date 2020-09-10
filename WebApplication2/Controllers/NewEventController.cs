using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class NewEventController : Controller
    {
        [Authorize]
        public IActionResult InputEv([FromBody] newEvent EventNew)
        {
            var DBO = new OnlineEventsContext();
            var Event = new Event();
            var leaderFio = EventNew.Leader.Split(" ");
            var photoFio = EventNew.Photo.Split(" ");
            var decorFio = EventNew.Decor.Split(" ");
            var userid = DBO.User.Where(c => c.LoginUser == User.Identity.Name).FirstOrDefault() ;

            Event.OrganizerNavigation = userid;

            if (!string.IsNullOrEmpty(EventNew.NameEvent))
                Event.NameEvent = EventNew.NameEvent;
            else
                Event.NameEvent = "Без названия";
            if (DBO.TypeEvent.Count() > 0 && !string.IsNullOrEmpty(EventNew.typeEvent))
                Event.TypeEvent = DBO.TypeEvent.Where(c => c.NameType == EventNew.typeEvent).FirstOrDefault()?.IdType ?? 0;
            if (!string.IsNullOrEmpty(EventNew.Amount))
                Event.Amount = Convert.ToInt32(EventNew.Amount);
            else
            {
                Event.Amount = 0;
            }
            if (DBO.Place.Where(c => c.NamePlace == EventNew.NamePlace).Count() > 0)
                Event.Place = DBO.Place.Where(c => c.NamePlace == EventNew.NamePlace).FirstOrDefault().IdPlace;
            else
            {
                var place = new Place();
                place.NamePlace = EventNew.NamePlace;
                DBO.Place.Add(place);
                DBO.SaveChanges();
                Event.Place = place.IdPlace;
            }

            if (!string.IsNullOrEmpty(EventNew.NameCity))
                Event.City = EventNew.NameCity;
            else
                Event.City = "Город не указан";
            if (!string.IsNullOrEmpty(EventNew.NameStreet))
                Event.Sreet = EventNew.NameStreet;
            else
                Event.Sreet = "Улица не указана";
            if (!string.IsNullOrEmpty(EventNew.NumHouse))
                Event.House = EventNew.NumHouse;
            else
                Event.House = "Дом не указан";

            if (EventNew.date!=null)
                Event.DateEvent = EventNew.date.DateTime;

            if (!string.IsNullOrEmpty(EventNew.Cost))
                Event.Cost = Convert.ToDecimal(EventNew.Cost);
            else
                Event.Cost = 0;
            if (DBO.Leader.Count() > 0 && !string.IsNullOrEmpty(EventNew.Leader))
                Event.Leader = DBO.Leader.Where(c => c.NameLeader == leaderFio[0] && c.SurnameLeader == leaderFio[1]).FirstOrDefault()?.IdLeader ?? 0;
            if (DBO.Photo.Count() > 0 && !string.IsNullOrEmpty(EventNew.Photo))
                Event.Photo = DBO.Photo.Where(c => c.NamePhoto == photoFio[0] && c.SurnamePhoto == photoFio[1]).FirstOrDefault()?.IdPhoto ?? 0;
            if (DBO.Decor.Count() > 0 && !string.IsNullOrEmpty(EventNew.Decor))
                Event.Decor = DBO.Decor.Where(c => c.NameDecor == decorFio[0] && c.SurnameDecor == decorFio[1]).FirstOrDefault()?.IdDecor ?? 0;
            Event.InfoEvent = EventNew.InfoEvent;
            Event.Access = false;
            DBO.Event.Add(Event);
            DBO.SaveChanges();
            return Ok();
        }
    }
    public class newEvent
    {
        public string NameEvent { get; set; }
        public string typeEvent { get; set; }
        public string Amount { get; set; }
        public string NamePlace { get; set; }
        public string NameCity { get; set; }
        public string NameStreet { get; set; }
        public string NumHouse { get; set; }
        public string Cost { get; set; }
        public string Leader { get; set; }
        public string Photo { get; set; }
        public string Decor { get; set; }
        public string InfoEvent { get; set; }
        public DateTimeOffset date { get; set; }


    }
}