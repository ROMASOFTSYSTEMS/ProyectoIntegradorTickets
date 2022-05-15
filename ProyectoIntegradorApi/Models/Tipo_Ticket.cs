using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Tipo_Ticket
    {
        [Key]
        public int id_tipo_ticket { get; set; }
        public string t_tipo_ticket { get; set; }
        public int f_estado { get; set; }
    }
}
