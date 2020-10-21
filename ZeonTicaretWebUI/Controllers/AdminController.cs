using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZeonTicaretWebUI.App_Classes;
using ZeonTicaretWebUI.Models;

namespace ZeonTicaretWebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        MvcDB db = new MvcDB();
        public ActionResult Urunler()
        {
            return View(db.Urun.ToList());
        }
        public ActionResult UrunEkle()
        {
            ViewBag.Kategoriler = db.Kategori.ToList();
            ViewBag.Markalar = db.Marka.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            
            db.Urun.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }
        public ActionResult Markalar()
        {
            return View(db.Marka.ToList());
        }
        public ActionResult MarkaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MarkaEkle(Marka marka,HttpPostedFileBase fileUpload)
        {
            int resimId = -1;
            
            if(fileUpload!=null)
            {
                Image image = Image.FromStream(fileUpload.InputStream);
                int width =Convert.ToInt32(ConfigurationManager.AppSettings["MarkaWidht"].ToString());
                int height= Convert.ToInt32(ConfigurationManager.AppSettings["MarkaHeight"].ToString());
                string name = "/Content/MarkaResim/"+Guid.NewGuid()+Path.GetExtension(fileUpload.FileName);
                Bitmap bm = new Bitmap(image,width,height);
                bm.Save(Server.MapPath(name));
                Resim rsm = new Resim();
                rsm.Ortayol = name;
                db.Resim.Add(rsm);
                db.SaveChanges();
                if(rsm.Id != 0)
                    resimId = rsm.Id;
                
            }
            if(resimId!=-1)
             marka.ResimId = resimId;
            db.Marka.Add(marka);
            db.SaveChanges();
            return RedirectToAction("Markalar");
        }
        public ActionResult Kategoriler()
        {
            return View(db.Kategori.ToList());
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            db.Kategori.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }
        public ActionResult OzellikTipleri()
        {

            return View(db.OzellikTip.ToList());
        }

        public ActionResult OzellikTipiEkle()
        {
            ViewBag.Kategoriler = db.Kategori.ToList();
            return View(db.OzellikTip.ToList());
            
        }
        [HttpPost]
        public ActionResult OzellikTipiEkle(OzellikTip ozelliktipi)
        {
            db.OzellikTip.Add(ozelliktipi);
            db.SaveChanges();
            return RedirectToAction("OzellikTipleri");
        }
        public ActionResult OzellikDegerleri()
        {
            return View(db.OzellikDegeri.ToList());
            
        }
        public ActionResult OzellikDegeriEkle()
        {
            ViewBag.OzellikTipi = db.OzellikTip.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult OzellikDegeriEkle(OzellikDegeri ozellikdegeri)
        {
            db.OzellikDegeri.Add(ozellikdegeri);
            db.SaveChanges();
            return RedirectToAction("OzellikDegerleri");
        }
        public ActionResult UrunOzellikleri()
        {
            return View(db.UrunOzellikleri.ToList());
        }
        public ActionResult UrunOzellikSil(int urunId,int tipId,int degerId)
        {
            UrunOzellikleri oz=db.UrunOzellikleri.FirstOrDefault(x => x.UrunId == urunId && x.OzellikTip.Id == tipId && x.OzellikDegeri.Id == degerId);
            db.UrunOzellikleri.Remove(oz);
            db.SaveChanges();
            return RedirectToAction("UrunOzellikleri");
        }
        public ActionResult UrunOzelligiEkle()
        {
           
            return View(db.Urun.ToList());
        }
        public PartialViewResult UrunOzellikTipWidget(int? katId)
        {
            if(katId!=null)
            {
                return PartialView(db.OzellikTip.Where(x => x.KategoriId == katId).ToList());

            }
            else
            {
                return PartialView(db.OzellikTip.ToList());
            }
     
        }
        public PartialViewResult UrunOzellikDegerWidget(int? tipId)
        {
            if (tipId != null)
            {
                return PartialView(db.OzellikDegeri.Where(x => x.OzellikTip.Id ==tipId).ToList());

            }
            else
            {
                return PartialView(db.OzellikDegeri.ToList());
            }
        }
        [HttpPost]
        public ActionResult UrunOzellikEkle(UrunOzellikleri ozellik)
        {
            db.UrunOzellikleri.Add(ozellik);
            db.SaveChanges();
            return RedirectToAction("UrunOzellikleri");
        }
        public ActionResult UrunResimEkle(int id)
        {
           
            return View(id);
        }
        [HttpPost]
        public ActionResult UrunResimEkle(int Uid,HttpPostedFileBase fileUpload)
        {
            if(fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                Bitmap ortaresim = new Bitmap(img,Settings.UrunOrtaBoyut);
                Bitmap buyukresim = new Bitmap(img, Settings.UrunBuyukBoyut);
               // Bitmap kucukresim = new Bitmap(img, Settings.UrunKucukBoyut);
                string ortaYol = "/Content/UrunResim/Orta/" + Guid.NewGuid()+Path.GetExtension(fileUpload.FileName);
                string buyukYol = "/Content/UrunResim/Buyuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                //string kucukYol = "/Content/UrunResim/Kucuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                ortaresim.Save(Server.MapPath(ortaYol));
                buyukresim.Save(Server.MapPath(buyukYol));
               // kucukresim.Save(Server.MapPath(kucukYol));


                Resim resim = new Resim();
                resim.Buyukyol = buyukYol;
                resim.Ortayol = ortaYol;
                //resim.Kucukyol = kucukYol;
                resim.UrunId = Uid;
                if(db.Resim.FirstOrDefault(x=>x.UrunId==Uid && x.Varsayilan==false)!=null)
                {
                    resim.Varsayilan = true;
                }
                else
                {
                    resim.Varsayilan = false;
                }
                db.Resim.Add(resim);
                db.SaveChanges();
                return View(Uid);
          
            }
            return View(Uid);
        }

        public ActionResult SliderResimleri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SliderResimEkle(HttpPostedFileBase fileUpload)
        {
            if(fileUpload!=null)
            {
                Image image = Image.FromStream(fileUpload.InputStream);
                Bitmap bt = new Bitmap(image,Settings.SliderBoyut);
                string resimyol = "/Content/SliderResim/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                bt.Save(Server.MapPath(resimyol));
                Resim rsm = new Resim();
                rsm.Buyukyol = resimyol;
                db.Resim.Add(rsm);
                db.SaveChanges();
            }
            return RedirectToAction("SliderResimleri");
        }
    }
}