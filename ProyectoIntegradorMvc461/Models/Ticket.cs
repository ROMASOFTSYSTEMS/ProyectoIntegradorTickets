using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegradorMvc461.Models
{
    public class Ticket
    {
        [Key]
        public int id_ticket { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Empresa")]
        public int id_empresa { get; set; }
        public string t_empresa { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Usuario")]
        public int id_usuario { get; set; }
        public string c_usuario { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Sistema")]
        public int id_sistema { get; set; }
        public string t_sistema { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Modulo")]
        public int id_modulo { get; set; }
        public string t_modulo { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Tipo de Ticket")]
        public int id_tipo_ticket { get; set; }
        public string t_tipo_ticket { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado de Ticket")]
        public int id_estado_ticket { get; set; }
        public string t_estado_ticket { get; set; }
        [Required(ErrorMessage = "Debe ingresar Observación")]
        [DataType(DataType.MultilineText)]
        public string t_observacion { get; set; }
        [DataType(DataType.MultilineText)]
        public string t_informe_solucion { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }
    }
}