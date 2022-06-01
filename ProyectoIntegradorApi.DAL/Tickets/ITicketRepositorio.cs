using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Usings
using ProyectoIntegradorApi.DAL.Models;

namespace ProyectoIntegradorApi.DAL.Tickets
{
    public interface ITicketRepositorio: IRepositorioGenerico<Ticket>
    {
        Task<Ticket> GetTicketId(int id);
        Task<List<Ticket>> GetListadoTickets();

    }
}
