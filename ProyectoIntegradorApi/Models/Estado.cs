using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Estado
    {
        [Key]
        public int id_estado { get; set; }
        public string t_estado { get; set; }
    }
}
