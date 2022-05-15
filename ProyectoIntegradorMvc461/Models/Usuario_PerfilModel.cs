//Usuario_PerfilModel
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
    public class Usuario_PerfilModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Usuario_PerfilModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<Usuario_Perfil> GetUsuario_Perfil(int usuario, int perfil)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Perfil/" + usuario + "/" + perfil;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Usuario_Perfil c = await respuesta.Content.ReadAsAsync<Usuario_Perfil>();
                    return c;
                }
                else { return null; }
            }

        }

        public async Task<List<Usuario_Perfil>> GetUsuario_Perfiles(int usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Perfil/" + usuario;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Usuario_Perfil> cList = await respuesta.Content.ReadAsAsync<List<Usuario_Perfil>>();
                    return cList;
                }
                else { return null; }
            }
        }
    }
}