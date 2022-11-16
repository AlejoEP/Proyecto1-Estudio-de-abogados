using System.Collections;

namespace AbogadosExpedientes
{
    internal class Expediente
    {
        private int numero;
        private string tipo_tramite;
        private string estado;
        private string abogado_a_cargo;
        private string titular;
        private DateOnly fecha_de_presentacion;
        //metodo constructor
        public Expediente(int numero, string tipo_tramite, string estado, string abogado, string titular, DateOnly fecha)
        {
            this.numero = numero;
            this.tipo_tramite = tipo_tramite;
            this.estado = estado;
            this.abogado_a_cargo = abogado;
            this.titular = titular;
            this.fecha_de_presentacion = fecha;
        }
        public int Numero { get { return numero; } }
        public string Tramite { get { return tipo_tramite; } }
        public string Estado { get { return estado; } set { estado = value; } }
        public string Abogado { get { return abogado_a_cargo; } set { abogado_a_cargo = value; } }
        public string Titular { get { return titular; } }
        public DateOnly FechaDePresentacion { get { return fecha_de_presentacion; } set { fecha_de_presentacion = value; } }
        
        
    }
}
