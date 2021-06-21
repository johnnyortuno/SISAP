using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SISAP.Infrastructure.Menu
{
    public  class Util
    {
        public static string GetUrl(string url)
        {
            return VirtualPathUtility.ToAbsolute(url);
        }
    }
}
