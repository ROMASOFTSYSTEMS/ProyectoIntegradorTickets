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
    public class ModuloModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public ModuloModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Modulo>> GetModulo()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Modulo";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Modulo> cList = await respuesta.Content.ReadAsAsync<List<Modulo>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<Modulo> GetModuloByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Modulo/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Modulo c = await respuesta.Content.ReadAsAsync<Modulo>();
                    return c;
                }
                else { return null; }
            }
        }
        public async Task AddModulo(Modulo c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Modulo";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditModulo(Modulo c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Modulo";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeleteModulo(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Modulo/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}