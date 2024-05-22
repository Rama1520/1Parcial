using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public abstract class Documento
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public string Estado { get; set; } = "Inicio";
        protected abstract string NumNormalizado { get; }

        public Documento(string titulo, string autor, int anio)
        {
            Anio = anio;
            Titulo = titulo;
            Autor = autor;
        }

        public bool AvanzarEstado()
        {
            switch (Estado)
            {
                case "Inicio":
                    Estado = "Distribuido";
                    break;
                case "Distribuido":
                    Estado = "EnEscaner";
                    break;
                case "EnEscaner":
                    Estado = "EnRevision";
                    break;
                case "EnRevision":
                    Estado = "Terminado";
                    break;
                case "Terminado":
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Autor: {Autor}");
            sb.AppendLine($"Estado: {Estado}");
            return sb.ToString();
        }

        public static bool operator ==(Documento d1, Documento d2)
        {
            return d1.Equals(d2);
        }

        public static bool operator !=(Documento d1, Documento d2)
        {
            return !(d1 == d2);
        }
    }
}
