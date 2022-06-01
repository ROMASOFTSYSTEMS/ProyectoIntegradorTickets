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
    public class Estado_TicketModel
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public Estado_TicketModel()
        {
            this.UriApi = "https://localhost:44396/"; // Local API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Estado_Ticket>> GetEstado_Ticket()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Estado_Ticket";
                client.BaseAddress = new Uri(this.UriApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List<Estado_Ticket> cList = await respuesta.Content.ReadAsAsync<List<Estado_Ticket>>();
                    return cList;
                }
                else { return null; }
            }
        }
    }
}