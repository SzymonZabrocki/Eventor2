using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eventor2.Models;
using Microsoft.AspNet.Identity;



namespace Eventor2.Controllers
{
    [Authorize]
    public class TicketModelsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        
        [Authorize]
        public ActionResult BuyTicket()
        {
            GetLoggedUserMail();
            return View();
        }
        
        private string GetLoggedUserMail()
        {
            string userId = User.Identity.GetUserId();
            var userEmail = db.Users.First(x => x.Id == userId).Email;
            Session["LoggedInEmail"] = userEmail;
            return userEmail;
        }


        [HttpPost]

        public ActionResult ReserveBasicTicket([Bind(Include = "Count")] TicketNumberModels helperTicket)
        {
            return ReserveTickets(helperTicket.Count, "Basic");
        }

        [HttpPost]

        public ActionResult ReserveProTicket([Bind(Include = "Count")] TicketNumberModels helperTicket)
        {
            return ReserveTickets(helperTicket.Count, "Pro");
        }

        [HttpPost]

        public ActionResult ReserveVipTicket([Bind(Include = "Count")] TicketNumberModels helperTicket)
        {
            return ReserveTickets(helperTicket.Count, "Vip");
        }

        private int GetNumberOfUserTickets()
        {
            return db.TicketModels.Where(x => x.UserEmail == GetLoggedUserMail()).Count();
        }

        private ActionResult ReserveTickets(int amount, string ticketType)
        {
            if (amount < 1)
            {
                ModelState.AddModelError("ValueError"+ticketType, "Podaj liczbę naturalną");
            }
            else
            {
                if (amount > db.TicketModels.Where(x => x.Type == ticketType && x.UserEmail == null).Count())
                {
                    ModelState.AddModelError("CountError" + ticketType, "Nie ma już tylu miejsc");
                }
                else
                {
                    for (int i = 0; i < amount; i++)
                    {
                        var ticket = db.TicketModels.First(x => x.Type == ticketType && x.UserEmail == null);
                        ticket.UserEmail = GetLoggedUserMail();
                        db.Entry(ticket).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            return View("BuyTicket");
        }
        
        // GET: TicketModels
        public ActionResult Index()
        {
            GetLoggedUserMail();
            return View(db.TicketModels.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
