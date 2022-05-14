using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Dtos
{
    public class EmpresaDto
    {
        public Guid id_empresa { get; init; }
        public string t_empresa { get; init; }
        public int f_estado { get; init; }

    }
}
