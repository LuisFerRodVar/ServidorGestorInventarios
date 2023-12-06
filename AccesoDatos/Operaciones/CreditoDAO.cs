using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class CreditoDAO
    {
        GestionInventarioContext contexto = new GestionInventarioContext();

        public Credito getCredito(int id)
        {
            var credito = contexto.Creditos.Where(c=> id == c.Id).FirstOrDefault();
            return credito;
        }
        public bool agregarCredito(string fecha, double monto, int idFactura)
        {
            try
            {
                var credito = new Credito();
                credito.Fecha = fecha;
                credito.Monto = monto;
                credito.IdFactura = idFactura;
                contexto.Creditos.Add(credito);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarCredito(int id)
        {
            try
            {
                var credito = getCredito(id);
                if(credito != null)
                {
                    return false;
                }
                contexto.Creditos.Remove(credito);
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool editarCredito(int id, string fecha, double monto, int idFactura)
        {
            try
            {
                var credito = getCredito(id);
                if(credito == null) {
                    return false;
                }
                credito.Fecha = fecha;
                credito.Monto = monto;
                credito.IdFactura=idFactura;
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
