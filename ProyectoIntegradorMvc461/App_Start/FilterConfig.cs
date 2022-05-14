using System.Web;
using System.Web.Mvc;

namespace ProyectoIntegradorMvc461
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Aqui le damos de alta al Filtro, para que siempre vaya a Login
            filters.Add(new Filters.VerificaSession());
        }
    }
}
