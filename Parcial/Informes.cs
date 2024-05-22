using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Informes
    {
        public static double ObtenerExtension(Escaner escaner, string estado)
        {
            var documentos = escaner.ObtenerDocumentosPorEstado(estado);
            double totalExtension = 0;

            foreach (var doc in documentos)
            {
                if (doc is Libro libro)
                {
                    totalExtension += libro.Paginas;
                }
                else if (doc is Mapa mapa)
                {
                    totalExtension += mapa.Superficie;
                }
            }

            return totalExtension;
        }

        public static int ObtenerCantidad(Escaner escaner, string estado)
        {
            return escaner.ObtenerDocumentosPorEstado(estado).Count;
        }

        public static string ObtenerResumen(Escaner escaner, string estado)
        {
            var documentos = escaner.ObtenerDocumentosPorEstado(estado);
            var sb = new StringBuilder();

            foreach (var doc in documentos)
            {
                sb.AppendLine(doc.ToString());
            }

            return sb.ToString();
        }
    }
}
