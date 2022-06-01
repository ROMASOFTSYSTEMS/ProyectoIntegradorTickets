using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ProyectoIntegradorMvc461.Models
{
    public class Tipo_Ticket
    {
        [Key]
        public int id_tipo_ticket { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string t_tipo_ticket { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }

    }
}