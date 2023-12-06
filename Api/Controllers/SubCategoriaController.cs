using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        SubCategoriaDAO subCategoriaDAO = new SubCategoriaDAO();

        [HttpPost("subCategoria")]
        public bool agregarSubCategoria([FromBody] SubCategorium subCategoria)
        {
            return subCategoriaDAO.agregarSubCategoria(subCategoria.Id,subCategoria.IdCategoria ,subCategoria.Nombre);
        }
        [HttpGet("subCategoria")]
        public List<SubCategorium> obtenerSubCategorias()
        {
            return subCategoriaDAO.getSubCategorias();
        }
        [HttpPut("subCategoria")]
        public bool editarSubCategoria([FromBody] SubCategorium subCategoria)
        {
            return subCategoriaDAO.editarSubCategoria(subCategoria.Id,subCategoria.IdCategoria, subCategoria.Nombre);
        }
        [HttpDelete("subCategoria")]
        public bool eliminarSubCategoria(int id)
        {
            return subCategoriaDAO.eliminarSubCategoria(id);
        }
        [HttpGet("subCate")]
        public SubCategorium getSubCategoria(int id)
        {
            return subCategoriaDAO.getSubCategoria(id);
        }

    }
}
