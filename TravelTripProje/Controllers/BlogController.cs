using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;
namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(b => b.ID).Take(3).ToList();
            //var bloglar = c.Blogs.ToList();
            return View(by);
        }
        
        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
           // var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
           by.Deger2 = c.Yorumlars.Where(x => x.BlogID==id).ToList();
            return View(by);
        }
        
    }
}