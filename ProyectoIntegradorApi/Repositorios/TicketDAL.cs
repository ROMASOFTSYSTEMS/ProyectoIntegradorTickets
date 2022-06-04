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
    public class TicketDAL : ITicketRepositorio
    {
        private readonly string _CadenaConexion;
        // Constructor
        public TicketDAL(string pCadenaConexion)
        {
            _CadenaConexion = pCadenaConexion;
        }
        public async Task<bool> Grabar(Ticket entity)
        {
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Ticket_Grabar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ticket", entity.id_ticket);
                cmd.Parameters.AddWithValue("@id_empresa", entity.id_empresa);
                cmd.Parameters.AddWithValue("@id_usuario", entity.id_usuario);
                cmd.Parameters.AddWithValue("@id_sistema", entity.id_sistema);
                cmd.Parameters.AddWithValue("@id_modulo", entity.id_modulo);
                cmd.Parameters.AddWithValue("@id_tipo_ticket", entity.id_tipo_ticket);
                cmd.Parameters.AddWithValue("@id_estado_ticket", entity.id_estado_ticket);
                cmd.Parameters.AddWithValue("@t_observacion", entity.t_observacion);
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
        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Ticket_Eliminar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ticket", id);
                try
                {
                    await con.OpenAsync();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception)
                {
                    con.Close();
                    return false;
                }
            }
        }

        public async Task<Ticket> GetTicketId(int id)
        {
            Ticket ObjEntidad = new Ticket();
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Ticket_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_ticket", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        ObjEntidad.id_ticket = Convert.ToInt32(dr["id_ticket"]);
                        ObjEntidad.id_empresa = Convert.ToInt32(dr["id_empresa"]);
                        ObjEntidad.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                        ObjEntidad.id_sistema = Convert.ToInt32(dr["id_sistema"]);
                        ObjEntidad.id_modulo = Convert.ToInt32(dr["id_modulo"]);
                        ObjEntidad.id_tipo_ticket = Convert.ToInt32(dr["id_tipo_ticket"]);
                        ObjEntidad.id_estado_ticket = Convert.ToInt32(dr["id_estado_ticket"]);
                        ObjEntidad.t_informe_solucion = dr["t_informe_solucion"].ToString();
                        ObjEntidad.t_observacion = dr["t_observacion"].ToString();
                        ObjEntidad.t_informe_solucion = dr["t_informe_solucion"].ToString();
                        ObjEntidad.f_estado = Convert.ToInt32(dr["id_ticket"]);
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
            return ObjEntidad;
        }

        public async Task<List<Ticket>> GetListadoTickets()
        {
            List<Ticket> Listado = new List<Ticket>();

            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Ticket_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id_ticket", id);
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


    }
}
