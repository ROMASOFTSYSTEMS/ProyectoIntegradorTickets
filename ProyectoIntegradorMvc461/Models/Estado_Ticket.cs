using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Estado_Ticket
    {
        [Key]
        public int id_estado_ticket { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string t_estado_ticket { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }
    }
}