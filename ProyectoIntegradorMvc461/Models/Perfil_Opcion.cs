using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Perfil_Opcion
    {
        public int id_perfil_opcion { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Perfil")]
        public int id_perfil { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Opcion")]
        public int id_opcion { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }
    }
}