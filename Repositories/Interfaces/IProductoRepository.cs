using Juguetes.Entities.DataTransferObjects;
using Juguetes.Entities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAllProductos(bool trackChanges);
        Producto GetProducto(int productoId, bool trackChanges);

        void UpdateProducto(Producto producto);
        void CreateProducto(Producto producto);
    }
}
