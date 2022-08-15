using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Entities.DataTransferObjects
{
    public class ProductForCreationDto
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int RestriccionEdad { get; set; }

        public string Compañia { get; set; }

        public decimal Precio { get; set; }
    }
}
