using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Usings
using ProyectoIntegradorApi.Models;

namespace ProyectoIntegradorApi.Tickets
{
    public interface ITicketResolutorRepositorio : IRepositorioGenerico<Ticket>
    {
        Task<Ticket> GetTicketId(int id);
        Task<List<Ticket>> GetTicket_Listado();
        Task<bool> GrabarAtencion(Ticket entity);
    }
}
