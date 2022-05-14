using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Usings
using ProyectoIntegradorApi.Models;
namespace ProyectoIntegradorApi.Repositories
{

    public interface IEmpresaRepositorio
    {
        Task<Empresa> GetItemAsync(Guid id);
        Task<IEnumerable<Empresa>> GetItemsAsync();
        Task CreateItemAsync(Empresa empresa);
        Task UpdateItemAsync(Empresa empresa);
        Task DeleteItemAsync(Guid id);
    }

}
