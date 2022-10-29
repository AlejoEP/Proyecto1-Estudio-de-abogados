using System.Collections.Generic;

namespace AbogadosExpedientes
{
    internal class Expediente
    {
        private int numero;
        private string tipo_tramite;
        private string estado;
        private string abogado;
        private string titular;

        //metodo constructor
        public Expediente(int numero, string tipo_tramite, string estado, string abogado, string titular)
        {
            this.numero = numero;
            this.tipo_tramite = tipo_tramite;
            this.estado = estado;
            this.abogado = abogado;
            this.titular = titular;
        }
        public int Numero { get { return numero; } }
        public string Tramite { get { return tipo_tramite; } }
        public string Estado { get { return estado; } set { estado = value; } }
        public string Abogado { get { return abogado; } set { abogado = value; } }
        public string Titular { get { return tipo_tramite; } }
    }
}
