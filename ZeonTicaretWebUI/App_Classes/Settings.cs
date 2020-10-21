using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ZeonTicaretWebUI.App_Classes
{
    public class Settings
    {
        public static Size UrunOrtaBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["UrunOrtaWidht"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["UrunOrtaHeight"]);
                return sz;
            }
        }
        public static Size UrunKucukBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["UrunKucukWidht"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["UrunKucukHeight"]);
                return sz;
            }
        }
        public static Size UrunBuyukBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["UrunBuyukWidht"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["UrunBuyukHeight"]);
                return sz;
            }
        }
        public static Size SliderBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["SliderWidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["SliderHeight"]);
                return sz;
            }
        }
    }
}