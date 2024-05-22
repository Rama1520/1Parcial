using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Mapa : Documento
    {
        public string Barcode { get; set; }
        public int Anio { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }

        public double Superficie => Alto * Ancho;

        protected override string NumNormalizado => null;

        public Mapa(string titulo, string autor, string barcode, int anio, double alto, double ancho)
            : base(titulo, autor)
        {
            Barcode = barcode;
            Anio = anio;
            Alto = alto;
            Ancho = ancho;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Barcode: {Barcode}");
            sb.AppendLine($"Anio: {Anio}");
            sb.AppendLine($"Alto: {Alto}");
            sb.AppendLine($"Ancho: {Ancho}");
            sb.AppendLine($"Superficie: {Superficie}");
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Mapa other)
            {
                return Barcode == other.Barcode ||
                       (Titulo == other.Titulo && Autor == other.Autor &&
                        Anio == other.Anio && Superficie == other.Superficie);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Barcode, Titulo, Autor, Anio, Superficie).GetHashCode();
        }
    }
}
