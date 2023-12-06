using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class SubCategoriaDAO
    {
        GestionInventarioContext contexto = new GestionInventarioContext();
        public SubCategorium getSubCategoria(int id)
        {
            var subCategoria = contexto.SubCategoria.Where(sc =>  sc.Id == id).FirstOrDefault();
            return subCategoria;

        }
        public List<SubCategorium> getSubCategorias()
        {
            var subCategorias = contexto.SubCategoria.ToList();
            return subCategorias;

        }
        public bool agregarSubCategoria(int id, int idCategoria, string nombre)
        {
            try
            {
                var subCategoria = new SubCategorium();
                subCategoria.Id = id;
                subCategoria.IdCategoria = idCategoria;
                subCategoria.Nombre = nombre;
                contexto.Add(subCategoria);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarSubCategoria(int id)
        {
            try
            {
                var subCategoria = getSubCategoria(id);
                if(subCategoria == null)
                {
                    return false;
                }
                contexto.SubCategoria.Remove(subCategoria);
                contexto.SaveChanges ();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool editarSubCategoria(int id, int idCategoria, string nombre)
        {
            try
            {
                var subCategoria = getSubCategoria(id);
                if(subCategoria == null)
                {
                    return false;
                }
                subCategoria.IdCategoria = idCategoria;
                subCategoria.Nombre = nombre;
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
