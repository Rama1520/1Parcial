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
        public static bool operator ==(Libro l1, Libro l2) 
        { 
            return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN ||
                   (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }


        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
    

        
    }
}
