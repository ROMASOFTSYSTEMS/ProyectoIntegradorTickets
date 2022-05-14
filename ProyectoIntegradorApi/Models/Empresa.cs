using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegradorApi.Models
{
    public class Empresa
    {
        [Key]
        public int id_empresa { get; set; }
        public string t_empresa { get; set; }
        public int f_estado { get; set; }
    }
}
