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
    public class TicketModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public TicketModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }
        //public async Task<Ticket> GetTicket(int usuario, int perfil)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        String petition = "api/Ticket/" + usuario + "/" + perfil;
        //        client.BaseAddress = new Uri(this.UriApi);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(mediaheader);
        //        HttpResponseMessage respuesta = await client.GetAsync(petition);
        //        if (respuesta.IsSuccessStatusCode)
        //        {
        //            Ticket c = await respuesta.Content.ReadAsAsync<Ticket>();
        //            return c;
        //        }
        //        else { return null; }
        //    }

        //}
        public async Task<Ticket> GetTicketByID(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Ticket/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    Ticket c = await respuesta.Content.ReadAsAsync<Ticket>();
                    return c;
                }
                else { return null; }
            }
        }
        public async Task<List<Ticket>> GetTicketPorEmpresa(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/TicketsPorEmpresa/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Ticket> cList = await respuesta.Content.ReadAsAsync<List<Ticket>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<List<Ticket>> GetTicketPorSistema(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/TicketsPorSistema/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Ticket> cList = await respuesta.Content.ReadAsAsync<List<Ticket>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<List<Ticket>> GetTicketPorModulo(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/TicketsPorModulo/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Ticket> cList = await respuesta.Content.ReadAsAsync<List<Ticket>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task<List<Ticket>> GetTickets()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Tickets/";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Ticket> cList = await respuesta.Content.ReadAsAsync<List<Ticket>>();
                    return cList;
                }
                else { return null; }
            }
        }
        public async Task AddTicket(Ticket c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Ticket";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PostAsJsonAsync(peticion, c);
            }
        }
        public async Task EditTicket(Ticket c)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/TicketResolutor";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.PutAsJsonAsync(peticion, c);
            }
        }
        public async Task DeleteTicket(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/Ticket/" + id;
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                await client.DeleteAsync(peticion);
            }
        }
    }
}