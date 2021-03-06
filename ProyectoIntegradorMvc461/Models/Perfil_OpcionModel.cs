//Perfil_OpcionModel
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
    public class Perfil_OpcionModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Perfil_OpcionModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<Perfil_Opcion> GetPerfil_Opcion(int perfil, int opcion)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Perfil_Opcion/" + perfil + "/" + opcion;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Perfil_Opcion c = await respuesta.Content.ReadAsAsync<Perfil_Opcion>();
                    return c;
                }
                else { return null; }
            }

        }

        public async Task<List<Perfil_Opcion>> GetPerfil_Opciones(int perfil)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Perfil_Opcion/" + perfil;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    //Perfil_Opcion c = await respuesta.Content.ReadAsAsync<Perfil_Opcion>();
                    List<Perfil_Opcion> cList = await respuesta.Content.ReadAsAsync<List<Perfil_Opcion>>();
                    return cList;
                }
                else { return null; }
            }
        }
    }
}