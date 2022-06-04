using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ProyectoIntegradorApi.Models;
//Usings
using ProyectoIntegradorApi.Tickets;

namespace ProyectoIntegradorApi.Repositorios
{
    public class TicketResolutorDAL : ITicketResolutorRepositorio
    {
        private readonly string _CadenaConexion;
        // Constructor
        public TicketResolutorDAL(string pCadenaConexion)
        {
            _CadenaConexion = pCadenaConexion;
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetTicket_Listado()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Grabar(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GrabarAtencion(Ticket entity)
        {
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Ticket_GrabarAtencion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ticket", entity.id_ticket);
                cmd.Parameters.AddWithValue("@id_estado_ticket", entity.id_estado_ticket);
                cmd.Parameters.AddWithValue("@t_informe_solucion", entity.t_informe_solucion);
                cmd.Parameters.AddWithValue("@f_estado", entity.f_estado);
                try
                {
                    await con.OpenAsync();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    con.Close();
                    return false;
                }
            }
        }
    }
}
