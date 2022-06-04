using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Ticket
    {
        [Key]
        public int id_ticket { get; set; }
        public int id_empresa { get; set; }
        public string t_empresa { get; set; }
        public int id_usuario { get; set; }
        public string c_usuario { get; set; }
        public int id_sistema { get; set; }
        public string t_sistema { get; set; }
        public int id_modulo { get; set; }
        public string t_modulo { get; set; }
        public int id_tipo_ticket { get; set; }
        public string t_tipo_ticket { get; set; }
        public int id_estado_ticket { get; set; }
        public string t_estado_ticket { get; set; }
        public string t_observacion { get; set; }
        public string t_informe_solucion { get; set; }
        public int f_estado { get; set; }

    }
}
