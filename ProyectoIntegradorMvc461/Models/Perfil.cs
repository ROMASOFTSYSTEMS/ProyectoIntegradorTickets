using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorMvc461.Models
{
    public class Perfil
    {
        public int id_perfil { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string t_perfil { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado{ get; set; }
    }
}
