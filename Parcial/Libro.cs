using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Libro : Documento
    {
        public string ISBN { get; set; }
        public string Barcode { get; set; }
        public int Paginas { get; set; }

        protected override string NumNormalizado => ISBN;

        public Libro(string titulo, string autor, string isbn, string barcode, int paginas)
            : base(titulo, autor)
        {
            ISBN = isbn;
            Barcode = barcode;
            Paginas = paginas;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"Barcode: {Barcode}");
            sb.AppendLine($"Paginas: {Paginas}");
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is Libro other)
            {
                return Barcode == other.Barcode || ISBN == other.ISBN ||
                       (Titulo == other.Titulo && Autor == other.Autor);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (ISBN, Barcode, Titulo, Autor).GetHashCode();
        }
    }
}
