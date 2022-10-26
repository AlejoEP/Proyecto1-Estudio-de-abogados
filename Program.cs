using System.Collections;

namespace AbogadosExpedientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstudioJuridico alejo; //Declaro la variable alejo de tipo EstudioJuridico
            alejo = new EstudioJuridico(); //instancia de la clase EstudioJuridico

            //declaro y creo 5 objetos de la clase abogado
            Abogado abogado1 = new Abogado("Javier", "Perez", "2222", "Laboral", "1");
            Abogado abogado2 = new Abogado("Gabriela", "Acosta", "3333", "Penal", "2");
            Abogado abogado3 = new Abogado("Fernando", "Burlando", "4444", "Penal", "2");
            Abogado abogado4 = new Abogado("Matias", "Morla", "5555", "Comercial", "4");
            Abogado abogado5 = new Abogado("Ana", "Rosenfel", "6666", "Familia", "5");

            //metodo que agrega abogados
            alejo.agregarAbogado(abogado1);
            alejo.agregarAbogado(abogado2);
            alejo.agregarAbogado(abogado3);
            alejo.agregarAbogado(abogado4);
            alejo.agregarAbogado(abogado5);

            //funcion que imprime menu de opciones. NO HACE NADA MAS QUE ESO
            static void menu()
            {
                Console.WriteLine("\nMenu de opciones");
                Console.WriteLine("1. Mostrar buffet de abogados");
                Console.WriteLine("2. Agregar abogado");
                Console.WriteLine("3. Eliminar abogado");
                Console.WriteLine("0. Salir\n");
            }


            menu();
            Console.WriteLine("Elija una opcion: ");
            int num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                if (num == 1)
                {
                    Console.WriteLine("\n\tBuffet de abogados\n");
                    alejo.mostrar();
                    menu();
                    Console.WriteLine("Elija una opcion: ");
                    num = int.Parse(Console.ReadLine());
                }
                else if (num == 2)
                {
                    agregaAbog(alejo);
                    menu();
                    Console.WriteLine("Elija una opcion: ");
                    num = int.Parse(Console.ReadLine());
                }
                else if (num == 3)
                {
                    Console.WriteLine("Para eliminar un abogado ingrese su dni: ");
                    string dni = Console.ReadLine();
                    borrarAbogado(alejo, dni);
                    menu();
                    Console.WriteLine("Elija una opcion: ");
                    num = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Ha salido correctamente del programa");

            static void agregaAbog(EstudioJuridico aboga)
            {
                string opcion = "";
                while (opcion.ToLower() != "no".ToLower())
                {
                    Console.WriteLine("Nombre:");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Apellido: ");
                    string ape = Console.ReadLine();
                    Console.WriteLine("DNI: ");
                    string dni = Console.ReadLine();
                    Console.WriteLine("Especialidad");
                    string esp = Console.ReadLine();
                    Console.WriteLine("Expedientes");
                    string exp = Console.ReadLine();
                    Abogado abogado = new Abogado(nom, ape, dni, esp, exp);
                    aboga.agregarAbogado(abogado);
                    Console.WriteLine("Si desea agregar otro abogado presione cualquier tecla y luego enter. Caso contrario ingrese 'NO'");
                    opcion = Console.ReadLine();
                }
            }

            static void borrarAbogado(EstudioJuridico aboga, string dni)
            {
                ArrayList nueva_lista_abogados;
                bool esta = false;
                nueva_lista_abogados = aboga.listAbogado(); /*tomo la lista de abogados*/
                foreach (Abogado abo in nueva_lista_abogados)
                {
                    if (abo.Dni == dni)
                    {
                        esta = true;
                        aboga.eliminarAbogado(abo);
                        break;
                    }
                }
                if (esta)
                {
                    Console.WriteLine("El abogado se elimino con éxito");
                }
            }
        }
        class EstudioJuridico
        {
            private ArrayList lista_abogados;
            private ArrayList lista_expedientes;

            public EstudioJuridico()
            {
                lista_abogados = new ArrayList();
                lista_expedientes = new ArrayList();
            }

            public void agregarAbogado(Abogado xabogado)
            {
                lista_abogados.Add(xabogado);
            }
            public void mostrar()
            {
                foreach (Abogado xabogado in lista_abogados)
                {
                    Console.WriteLine($"{xabogado.Nombre} {xabogado.Apellido} - DNI: {xabogado.Dni} - Especialidad: {xabogado.Especialidad}");
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
                return lista_expedientes;
            }
        }
        class Expediente
        {
            private string numero;
            private string tipo_tramite;
            private string estado;
            private string abogado;
            private string titular;

            public Expediente(string numero, string tipo_tramite, string estado, string abogado, string titular)
            {
                this.numero = numero;
                this.tipo_tramite = tipo_tramite;
                this.estado = estado;
                this.abogado = abogado;
                this.titular = titular;
            }

        }
        class Abogado
        {
            private string nombre;
            private string apellido;
            private string dni;
            private string especialidad;
            private string cant_expedientes;

            public Abogado(string nombre, string apellido, string dni, string especialidad, string cant_expedientes)
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

        }
        //estado: en letra, a despacho, en vista/giro, en fiscalia, preparalizado, archivado,   
    }
}//expedientes tipo judicial, administrativo, policial