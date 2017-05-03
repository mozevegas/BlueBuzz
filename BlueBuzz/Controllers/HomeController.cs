using BlueBuzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBuzz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var eventsFromCache = HttpRuntime.Cache["events"] as IEnumerable<Events> ;  // Added the Casting
            if (eventsFromCache == null)
            {
                var events = new ApplicationDbContext().Events.OrderBy(o => o.Title).ToList();
                // or should use Events.Include(i => i.Genre).Include(i => i.Venue).ToList();
                // add the menu to cache
                HttpRuntime.Cache.Add(
                    "events",
                    events,
                    null,
                    DateTime.Now.AddDays(7),
                    new TimeSpan(),
                    System.Web.Caching.CacheItemPriority.High,
                    null);
                eventsFromCache = HttpRuntime.Cache["events"] as IEnumerable<Events>;

            }
            return View(eventsFromCache);
        }

        [Authorize]
        public ActionResult Owner ()
        {
            return View();
        }


        public ActionResult Create()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}