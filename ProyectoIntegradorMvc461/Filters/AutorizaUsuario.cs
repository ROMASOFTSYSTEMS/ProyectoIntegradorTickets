using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
// Usings
using System.Web.Mvc;
using ProyectoIntegradorMvc461.Models;

namespace ProyectoIntegradorMvc461.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AutorizaUsuario:AuthorizeAttribute
    {
        Perfil_OpcionModel model;
        private Usuario oUsuario;
        //private _Database 
        private int IdOperacion;
        public AutorizaUsuario(int IdOperacion=0)
        {
            
            this.IdOperacion = IdOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.model = new Perfil_OpcionModel();

            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                oUsuario = (Usuario)HttpContext.Current.Session["User"];
                var xx = PerfilOpcion(1, 2);
                Task<Perfil_Opcion> Obj = PerfilOpcion(1, 2);

                //Perfil_Opcion Obj = (Perfil_Opcion)xx;      // model.GetPerfil_OpcionPerfilOpcion(1, 2);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Perfil_Opcion> PerfilOpcion(int perfil, int opcion)
        {
            try
            {
                // Aqui se pone la logica para extraer el Usuario y Clave
                Perfil_Opcion Obj = await model.GetPerfil_OpcionPerfilOpcion(1, 2);
                if (Obj == null)
                {
                    return null;
                }
                return Obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}