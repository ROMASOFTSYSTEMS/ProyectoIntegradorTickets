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
        private bool lAcceso;
        private Usuario oUsuario;
        private List<Perfil_Opcion> oLstOpciones;
        //private _Database 
        private int IdOpcion;
        public AutorizaUsuario(int IdOpcion = 0)
        {
            this.lAcceso = false;
            this.IdOpcion = IdOpcion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.model = new Perfil_OpcionModel();
            string nombreOpcion = "";
            //String nombreOpcion = "";
            //String nombreModulo = "";
            try
            {
                oUsuario = (Usuario)HttpContext.Current.Session["User"];
                oLstOpciones = (List<Perfil_Opcion>)HttpContext.Current.Session["Opciones"];
                if (oLstOpciones != null)
                {
                    if (oLstOpciones.Count() < 1)
                    {
                        //filterContext.Result = new RedirectResult("/Error/OpcionNoAutorizada?opcion=" + nombreOpcion);
                        filterContext.Result = new RedirectResult("/Error/UnauthorizedOption");
                    }
                    else
                    {
                        this.lAcceso = false;
                        // Aqui debo Buscar la Opcion recibida
                        for (int i = 0; i < oLstOpciones.Count(); i++)
                        {
                            //if(oLstOpciones[i].id_opcion.Equals(this.IdOpcion) && oLstOpciones[i].f_estado.Equals(1))
                            if (oLstOpciones[i].id_opcion.Equals(this.IdOpcion))
                            {
                                this.lAcceso = oLstOpciones[i].f_estado.Equals(1);
                                nombreOpcion = oLstOpciones[i].t_opcion.ToString();
                                break;
                            }
                        }
                        if (!this.lAcceso)
                        {
                            //filterContext.Result = new RedirectResult("/Error/OpcionNoAutorizada?opcion=" + nombreOpcion);
                            //filterContext.Result = new RedirectResult("/Error/UnauthorizedOption");
                            filterContext.Result = new RedirectResult("/Error/UnauthorizedOption?opcion=" + nombreOpcion);
                        }
                    }
                }
                else {
                    //filterContext.Result = new RedirectResult("/Error/OpcionNoAutorizada?opcion=" + nombreOpcion);
                    filterContext.Result = new RedirectResult("/Error/UnauthorizedOption");
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("/Error/UnauthorizedOption");
                //filterContext.Result = new RedirectResult("/Error/OpcionNoAutorizada?opcion=" + nombreOpcion);
                //throw;
            }

        }

        public async Task<Perfil_Opcion> PerfilOpcion(int perfil, int opcion)
        {
            try
            {
                // Aqui se pone la logica para extraer el Usuario y Clave
                Perfil_Opcion Obj = await model.GetPerfil_Opcion(perfil, opcion);
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

        public async Task<List<Perfil_Opcion>> PerfilOpciones(int perfil)
        {
            try
            {
                // Aqui se pone la logica para extraer el Usuario y Clave
                List<Perfil_Opcion> cList = await model.GetPerfil_Opciones(perfil);
                if (cList == null)
                {
                    return null;
                }
                return cList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}