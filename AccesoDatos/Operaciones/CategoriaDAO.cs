using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class CategoriaDAO
    {
        GestionInventarioContext contexto = new GestionInventarioContext();

        public List<Categorium> getCategorias() {
            var categoria = contexto.Categoria.ToList();
            return categoria;
        }
        public bool agregarCategoria(int id, string nombre) {
            try
            {
                var categoria = new Categorium();
                categoria.Id = id;
                categoria.Nombre = nombre;
                contexto.Categoria.Add(categoria);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

        public Categorium getCategoria(int id) {
            var categoria = contexto.Categoria.Where(cat => cat.Id == id).FirstOrDefault();
            return categoria;
        }
        public bool eliminarCategoria(int id)
        {
            try
            {
                var categoria = getCategoria(id);

                if(categoria == null)
                {
                    return false;
                }

                contexto.Categoria.Remove(categoria);
                contexto.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool editarCategoria(int id, string nombre)
        {
            try
            {
                var categoria = getCategoria(id);
                if(categoria == null)
                {
                    return false;
                }
                categoria.Nombre = nombre;
                contexto.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }

    }
}
