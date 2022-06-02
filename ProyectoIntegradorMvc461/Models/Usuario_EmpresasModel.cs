using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Usings
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace ProyectoIntegradorMvc461.Models
{
    public class Usuario_EmpresasModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Usuario_EmpresasModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<List<Usuario_Empresa>> GetUsuario_Empresas(int usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Empresas/" + usuario;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Usuario_Empresa> cList = await respuesta.Content.ReadAsAsync<List<Usuario_Empresa>>();
                    return cList;
                }
                else { return null; }
            }
        }
    }
}