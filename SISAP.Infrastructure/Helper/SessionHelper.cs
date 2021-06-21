using System;
using System.Web;

namespace SISAP.Infrastructure.Helper
{
    public static class SessionHelper
    {
        public static T Get<T>(string index)
        {
            if (HttpContext.Current.Session == null)
            {
                var i = HttpContext.Current.Session.Count - 1;
                while (i >= 0)
                {
                    try
                    {
                        var obj = HttpContext.Current.Session[i];
                        if (obj != null && obj.GetType().ToString() == "Microsoft.Reporting.WebForms.ReportHierarchy")
                            HttpContext.Current.Session.RemoveAt(i);
                    }
                    catch (Exception)
                    {
                        HttpContext.Current.Session.RemoveAt(i);
                    }
                    i--;
                }
                return default(T);
            }
            try
            {
                if (HttpContext.Current.Session.Keys.Count > 0 && !HttpContext.Current.Session.Keys.Equals(index))
                {
                    return (T)HttpContext.Current.Session[index];
                }
                else
                {
                    var i = HttpContext.Current.Session.Count - 1;
                    while (i >= 0)
                    {
                        try
                        {
                            var obj = HttpContext.Current.Session[i];
                            if (obj != null && obj.GetType().ToString() == "Microsoft.Reporting.WebForms.ReportHierarchy")
                                HttpContext.Current.Session.RemoveAt(i);
                        }
                        catch (Exception)
                        {
                            HttpContext.Current.Session.RemoveAt(i);
                        }

                        i--;
                    }
                    return default(T);
                }
            }
            catch (Exception e)
            {
                var i = HttpContext.Current.Session.Count - 1;

                while (i >= 0)
                {
                    try
                    {
                        var obj = HttpContext.Current.Session[i];
                        if (obj != null && obj.GetType().ToString() == "Microsoft.Reporting.WebForms.ReportHierarchy")
                            HttpContext.Current.Session.RemoveAt(i);
                    }
                    catch (Exception)
                    {
                        HttpContext.Current.Session.RemoveAt(i);
                    }

                    i--;
                }
                return default(T);
            }
        }
        public static void Set<T>(string index, T value)
        {
            HttpContext.Current.Session[index] = (T)value;
        }
    }
}
