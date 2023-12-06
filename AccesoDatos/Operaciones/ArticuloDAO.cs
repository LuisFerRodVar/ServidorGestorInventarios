using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class ArticuloDAO
    {
        GestionInventarioContext contexto = new GestionInventarioContext();
        public Articulo getArticulo(int id)
        {
            var articulo = contexto.Articulos.Where(a => id == a.Id).FirstOrDefault();
            return articulo;
        }
        public bool agregarArticulo(int id, int idSubCategoria, string nombre, string marca, string detalle, int cantidad, int conversion)
        {
            try
            {
                var nuevoArticulo = new Articulo();
                nuevoArticulo.Id = id;
                nuevoArticulo.IdSubCategoria = idSubCategoria;
                nuevoArticulo.Nombre = nombre;
                nuevoArticulo.Marca = marca;
                nuevoArticulo.Detalle = detalle;
                nuevoArticulo.Cantidad = cantidad;
                nuevoArticulo.Conversion = conversion;
                contexto.Articulos.Add(nuevoArticulo);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarArticulo(int id)
        {
            try
            {
                var articulo = getArticulo(id);
                if(articulo == null)
                {
                    return false;
                }
                contexto.Remove(articulo);
                contexto.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool editarArticulo(int id, int idSubCategoria, string nombre, string marca, string detalle, int cantidad, int conversion)
        {
            try
            {
                var articulo = getArticulo(id);
                articulo.IdSubCategoria = idSubCategoria;
                articulo.Nombre = nombre;
                articulo.Marca = marca;
                articulo.Detalle = detalle;
                articulo.Cantidad = cantidad;
                articulo.Conversion = conversion;
                contexto.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
        public List<Articulo> getArticulos()
        {
            var articulos = contexto.Articulos.ToList();
            return articulos;
        }
        public List<Articulo> getArticuloSubCategoria(int id){
            var articulos = contexto.Articulos.Where(a => a.IdSubCategoria == id).ToList();
            return articulos;
        }

    }

}
