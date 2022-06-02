using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Usings
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;

namespace ProyectoIntegradorMvc461.Models
{
    public class EmpresaModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public EmpresaModel()
        {
            //this.UriApi = "https://localhost:44396/"; // Local API
            this.UriApi = ConfigurationManager.AppSettings[("RutaAPI")]; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empresa>> GetEmpresa()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Empresa";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Empresa> cList = await respuesta.Content.ReadAsAsync<List<Empresa>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<Empresa> GetEmpresaByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Empresa/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Empresa c = await respuesta.Content.ReadAsAsync<Empresa>();
                    return c;
                }
                else { return null; }
            }
        }
        public async Task AddEmpresa(Empresa c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Empresa";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditEmpresa(Empresa c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Empresa";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeleteEmpresa(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Empresa/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}