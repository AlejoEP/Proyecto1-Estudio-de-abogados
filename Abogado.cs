using System.Collections;

namespace AbogadosExpedientes
{
    internal class Abogado
    {
        private string nombre;
        private string apellido;
        private string dni;
        private string especialidad;
        private int cant_expedientes;

        //metodo constructor
        public Abogado(string nombre, string apellido, string dni, string especialidad, int cant_expedientes)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.especialidad = especialidad;
            this.cant_expedientes = cant_expedientes;
        }
        public string Nombre { get { return nombre; } set { } }
        public string Apellido { get { return apellido; } set { } }
        public string Dni { get { return dni; } set { } }
        public string Especialidad { get { return especialidad; } set { } }
        public int Cant_Expedientes { get { return cant_expedientes; } set { cant_expedientes = value; } }
        //si no hago un set de cant_expedientes no puedo agregarle expedientes ya que esta protegido.
    }
}
