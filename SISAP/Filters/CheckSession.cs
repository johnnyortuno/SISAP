using SISAP.Controllers;
using SISAP.Core.Entities;
using SISAP.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISAP.Filters
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                var usuario = SessionHelper.Get<int?>("UsuarioId");
                if(usuario == null)
                {
                    if(filterContext.Controller is LoginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Login/Login");
                    }
                }
                else
                {
                    if(filterContext.Controller is LoginController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Inicio/Inicio");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }
        }
    }
}