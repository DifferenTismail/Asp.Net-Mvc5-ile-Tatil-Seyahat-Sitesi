using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models;
using TravelTripProje.Models.Siniflar;
namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BlogGuncelle(int id)
        {
            var deger = c.Blogs.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog blog)
        {
            var deger = c.Blogs.Find(blog.ID);
            deger.Baslik = blog.Baslik;
            deger.Tarih = blog.Tarih;
            deger.Aciklama = blog.Aciklama;
            deger.BlogImage = blog.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var value = c.Blogs.Find(id);
            c.Blogs.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var value = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(value);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [HttpGet]
        public ActionResult YorumGuncelle(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var deger = c.Yorumlars.Find(yorumlar.ID);
            deger.Yorum = yorumlar.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}