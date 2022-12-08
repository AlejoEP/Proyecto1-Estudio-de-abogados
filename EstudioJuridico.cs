using System.Collections;

namespace AbogadosExpedientes
{
    internal class EstudioJuridico
    {
        private ArrayList lista_abogados;
        private ArrayList lista_expedientes;

        //metodo constructor
        public EstudioJuridico()
        {
            lista_abogados = new ArrayList();
            lista_expedientes = new ArrayList();
        }

        public void agregarAbogado(Abogado xabogado)
        {
            lista_abogados.Add(xabogado);
        }
        public void mostrarAbogados()
        {
            foreach (Abogado xabogado in lista_abogados)
            {
                Console.WriteLine($"Nombre y apellido: {xabogado.Nombre} {xabogado.Apellido}\nDNI: {xabogado.Dni}" +
                    $"\nEspecialidad: {xabogado.Especialidad}\nExpedientes: {xabogado.Cant_Expedientes}\n---------------------------------");
            }
        }
        public void eliminarAbogado(Abogado xabogado)
        {
            lista_abogados.Remove(xabogado);
        }

        public ArrayList listAbogado()
        {
            return lista_abogados; 
        }
        public ArrayList listExpediente()
        {
            return lista_expedientes; //me permite iterar sobra la lista de expedientes.
        }

        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        //metodos para expediente


        public void agregarExpediente(Expediente expediente)
        {
            lista_expedientes.Add(expediente);
        }
        public void mostrarExpediente()
        {
            if (lista_expedientes.Count > 0)
            {
                foreach (Expediente expediente in lista_expedientes)
                {
                    Console.WriteLine($"Numero de expediente: {expediente.Numero}\nTitular: {expediente.Titular}\nTipo de tramite: {expediente.Tramite}\n" +
                        $"Estado: {expediente.Estado}\nAbogado a cargo: {expediente.Abogado}\nFecha de presentacion: {expediente.FechaDePresentacion}\n----------------------------");                    
                }
            }
            else
            {
                Console.WriteLine("NO HAY EXPEDIENTES CARGADOS");
            }

        }
        public void eliminarExpediente(Expediente expediente)
        {
            lista_expedientes.Remove(expediente);
        }        
        
    }
}

