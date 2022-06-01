using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.DAL.Tickets
{
    public interface IRepositorioGenerico<T> where T: class
    {
        Task<bool> Grabar(T entity);
        Task<bool> Eliminar(int id);

    }
}
