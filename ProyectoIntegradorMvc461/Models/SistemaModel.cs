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
    public class SistemaModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public SistemaModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Sistema>> GetSistema()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Sistema";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Sistema> cList = await respuesta.Content.ReadAsAsync<List<Sistema>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<Sistema> GetSistemaByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Sistema/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Sistema c = await respuesta.Content.ReadAsAsync<Sistema>();
                    return c;
                }
                else { return null; }
            }
        }
        public async Task AddSistema(Sistema c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Sistema";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditSistema(Sistema c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Sistema";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeleteSistema(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Sistema/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}