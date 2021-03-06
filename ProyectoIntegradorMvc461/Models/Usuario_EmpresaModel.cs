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
    public class Usuario_EmpresaModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Usuario_EmpresaModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<Usuario_Empresa> GetUsuario_Empresa(int usuario, int perfil)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Empresa/" + usuario + "/" + perfil;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Usuario_Empresa c = await respuesta.Content.ReadAsAsync<Usuario_Empresa>();
                    return c;
                }
                else { return null; }
            }

        }

        public async Task<List<Usuario_Empresa>> GetUsuario_Empresas(int usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Empresa/" + usuario;
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
        public async Task<List<Usuario_Empresa>> GetUsuario_Empresas()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Empresa/";
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
        public async Task<Usuario_Empresa> GetUsuario_EmpresaByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Usuario_Empresa/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Usuario_Empresa c = await respuesta.Content.ReadAsAsync<Usuario_Empresa>();
                    return c;
                }
                else { return null; }
            }
        }
        public async Task AddUsuario_Empresa(Usuario_Empresa c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Empresa";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditUsuario_Empresa(Usuario_Empresa c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Empresa";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeleteUsuario_Empresa(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Usuario_Empresa/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
        
    }
}
