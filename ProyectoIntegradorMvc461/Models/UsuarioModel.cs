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
    public class UsuarioModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public UsuarioModel()
        {
            //this.UriApi = "http://localhost:50809/"; // Local API
            //this.UriApi = "http://agendaexampleapi.azurewebsites.net/"; // Azure API
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<Usuario> GetUsuarioByUserPass(string User, string Pass)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario/" + User + "/" + Pass;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Usuario c = await respuesta.Content.ReadAsAsync<Usuario>();
                    return c;
                }
                else { return null; }
            }
        }

        //public async Task<Usuario> GetUsuarioByUserPass(string User, string Pass)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        String petition = "api/Usuario/" + User + "/" + Pass;
        //        client.BaseAddress = new Uri(this.UriApi);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(mediaheader);
        //        HttpResponseMessage respuesta = await client.GetAsync(petition);
        //        if (respuesta.IsSuccessStatusCode)
        //        {
        //            List<Usuario> cList = await respuesta.Content.ReadAsAsync<List<Usuario>>();
        //            return cList;
        //        }
        //        else { return null; }
        //    }
        //}


    }
}