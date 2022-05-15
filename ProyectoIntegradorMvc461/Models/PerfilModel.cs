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
    public class PerfilModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public PerfilModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Perfil>> GetPerfil()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Perfil> cList = await respuesta.Content.ReadAsAsync<List<Perfil>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<Perfil> GetPerfilByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Perfil/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Perfil c = await respuesta.Content.ReadAsAsync<Perfil>();
                    return c;
                }
                else { return null; }
            }
        }
        public async Task AddPerfil(Perfil c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditPerfil(Perfil c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeletePerfil(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Perfil/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}