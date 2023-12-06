using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        ArticuloDAO ArticuloDAO = new ArticuloDAO();

        [HttpPost("articulo")]
        public bool agregarArticulo([FromBody] Articulo articulo)
        {
            return ArticuloDAO.agregarArticulo(articulo.Id, articulo.IdSubCategoria, articulo.Nombre, articulo.Marca, articulo.Detalle, articulo.Cantidad, articulo.Conversion);
        }

    }
}
