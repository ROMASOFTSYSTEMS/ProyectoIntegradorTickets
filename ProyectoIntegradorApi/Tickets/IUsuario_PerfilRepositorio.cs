using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Usings
using ProyectoIntegradorApi.Models;

namespace ProyectoIntegradorApi.Tickets
{
    public interface IUsuario_PerfilRepositorio : IRepositorioGenerico<Usuario_Perfil>
    {
        Task<Usuario_Perfil> GetUsuario_PerfilId(int id);
        Task<List<Usuario_Perfil>> GetUsuario_Perfiles(int id_usuario);
        Task<List<Usuario_Perfil>> GetUsuario_Perfil_Listado();
    }
}

