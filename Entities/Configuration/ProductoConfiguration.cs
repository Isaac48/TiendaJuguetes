using Juguetes.Entities.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Entities.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>

    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            {
                builder.HasData
                (
                new Producto
                {
                    Id = 1,
                    Nombre = "Nintendo switch",
                    Descripcion = "Consola Switch Neon 32GB",
                    Compania = "Nintendo",
                    RestriccionEdad = 18,
                    Precio = 444.51m
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Nintendo Switch Modelo OLED",
                    Descripcion = "Consola Switch Modelo OLED White Joy-Con - Standard Edition 64 GB",
                    Compania = "USA",
                    RestriccionEdad = 18,
                    Precio = 555.51m
                }
                );
            }
        }
    }
}
