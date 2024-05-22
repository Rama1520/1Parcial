using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Escaner
    {
        private List<Documento> documentos = new List<Documento>();
        public string Locacion { get; private set; }
        public string Marca {get; private set; }
        public enum TipoDoc
        {
            libro,
            mapa
        }
        public Escaner(string marca, TipoDoc tipoDocumento)
        {
            Locacion = tipoDocumento.ToString() == "mapa" ? "mapoteca" : "procesosTecnicos";
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            return e.documentos.Contains(d);
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !e.documentos.Contains(d);
        }

        public static Escaner operator +(Escaner e, Documento d)
        {
            if (e != d && d.Estado == "Inicio")
            {
                d.AvanzarEstado();
                e.documentos.Add(d);
                return true;
            }
            return false;
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            var doc = documentos.FirstOrDefault(doc => doc == d);
            if (doc != null)
            {
                return doc.AvanzarEstado();
            }
            return false;
        }

        public List<Documento> ObtenerDocumentosPorEstado(string estado)
        {
            return documentos.Where(d => d.Estado == estado).ToList();
        }
    }
}
