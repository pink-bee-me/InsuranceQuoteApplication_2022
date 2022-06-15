using System.Web;
using System.Web.Mvc;

namespace InsuranceQuoteApplication_2022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
