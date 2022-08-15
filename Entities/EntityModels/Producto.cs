using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Entities.EntityModels
{
    public class Producto
    {
        [Column("ProductoId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es un campo obligatorio.")]
        [MaxLength(50, ErrorMessage = "Longitud máxima 50.")]
        public string Nombre { get; set; }

        [MaxLength(100, ErrorMessage = "Longitud máxima 100.")]
        public string Descripcion { get; set; }
        [Range(0, 18, ErrorMessage = "Edad de 0 a 100")]
        public int RestriccionEdad { get; set; }

        [Required(ErrorMessage = "Compañia es un campo obligatorio.")]
        [MaxLength(50, ErrorMessage = "Longitud máxima 50")]
        public string Compania { get; set; }
        [Required(ErrorMessage = "Precio es un campo obligatorio.")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Precio { get; set; }

        public bool Delete { get; set; }
    }
}
