using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class FacturaDAO
    {
        GestionInventarioContext contexto = new GestionInventarioContext();

        public Factura getFactura(int id)
        {
            var factura = contexto.Facturas.Where(f => f.Id == id).FirstOrDefault();
            return factura;
        }
        public bool agregarFactura(int id, string fecha, string tipo, double impuesto, double total, bool credito)
        {
            try
            {
                var factura = new Factura();
                factura.Id = id;
                factura.Fecha = fecha;
                factura.Tipo = tipo;
                factura.Impuesto = impuesto;
                factura.Total = total;
                factura.Credito = credito;
                contexto.Facturas.Add(factura);
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool eliminarFactura(int id)
        {
            try
            {
                var factura = getFactura(id);
                if(factura == null)
                {
                    return false;
                }
                contexto.Facturas.Remove(factura);
                contexto.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool editarFactura(int id, string fecha, string tipo, double impuesto, double total, bool credito)
        {
            try
            {
                var factura = getFactura(id);
                if(factura == null)
                {
                    return false;
                }
                factura.Fecha=fecha;
                factura.Tipo=tipo;
                factura.Impuesto=impuesto;
                factura.Total = total;
                factura.Credito=credito;
                contexto.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
