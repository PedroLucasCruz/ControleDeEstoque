using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class GraficoController : Controller
    {
        // GET: Grafico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PerdaMes()
        {
            return View();
        }

        public ActionResult EntradaSaidasMes()
        {
            return View();
        }
    }
}