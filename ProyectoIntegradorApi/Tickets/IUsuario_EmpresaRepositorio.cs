using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Usings
using ProyectoIntegradorApi.Models;

namespace ProyectoIntegradorApi.Tickets
{
    public interface IUsuario_EmpresaRepositorio : IRepositorioGenerico<Usuario_Empresa>
    {
        Task<Usuario_Empresa> GetUsuario_EmpresaId(int id);
        Task<List<Usuario_Empresa>> GetUsuario_Empresas(int id_usuario);
        Task<List<Usuario_Empresa>> GetUsuario_Empresa_Listado();
    }
}

