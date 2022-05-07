using Autos.Datos;
using Autos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autos.Controllers
{
    public class AutoController : Controller
    {
        readonly AutosAdmin autos=new AutosAdmin();
        // GET: Auto
        public ActionResult Index()
        {
            IEnumerable<AutoModel> list = autos.Consultar();
            return View(list);
        }
        public ActionResult Guardar()
        {
            return View();
        }

        public ActionResult Nuevo(AutoModel model)
        {
            autos.Guardar(model);
            return View("Guardar",model);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}