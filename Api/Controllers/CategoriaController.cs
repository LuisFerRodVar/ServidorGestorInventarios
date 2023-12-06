using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        CategoriaDAO categoriaDAO = new CategoriaDAO();

        [HttpPost("categoria")]
        public bool agregarCategoria([FromBody] Categorium categoria)
        {
            return categoriaDAO.agregarCategoria(categoria.Id, categoria.Nombre);
        }
        [HttpGet("categoria")]
        public List<Categorium> obtenerCategorias()
        {
            return categoriaDAO.getCategorias();
        }
        [HttpPut("categoria")]
        public bool editarCategoria([FromBody] Categorium categoria)
        {
            return categoriaDAO.editarCategoria(categoria.Id, categoria.Nombre);
        }
        [HttpDelete("categoria")]
        public bool eliminarCategoria(int id)
        {
            return categoriaDAO.eliminarCategoria(id);
        }
        [HttpGet("cate")]
        public Categorium getCategoria(int id)
        {
            return categoriaDAO.getCategoria(id);
        }
    }
}
