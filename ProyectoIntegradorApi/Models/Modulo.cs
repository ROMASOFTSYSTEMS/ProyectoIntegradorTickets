using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegradorApi.Models
{
    public class Modulo
    {
        [Key]
        public int id_modulo { get; set; }
        public string t_modulo { get; set; }
        public int f_estado { get; set; }
    }
}