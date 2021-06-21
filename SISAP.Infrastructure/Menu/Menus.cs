using SISAP.Infrastructure.Helper;
using SISAP.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISAP.Infrastructure.Menu
{
    public class Menus
    {
        public static string CargarMenu()
        {
            var UsuarioId = SessionHelper.Get<int?>("UsuarioId");
            if (UsuarioId == null) return "";
            var listaOpciones = new OpcionService().ListarOpciones();
            var listaGrupos = listaOpciones.Where(m => m.ParentId == null).ToList();


            StringBuilder html = new StringBuilder();
            html.AppendLine("<ul class='navbar-nav align-self-stretch'>");
            foreach(var item in listaGrupos.OrderBy(p => p.Orden))
            {
                var subMenus = listaOpciones.Where(m => m.ParentId == item.OpcionId).ToList();
                if (subMenus.Count() > 0)
                {
                    html.AppendLine("<li class='nav-item dropdown'>");
                    html.AppendLine("<a class='nav-link dropdown-toggle' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>");
                    var ico = item.Icono == null ? "glyphicon glyphicon-folder-close" : item.Icono;
                    html.AppendLine("<span class='" + ico + "'></span> " + item.Etiqueta + "<b class='caret'></b></a>");

                    html.AppendLine("<div class='dropdown-menu' aria-labelledby='navbarDropdown'>");
                    foreach (var sub in subMenus.OrderBy(p => p.Orden))
                    {
                        html.AppendLine(string.Format("<a href='{0}' class='dropdown-item' name='{0}'><i class='{2}'></i>{1}</a>", Util.GetUrl(sub.Url), sub.Etiqueta, sub.Icono == null ? "fas fa-address-card  mr-2" : sub.Icono));
    }
                    html.AppendLine("</div>");
                    html.AppendLine("<li/>");
                }
                else
                {
                    html.AppendLine("<li class='nav-item'>");
                    if (item.Url != null)
                        html.AppendLine(string.Format("<a href='{0}' class='{1}'>{2}</a>", Util.GetUrl(item.Url), "nav-link", item.Etiqueta));
                    else
                        html.AppendLine(string.Format("<a href='#' class='hide-links'><i class='{0}'></i><span>{1}</span> <span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span> </a> ", "fa fa-sitemap", item.Etiqueta));
                    html.AppendLine("</li>");
                }
            }
            html.AppendLine("</ul>");
            return html.ToString();
        }
    }
}
