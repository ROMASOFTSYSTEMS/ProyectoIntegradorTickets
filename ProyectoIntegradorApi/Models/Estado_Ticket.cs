using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Estado_Ticket
    {
        [Key]
        public int id_estado_ticket { get; set; }
        public string t_estado_ticket { get; set; }
        public int f_estado { get; set; }
    }
}
