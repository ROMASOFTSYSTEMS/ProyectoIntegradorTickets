using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public EstadoController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Estado
        [HttpGet]
        public async Task<IActionResult> GetallEstados()
        {
            var lista = await _DataBase.Estado.OrderBy(c => c.t_estado).ToListAsync();
            return Ok(lista);
        }
        #endregion
 
    }
}
