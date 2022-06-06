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
    public class TicketsPorEmpresaDAL: ITicketsPorEmpresaRepositorio
    {
        private readonly string _CadenaConexion;
        // Constructor
        public TicketsPorEmpresaDAL(string pCadenaConexion)
        {
            _CadenaConexion = pCadenaConexion;
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetListadoTicketsPorEmpresa(int id)
        {
            List<Ticket> Listado = new List<Ticket>();

            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Ticket_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ticket", null);
                cmd.Parameters.AddWithValue("@id_empresa", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        Listado.Add(new Ticket
                        {
                            id_ticket = Convert.ToInt32(dr["id_ticket"]),
                            id_empresa = Convert.ToInt32(dr["id_empresa"]),
                            t_empresa = dr["t_empresa"].ToString(),
                            id_usuario = Convert.ToInt32(dr["id_usuario"]),
                            c_usuario = dr["c_usuario"].ToString(),
                            id_sistema = Convert.ToInt32(dr["id_sistema"]),
                            t_sistema = dr["t_sistema"].ToString(),
                            id_modulo = Convert.ToInt32(dr["id_modulo"]),
                            t_modulo = dr["t_modulo"].ToString(),
                            id_tipo_ticket = Convert.ToInt32(dr["id_tipo_ticket"]),
                            t_tipo_ticket = dr["t_tipo_ticket"].ToString(),
                            id_estado_ticket = Convert.ToInt32(dr["id_estado_ticket"]),
                            t_estado_ticket = dr["t_estado_ticket"].ToString(),
                            t_observacion = dr["t_observacion"].ToString(),
                            t_informe_solucion = dr["t_informe_solucion"].ToString(),
                            f_estado = Convert.ToInt32(dr["f_estado"])
                        });
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    string xx = ex.Message.ToString();
                    con.Close();
                }
            }
            return Listado;
        }

        public Task<Ticket> GetTicketId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Grabar(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
