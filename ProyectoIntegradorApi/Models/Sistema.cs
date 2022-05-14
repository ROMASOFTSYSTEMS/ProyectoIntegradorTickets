using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorApi.Models
{
    public class Sistema
    {
        [Key]
        public int id_sistema { get; set; }
        public string t_sistema { get; set; }
        public int f_estado { get; set; }
    }
}