using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Repositories.Interfaces
{
	public interface IRepositoryManager
	{
		IProductoRepository Producto { get; }
		void Save();
	}
}
