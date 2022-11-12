using System.Collections;

namespace AbogadosExpedientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstudioJuridico estudioJuridico; //Declaro la variable alejo de tipo EstudioJuridico
            estudioJuridico = new EstudioJuridico(); //instancia de la clase EstudioJuridico


            //declaro y creo 5 objetos de la clase abogado
            Abogado abogado1 = new Abogado("Javier", "Perez", "2222", "Laboral", 0);
            Abogado abogado2 = new Abogado("Gabriela", "Acosta", "3333", "Penal", 0);

            //metodo que agrega abogados
            estudioJuridico.agregarAbogado(abogado1);
            estudioJuridico.agregarAbogado(abogado2);

            Expediente expediente1 = new Expediente(1, "Judicial", "Archivado", abogado1.Apellido, "nose");
            estudioJuridico.sumar_cantidad_expediente(abogado1);
            estudioJuridico.agregarExpediente(expediente1);

            Expediente expediente2 = new Expediente(2, "Previsional", "En despacho", abogado1.Apellido, "nose");
            estudioJuridico.sumar_cantidad_expediente(abogado1);
            estudioJuridico.agregarExpediente(expediente2);



            //Menu de opciones
            while (true)
            {
                Console.WriteLine("\nMenu de opciones");
                Console.WriteLine("1. Mostrar buffet de abogados");
                Console.WriteLine("2. Agregar abogado");
                Console.WriteLine("3. Eliminar abogado");
                Console.WriteLine("4. Lista de expedientes");
                Console.WriteLine("5. Agregar expediente y asignarlo a un abogado");
                Console.WriteLine("6. Modificar el estado de un expediente");
                Console.WriteLine("0. Salir\n");

                Console.WriteLine("Elija una opcion: ");
                try
                {
                    int num = int.Parse(Console.ReadLine());

                    if (num == 1)
                    {
                        Console.WriteLine("\n\tBuffet de abogados\n");
                        estudioJuridico.mostrarAbogados(); Console.WriteLine("\n*************************");
                    }
                    else if (num == 2)
                    {
                        agregaAbog(estudioJuridico); Console.WriteLine("\n*************************");
                    }
                    else if (num == 3)
                    {
                        Console.WriteLine("Para eliminar un abogado ingrese su dni: ");
                        string dni = Console.ReadLine();
                        borrarAbogado(estudioJuridico, dni); Console.WriteLine("\n*************************");
                    }
                    else if (num == 4)
                    {
                        Console.WriteLine("\n\tListado de expedientes\n");
                        estudioJuridico.mostrarExpediente(); Console.WriteLine("\n*************************");
                    }
                    else if (num == 5)
                    {
                        agregoExpe(estudioJuridico); Console.WriteLine("\n*************************");
                    }
                    else if (num == 6)
                    {

                        bool esnumero;
                        int valor = 0;

                        do
                        {
                            Console.WriteLine("Ingrese el numero del expediente: ");
                            string numero = Console.ReadLine();
                            esnumero = int.TryParse(numero, out valor); //validamos que sea un numero, si es true nos devuelve el numero que se guarda en valor

                            if (!esnumero)
                            {
                                Console.WriteLine("Error. Por favor, ingrese un numero");
                            }

                        } while (!esnumero);

                        cambiar_estado_exped(estudioJuridico, valor); Console.WriteLine("\n*************************");

                    }
                    else if (num == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Esa opcion no existe. Vuelva a intentarlo.");
                        Console.WriteLine("\n*************************");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Por favor, ingrese un numero");
                    Console.WriteLine("\n*************************");
                }

            }
            Console.WriteLine("Ha salido correctamente del programa");

            static void agregaAbog(EstudioJuridico aboga)
            {
                Console.WriteLine("Nombre:");
                string nom = Console.ReadLine();
                Console.WriteLine("Apellido: ");
                string ape = Console.ReadLine();
                Console.WriteLine("DNI: ");
                string dni = Console.ReadLine();
                Console.WriteLine("Especialidad");
                string esp = Console.ReadLine();


                int exp = 0;
                Abogado abogado = new Abogado(nom, ape, dni, esp, exp);
                aboga.agregarAbogado(abogado);
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

            static void agregoExpe(EstudioJuridico expedientes_abogados)
            {

                ArrayList lista_expedientes;
                lista_expedientes = expedientes_abogados.listExpediente();
                bool numero_igual = false;

                Console.WriteLine("Numero:");
                int num = int.Parse(Console.ReadLine());

                foreach (Expediente exped in lista_expedientes)
                {
                    if (num == exped.Numero)
                    {
                        numero_igual = true;
                    }
                }
                if (!numero_igual)
                {
                    Console.WriteLine("Tipo de tramite ");
                    string tramite = Console.ReadLine();
                    Console.WriteLine("Estado ");
                    string estado = Console.ReadLine();
                    Console.WriteLine("Abogado a cargo");
                    string abogado = Console.ReadLine();
                    Console.WriteLine("Titular");
                    string titular = Console.ReadLine();

                    Expediente expediente = new Expediente(num, tramite, estado, abogado, titular);

                    ArrayList recupero_lista_abogados;
                    recupero_lista_abogados = expedientes_abogados.listAbogado();

                    bool check = false;

                    foreach (Abogado abo in recupero_lista_abogados)
                    {
                        if (abo.Cant_Expedientes < 6 && abo.Apellido.ToLower() == expediente.Abogado.ToLower())
                        {
                            expedientes_abogados.sumar_cantidad_expediente(abo);
                            expedientes_abogados.agregarExpediente(expediente);

                            check = true;
                        }
                    }

                    if (check)
                    {
                        Console.WriteLine("El expediente se cargo con exito");
                    }
                    else
                    {
                        Console.WriteLine("Asignar a otro abogado");
                    }
                }
                else
                {
                    Console.WriteLine("Numero de expediente existente. Deberá buscar otro numero");
                }
            }


            static void cambiar_estado_exped(EstudioJuridico expedientes, int num)
            {
                ArrayList lista_exped = expedientes.listExpediente();//recupero la lista de expedientes

                bool existe = false;


                foreach (Expediente exped in lista_exped)
                {
                    if (num == exped.Numero)
                    {
                        Console.WriteLine("Ingrese el nuevo estado: ");
                        string estado = Console.ReadLine();
                        exped.Estado = estado;
                        existe = true;
                        break;
                    }

                }
                if (existe)
                {
                    Console.WriteLine($"El estado del expediente numero {num} se modifico con exito");
                }
                else
                {
                    Console.WriteLine("Numero de expediente inexistente");

                }

            }
            static void borrarExpediente(EstudioJuridico expedientes_abogados, int numero)
            {
                ArrayList lista_expediente;
                bool esta = false;
                lista_expediente = expedientes_abogados.listExpediente(); /*tomo la lista de expedientes*/
                foreach (Expediente exped in lista_expediente)
                {
                    if (exped.Numero == numero)
                    {
                        expedientes_abogados.eliminarExpediente(exped);
                        esta = true;

                        break;
                    }                   

                }

            }
        }          
    }
}