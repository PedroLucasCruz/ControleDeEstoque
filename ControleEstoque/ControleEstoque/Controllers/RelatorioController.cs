using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PosicaoEstoque()
        {
            return View();
        }

        public ActionResult Ressuprimento()
        {
            return View();
        }
    }
}