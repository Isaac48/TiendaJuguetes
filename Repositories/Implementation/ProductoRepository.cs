using Juguetes.Entities;
using Juguetes.Entities.DataTransferObjects;
using Juguetes.Entities.EntityModels;
using Juguetes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Repositories.Implementation
{
    internal sealed class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProducto(Producto producto) => Create(producto);

        public void UpdateProducto(Producto producto) => Update(producto);



        public IEnumerable<Producto> GetAllProductos(bool trackChanges) =>
            FindAll(trackChanges)
            .Where(x => x.Delete == false)
            .OrderBy(c => c.Nombre)
            .ToList();

        public Producto GetProducto(int productoId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(productoId), trackChanges)
            .SingleOrDefault();

    }
}
