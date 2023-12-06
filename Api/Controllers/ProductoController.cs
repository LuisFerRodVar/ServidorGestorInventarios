using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ArticuloDAO articuloDAO = new ArticuloDAO();
        [HttpGet("productos")]
        public List<Articulo> getArticulos()
        {
            return articuloDAO.getArticulos();
        }
        [HttpPost("productos")]
        public bool agregarProducto([FromBody] Articulo articulo)
        {
            return articuloDAO.agregarArticulo(articulo.Id, articulo.IdSubCategoria, articulo.Nombre, articulo.Marca, articulo.Detalle, articulo.Cantidad, articulo.Conversion);
        }
        [HttpPut("productos")]
        public bool editarProducto([FromBody] Articulo articulo)
        {
            return articuloDAO.editarArticulo(articulo.Id, articulo.IdSubCategoria, articulo.Nombre, articulo.Marca, articulo.Detalle, articulo.Cantidad, articulo.Conversion);
        }
        [HttpDelete("productos")]
        public bool eliminarProducto(int id)
        {
            return articuloDAO.eliminarArticulo(id);
        }
        [HttpGet("producto")]
        public Articulo obtenerArticulo(int id)
        {
            return articuloDAO.getArticulo(id);
        }


    }
}
