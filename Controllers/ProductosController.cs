using Juguetes.Entities.DataTransferObjects;
using Juguetes.Entities.EntityModels;
using Juguetes.Logger;
using Juguetes.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juguetes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private ILoggerManager _logger;
        public ProductosController(ILoggerManager logger, IRepositoryManager repository)
        {
            _logger = logger;
            _repository = repository;
            
        }
        /// <summary>
        /// Endpoint para obtener todos los productos activos de la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProductos()
        {
            try
            {
                var productos = _repository.Producto.GetAllProductos(trackChanges: false);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salio mal {nameof(GetProductos)} action { ex}");
                return StatusCode(500, "Internal server error");
            }
        }
        /// <summary>
        /// Endpoint para obtener un producto por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = _repository.Producto.GetProducto(id, trackChanges: false);
            if (producto == null)
            {
                _logger.LogInfo($"Producto id: {id} no existe en la base de datos.");
                return NotFound();
            }
            else
            {
                return Ok(producto);
            }
        }
        /// <summary>
        /// Endpoint para crear productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost("Crear")]
        public IActionResult CreateProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El modelo de producto es nulo.");
            }
            _repository.Producto.CreateProducto(producto);
            _repository.Save();
            return Ok(producto);
        }
        /// <summary>
        /// Endpoint para actualizar productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost("Actualizar")]
        public IActionResult UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                _logger.LogError("El modelo a actualizar del producto es nulo.");
                return BadRequest("Modelo del producto es nulo");
            }
            var productoEntity = _repository.Producto.GetProducto(producto.Id, trackChanges: true);
            if (productoEntity == null)
            {
                _logger.LogInfo($"Producto id: {producto.Id} no existe en la base de datos.");
                return NotFound();
            }

            productoEntity.Id = producto.Id;
            productoEntity.Nombre = producto.Nombre;
            productoEntity.Descripcion = producto.Descripcion;
            productoEntity.Compania = producto.Compania;
            productoEntity.Precio = producto.Precio;
            productoEntity.RestriccionEdad = producto.RestriccionEdad;

            _repository.Producto.UpdateProducto(productoEntity);
            _repository.Save();
            return Ok(producto);
        }
        /// <summary>
        /// Endpoint para eliminar producto ("Borrado logico")
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost("Eliminar")]
        public IActionResult DeleteProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                _logger.LogError("El producto a eliminar es nulo.");
                return BadRequest("Modelo del producto es nulo");
            }
            var productoEntity = _repository.Producto.GetProducto(producto.Id, trackChanges: true);
            if (productoEntity == null)
            {
                _logger.LogInfo($"Producto id: {producto.Id} no existe en la base de datos.");
                return NotFound();
            }
            productoEntity.Id = producto.Id;
            productoEntity.Delete = true;
            _repository.Producto.UpdateProducto(productoEntity);
            _repository.Save();
            return Ok(productoEntity);
        }


    }
}
