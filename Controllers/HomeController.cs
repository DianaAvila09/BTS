using BTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTS.Controllers
{
    //bts clase prueba
    public class HomeController : Controller
    {
        EtiquetasCI_EMMEntities sp = new EtiquetasCI_EMMEntities();
        public ActionResult Index(DateTime? inicio = null, int IdLinea = 0)
        {
            DateTime inicio2 = DateTime.Today;

            if (inicio.HasValue)
                inicio2 = Convert.ToDateTime(inicio);

            ViewBag.IdLinea = IdLinea;            
            ViewBag.inicio = inicio2.Month.ToString() + "/" + inicio2.Day.ToString() + "/" + inicio2.Year.ToString();

            var resultado = sp.sp_BTS_CalculaLostSize(inicio2).ToList().Where(a => IdLinea == 0 || a.IdLinea == IdLinea);
            return View(resultado);
        }

        [HttpGet]
        [Route("{IdLinea}")]
        public JsonResult Views(DateTime? inicio = null, int IdLinea = 0)
        {
            DateTime inicio2 = DateTime.Today;

            if (inicio.HasValue)
                inicio2 = Convert.ToDateTime(inicio);

            ViewBag.IdLinea = IdLinea;
            ViewBag.inicio = inicio2.Month.ToString() + "/" + inicio2.Day.ToString() + "/" + inicio2.Year.ToString();

            var respuesta = sp.sp_BTS_CalculaLostSize(inicio2).ToList().Where(a => IdLinea == 0 || a.IdLinea == IdLinea);
            var resultado = Json(respuesta, JsonRequestBehavior.AllowGet);
            return (resultado);
        }

        public ActionResult Datefilter(DateTime inicio, int IdLinea = 0)
        {

            ViewBag.inicio = inicio.Month.ToString() + "/" + inicio.Day.ToString() + "/" + inicio.Year.ToString();            
            ViewBag.IdLinea = IdLinea;

            var resultado = sp.sp_BTS_CalculaLostSize(inicio).ToList().Where(a => IdLinea == 0 || a.IdLinea == IdLinea);
            return View(resultado);
        }

        public ActionResult About()
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