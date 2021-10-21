using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AcuSharp.Util
{
    public static class UrlBuilderExtensions
    {
        public static StringBuilder AppendUrlQuery(this StringBuilder sb, string name, string value)
        {
            sb.Append("&");
            sb.Append(HttpUtility.UrlEncode(name));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(value));
            
            return sb;
        }
    }
}
