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
    public class Usuario_PerfilDAL : IUsuario_PerfilRepositorio
    {
        private readonly string _CadenaConexion;
        // Constructor
        public Usuario_PerfilDAL(string pCadenaConexion)
        {
            _CadenaConexion = pCadenaConexion;
        }

        public async Task<Usuario_Perfil> GetUsuario_PerfilId(int id)
        {
            Usuario_Perfil ObjEntidad = new Usuario_Perfil();
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Perfil_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_perfil", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        ObjEntidad.id_usuario_perfil = Convert.ToInt32(dr["id_usuario_perfil"]);
                        ObjEntidad.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                        ObjEntidad.id_perfil = Convert.ToInt32(dr["id_perfil"]);
                        ObjEntidad.c_usuario = dr["c_usuario"].ToString();
                        ObjEntidad.t_perfil = dr["t_perfil"].ToString();
                        ObjEntidad.f_estado = Convert.ToInt32(dr["f_estado"]);
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
        public async Task<List<Usuario_Perfil>> GetUsuario_Perfiles(int id_usuario)
        {
            List<Usuario_Perfil> Listado = new List<Usuario_Perfil>();

            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Perfil_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_perfil", null);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        Listado.Add(new Usuario_Perfil
                        {
                            id_usuario_perfil = Convert.ToInt32(dr["id_usuario_perfil"]),
                            id_usuario = Convert.ToInt32(dr["id_usuario"]),
                            id_perfil = Convert.ToInt32(dr["id_perfil"]),
                            c_usuario = dr["c_usuario"].ToString(),
                            t_perfil = dr["t_perfil"].ToString(),
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
        public async Task<List<Usuario_Perfil>> GetUsuario_Perfil_Listado()
        {
            List<Usuario_Perfil> Listado = new List<Usuario_Perfil>();

            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Perfil_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id_usuario_empresa", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        Listado.Add(new Usuario_Perfil
                        {
                            id_usuario_perfil = Convert.ToInt32(dr["id_usuario_perfil"]),
                            id_usuario = Convert.ToInt32(dr["id_usuario"]),
                            id_perfil = Convert.ToInt32(dr["id_perfil"]),
                            c_usuario = dr["c_usuario"].ToString(),
                            t_perfil = dr["t_perfil"].ToString(),
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
        public async Task<bool> Grabar(Usuario_Perfil entity)
        {
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Perfil_Grabar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_perfil", entity.id_usuario_perfil);
                cmd.Parameters.AddWithValue("@id_usuario", entity.id_usuario);
                cmd.Parameters.AddWithValue("@id_perfil", entity.id_perfil);
                cmd.Parameters.AddWithValue("@f_estado", entity.f_estado);
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

        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Perfil_Eliminar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_perfil", id);
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
