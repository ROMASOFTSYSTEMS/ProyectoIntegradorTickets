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
        public async Task<Usuario_Perfil> GetUsuario_PerfilByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Perfil/" + id;
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
        public async Task AddUsuario_Perfil(Usuario_Perfil c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditUsuario_Perfil(Usuario_Perfil c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Perfil";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeleteUsuario_Perfil(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Perfil/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}