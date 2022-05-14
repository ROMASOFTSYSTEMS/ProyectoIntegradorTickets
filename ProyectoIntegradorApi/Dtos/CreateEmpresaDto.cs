using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Dtos
{
    public record CreateEmpresaDto
    {
        [Required]
        public string t_empresa { get; init; }

        [Required]
        [Range(0, 1)]
        public int f_estado{ get; init; }

        //[Required]
        //[Range(1, 1000)]
        //public decimal Price { get; init; }
    }
}
