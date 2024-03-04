using System.Web;
using System.Web.Mvc;

namespace Week18_Lezione1_Esercitazione
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
