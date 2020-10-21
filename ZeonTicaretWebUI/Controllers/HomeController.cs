using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ZeonTicaretWebUI.App_Classes;
using ZeonTicaretWebUI.Models;
using static ZeonTicaretWebUI.App_Classes.Sepet;

namespace ZeonTicaretWebUI.Controllers
{
    public class HomeController : Controller
    {
        MvcDB db = new MvcDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Sepet()
        {
            return PartialView();
        }
        public PartialViewResult Slider()
        {
            var data = db.Resim.Where(x => x.Buyukyol.Contains("Slider")).ToList();
            return PartialView(data);
        }
        public PartialViewResult YeniUrunler()
        {
            var urun = db.Urun.ToList();
            return PartialView(urun);
        }
        public PartialViewResult Servisler()
        {
            return PartialView();
        }
     
        public PartialViewResult Markalar()
        {
            var data = db.Marka.ToList();
            return PartialView(data);
        }
       public void SepeteEkleme(int id)
        {
            SepetItem si = new SepetItem();
            Urun urun = db.Urun.FirstOrDefault(x => x.Id == id);
            si.Urun = urun;
            si.Adet = 1;
            si.Indirim = 0;
            Sepet s = new Sepet();
            s.SepeteEkle(si);
            
          
        }
        public PartialViewResult MiniSepetWidget()
        {
            if(HttpContext.Session["AktifSepet"]!=null)
            {
                return PartialView(HttpContext.Session["AktifSepet"]);
            }
            else
            {
                return PartialView();
            }
         
        }
        public void SepetAdetDusurWidget(int id)
        {
            if (HttpContext.Session["AktifSepet"] != null)
            {
                Sepet s = (Sepet)HttpContext.Session["AktifSepet"];
                if (s.Urunler.FirstOrDefault(x => x.Urun.Id == id).Adet > 1)
                {
                    s.Urunler.FirstOrDefault(x => x.Urun.Id == id).Adet--;
                }
                else
                {
                    SepetItem si = s.Urunler.FirstOrDefault(x => x.Urun.Id == id);
                    s.Urunler.Remove(si);

                }
            }
        }
        public ActionResult SepetiGoruntule()
        {
           
            if (HttpContext.Session["AktifSepet"] != null)
            {
                return View(HttpContext.Session["AktifSepet"]);
            }
            else
            {
                return View();
            }
        }
        public ActionResult UrunDetay(string id)
        {
            Urun urun = db.Urun.FirstOrDefault(x => x.Adi == id);
            return View();
        }
    }
}