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
    public class Usuario_EmpresaDAL : IUsuario_EmpresaRepositorio
    {
        private readonly string _CadenaConexion;
        // Constructor
        public Usuario_EmpresaDAL(string pCadenaConexion)
        {
            _CadenaConexion = pCadenaConexion;
        }

        public async Task<Usuario_Empresa> GetUsuario_EmpresaId(int id)
        {
            Usuario_Empresa ObjEntidad = new Usuario_Empresa();
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Empresa_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_empresa", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        ObjEntidad.id_usuario_empresa = Convert.ToInt32(dr["id_usuario_empresa"]);
                        ObjEntidad.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                        ObjEntidad.id_empresa = Convert.ToInt32(dr["id_empresa"]);
                        ObjEntidad.c_usuario = dr["c_usuario"].ToString();
                        ObjEntidad.t_empresa = dr["t_empresa"].ToString();
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

        public async Task<List<Usuario_Empresa>> GetUsuario_Empresas(int id_usuario)
        {
            List<Usuario_Empresa> Listado = new List<Usuario_Empresa>();

            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Empresa_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_empresa", null);
                cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        Listado.Add(new Usuario_Empresa
                        {
                            id_usuario_empresa = Convert.ToInt32(dr["id_usuario_empresa"]),
                            id_usuario = Convert.ToInt32(dr["id_usuario"]),
                            id_empresa = Convert.ToInt32(dr["id_empresa"]),
                            c_usuario = dr["c_usuario"].ToString(),
                            t_empresa = dr["t_empresa"].ToString(),
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
        public async Task<List<Usuario_Empresa>> GetUsuario_Empresa_Listado()
        {
            List<Usuario_Empresa> Listado = new List<Usuario_Empresa>();

            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Empresa_Consulta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id_usuario_empresa", id);
                try
                {
                    await con.OpenAsync();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        Listado.Add(new Usuario_Empresa
                        {
                            id_usuario_empresa = Convert.ToInt32(dr["id_usuario_empresa"]),
                            id_usuario = Convert.ToInt32(dr["id_usuario"]),
                            id_empresa = Convert.ToInt32(dr["id_empresa"]),
                            c_usuario = dr["c_usuario"].ToString(),
                            t_empresa = dr["t_empresa"].ToString(),
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
        public async Task<bool> Grabar(Usuario_Empresa entity)
        {
            using (SqlConnection con = new SqlConnection(_CadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("USP_Usuario_Empresa_Grabar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_empresa", entity.id_usuario_empresa);
                cmd.Parameters.AddWithValue("@id_usuario", entity.id_usuario);
                cmd.Parameters.AddWithValue("@id_empresa", entity.id_empresa);
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
                SqlCommand cmd = new SqlCommand("USP_Usuario_Empresa_Eliminar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario_empresa", id);
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
    }
}
