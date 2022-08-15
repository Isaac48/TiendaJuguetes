using Juguetes.Entities;
using Juguetes.Repositories.Implementation;
using Juguetes.Repositories.Interfaces;
using System;

namespace Repository {
	public sealed class RepositoryManager : IRepositoryManager
	{
		private  ApplicationContext _repositoryContext;
		private  IProductoRepository _productoRepository;

		public RepositoryManager(ApplicationContext repositoryContext)
		{
			_repositoryContext = repositoryContext;
			
		}

		public IProductoRepository Producto
		{
			get
			{
				if (_productoRepository == null)
					_productoRepository = new ProductoRepository(_repositoryContext);
				return _productoRepository;
			}
		}


        public void Save() => _repositoryContext.SaveChanges();
	}
}


