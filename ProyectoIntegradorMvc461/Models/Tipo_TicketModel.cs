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
    public class Tipo_TicketModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Tipo_TicketModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Tipo_Ticket>> GetTipo_Ticket()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Tipo_Ticket";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Tipo_Ticket> cList = await respuesta.Content.ReadAsAsync<List<Tipo_Ticket>>();
                    return cList;
                }
                else { return null; }
            }
        }
    }
}