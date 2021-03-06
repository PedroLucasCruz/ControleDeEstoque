﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControleEstoque
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        //Tratamento de erro 200 retornado do servidor 
        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex is HttpRequestValidationException)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.ContentType = "application/json";
                Response.Write("{ \"Mensagens\":[\"Somente textos sem caracteres especiais podem ser enviados.\"],\"Obj\":\"\"}");
                Response.End();
            }
            else if(ex is HttpAntiForgeryException)
            {
                Response.Clear();
                Response.StatusCode = 200;             
                Response.End();
                //Log no banco pode ser inputado aqui para auditoria de sistema de segurança
            }
        }
    }
}
