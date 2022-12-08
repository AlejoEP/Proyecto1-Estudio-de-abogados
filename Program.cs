using System.Collections;

namespace AbogadosExpedientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstudioJuridico estudioJuridico; //Declaro la variable estudiojuridico de tipo EstudioJuridico
            estudioJuridico = new EstudioJuridico(); //instancia de la clase EstudioJuridico/ creo el objeto 
            

            //declaro y creo 2 objetos de la clase abogado
            Abogado abogado1 = new Abogado("Javier", "Perez", "2222", "Laboral", 0);
            Abogado abogado2 = new Abogado("Gabriela", "Acosta", "3333", "Penal", 0);

            //metodo que agrega abogados
            estudioJuridico.agregarAbogado(abogado1);
            estudioJuridico.agregarAbogado(abogado2);

            //declaro y creo 3 objetos de la clase Expediente. 
            Expediente expediente1 = new Expediente(1, "Judicial", "Archivado", abogado1.Apellido, "Lionel Messi", new DateOnly(2022,12,23));
            abogado1.sumar_un_expediente();
            estudioJuridico.agregarExpediente(expediente1);

            Expediente expediente2 = new Expediente(2, "Audiencia", "En despacho", abogado1.Apellido, "Julian Alvarez", new DateOnly(2022, 02, 15));
            abogado1.sumar_un_expediente();
            estudioJuridico.agregarExpediente(expediente2);

            Expediente expediente3 = new Expediente(3, "Audiencia", "salida", abogado2.Apellido, "Marcos Acuña", new DateOnly(2022, 01, 13));
            abogado2.sumar_un_expediente();
            estudioJuridico.agregarExpediente(expediente3);



            //Menu de opciones
            while (true)
            {
                Console.WriteLine("\nMENU DE OPCIONES\n");
                Console.WriteLine("1. Mostrar buffet de abogados");
                Console.WriteLine("2. Agregar abogado");
                Console.WriteLine("3. Eliminar abogado");
                Console.WriteLine("4. Lista de expedientes");
                Console.WriteLine("5. Agregar expediente y asignarlo a un abogado");
                Console.WriteLine("6. Modificar el estado de un expediente");
                Console.WriteLine("7. Eliminar expediente");
                Console.WriteLine("8. Listado de expedientes de tipo ‘audiencia’ que se hayan presentado en un mes determinado ");
                Console.WriteLine("0. Salir\n");

                Console.WriteLine("Elija una opcion: ");
                try
                {
                    int num = int.Parse(Console.ReadLine());

                    if (num == 1)
                    {
                        Console.WriteLine("\n\tBuffet de abogados\n");
                        estudioJuridico.mostrarAbogados();
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (num == 2)
                    {
                        agregaAbog(estudioJuridico); Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (num == 3)
                    {
                        Console.WriteLine("Para eliminar un abogado ingrese su dni: ");
                        string dni = Console.ReadLine();
                        borrarAbogado(estudioJuridico, dni); Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (num == 4)
                    {
                        Console.WriteLine("\n\tListado de expedientes\n");
                        estudioJuridico.mostrarExpediente();
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (num == 5)
                    {
                        agregoExpe(estudioJuridico); Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
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

                        cambiar_estado_exped(estudioJuridico, valor); Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();

                    }
                    else if (num == 7)
                    {
                        Console.WriteLine("Ingrese el numero del expediente que desea borrar: ");
                        int numero = int.Parse(Console.ReadLine());
                        borrarExpediente(estudioJuridico, numero);
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (num == 8)
                    {
                        Console.WriteLine("Ingrese numero de mes:");
                        int xmes = int.Parse(Console.ReadLine());
                        lista_expedientes_tipo_audiencia(estudioJuridico, xmes); Console.WriteLine("\n------------------------------");
                        Console.WriteLine("\nPresione cualquier tecla y luego enter para regresar al menu:");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (num == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Esa opcion no existe. Vuelva a intentarlo.");
                        Console.WriteLine("\n------------------------------");
                    }
                }
                catch (Exception) //si no ingresa un numero, capturamos el error
                {
                    Console.WriteLine("Error. Por favor, ingrese un numero");
                    Console.WriteLine("\n------------------------------");
                }

            }
            Console.WriteLine("Ha salido correctamente del programa");


            static void agregaAbog(EstudioJuridico estudioJuridico)
            {
                Console.WriteLine("Nombre:");
                string nom = Console.ReadLine();
                Console.WriteLine("Apellido: ");
                string ape = Console.ReadLine();
                Console.WriteLine("DNI: ");
                string dni = Console.ReadLine();
                Console.WriteLine("Especialidad");
                string esp = Console.ReadLine();


                int exp = 0; //expediente es igual a cero xq al agregar un abogado debe iniciar sin expedientes

                Abogado abogado = new Abogado(nom, ape, dni, esp, exp);
                estudioJuridico.agregarAbogado(abogado);
            }

            static void borrarAbogado(EstudioJuridico estudioJuridico, string dni)
            {
                ArrayList lista_abogados_actualizada;                
                lista_abogados_actualizada = estudioJuridico.listAbogado(); //tomo la lista de abogados

                bool encuentra = false;

                foreach (Abogado abogado in lista_abogados_actualizada)
                {
                    if (abogado.Dni == dni)
                    {
                        encuentra = true;
                        estudioJuridico.eliminarAbogado(abogado);
                        break;
                    }
                }
                if (encuentra)
                {
                    Console.WriteLine("El abogado se elimino con éxito");
                }
            }


            static void agregoExpe(EstudioJuridico expedientes_abogados)
            {
                ArrayList lista_expedientes;
                lista_expedientes = expedientes_abogados.listExpediente();

                ArrayList lista_abogados;
                lista_abogados = expedientes_abogados.listAbogado();

                bool numero_igual = false;

                Console.WriteLine("Numero:");
                int num = int.Parse(Console.ReadLine());

                foreach (Expediente exped in lista_expedientes)
                {
                    if (num == exped.Numero)
                    {
                        numero_igual = true; //estoy validando que el numero ingresado este dentro de la lista de expedientes
                    }
                }

                if (!numero_igual) //si el numero ingresado no esta; se procede a cargar un nuevo expediente
                {
                    Console.WriteLine("Tipo de tramite ");
                    string tramite = Console.ReadLine();
                    Console.WriteLine("Estado ");
                    string estado = Console.ReadLine();
                    Console.WriteLine("Abogado a cargo");
                    string abog = Console.ReadLine();
                    Console.WriteLine("Titular");
                    string titular = Console.ReadLine();
                    Console.WriteLine("Fecha de presentacion(Dia/Mes/Año) ");
                    DateOnly fecha = DateOnly.Parse(Console.ReadLine());
                    
                    bool crea_exped = false;
                    

                    try
                    {
                        foreach (Abogado xabogado in lista_abogados)
                        {
                            if (abog.ToLower() == xabogado.Apellido.ToLower())// abog es el abogado que le pasamos al expediente que vamos a generar
                            {
                                if (xabogado.Cant_Expedientes <= xabogado.Limite) //si no superamos el limite creamos el expediente
                                {
                                    Expediente expediente = new Expediente(num, tramite, estado, abog, titular, fecha);
                                    expedientes_abogados.agregarExpediente(expediente);
                                    xabogado.sumar_un_expediente();
                                    crea_exped = true;
                                }
                                else 
                                {
                                    throw new ExcepcionLimiteExpediente(); // superamos el limite, levantamos una excepcion
                                }
                            }
                            
                        }
                        if (!crea_exped)
                        {
                            Console.WriteLine($"No contamos con el/la abogado/a '{abog}' en nuestro estudio. " +
                                $"Consulte nuestro buffet de abogados y elija otro");
                            
                        }
                        if (crea_exped)
                        {
                            Console.WriteLine("\nEl expediente fue creado y asignado con exito.");
                        }

                    }
                    catch (ExcepcionLimiteExpediente) //capturamos la excepcion levantada e indicamos el error
                    {
                        Console.WriteLine($"El abogado {abog} supera el limite de expedientes permitido. Consulte nuestro buffet de abogados para elegir otro");
                    }
                    
                }

                else
                {
                    Console.WriteLine("Numero de expediente existente. Verifique bien el numero a ingresar y luego vuelva a elegir la opcion 5.");
                }
            }


            static void cambiar_estado_exped(EstudioJuridico expedientes, int num)
            {
                ArrayList lista_exped = expedientes.listExpediente();//recupero la lista de expedientes

                bool existe = false;


                foreach (Expediente exped in lista_exped)
                {
                    if (num == exped.Numero) //si el numero que le pasamos por parametro es igual al numero de expediente cambiamos el estado
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
                    Console.WriteLine($"\nEl estado del expediente numero {num} se modifico con exito");
                }
                else
                {
                    Console.WriteLine("Numero de expediente inexistente");

                }

            }


            static void borrarExpediente(EstudioJuridico expedientes_abogados, int numero)
            {
                ArrayList lista_expediente;                
                lista_expediente = expedientes_abogados.listExpediente(); //tomo la lista de expedientes

                bool esta = false;
                string? expediente = null; //el compilador de C# no permite el uso de variables no inicializadas/asignadas


                foreach (Expediente exped in lista_expediente)
                {
                    if (exped.Numero == numero) //si el numero que le pasamos por parametro es igual al numero de expediente eliminamos expediente
                    {
                        expedientes_abogados.eliminarExpediente(exped);
                        esta = true;
                        expediente = exped.Abogado;
                        break;
                    }                   

                }
                if (esta)
                {
                    Console.WriteLine("El expediente se elimino con exito.");
                }

                ArrayList lista_abogados;
                lista_abogados = expedientes_abogados.listAbogado(); //tomo la lista de abogados

                foreach (Abogado abogado in lista_abogados)
                {
                    if (abogado.Apellido == expediente) // cuando el valor booleano cambia a verdadero es xq elimina el expediente, entonces 
                    {
                        abogado.restar_un_expediente();
                        break;
                    }
                }

            }


            static void lista_expedientes_tipo_audiencia(EstudioJuridico expedientes, int mes)
            {
                ArrayList lista_expedientes;                

                ArrayList expedientes_tipo_audiencia = new ArrayList(); //creamos un nuevo Arraylist para guardar los expedientes tipo audiencia

                bool check = false;

                lista_expedientes = expedientes.listExpediente();
                

                foreach (Expediente exped in lista_expedientes)
                {
                    if (exped.Tramite.ToLower() == "Audiencia".ToLower() && exped.FechaDePresentacion.Month == mes)
                    {
                        expedientes_tipo_audiencia.Add(exped);
                        check = true;
                    }
                }

                if (!check)
                {
                    Console.WriteLine("No se han encontrado expedientes que cumplan los parametros requeridos");
                }
                else
                {
                    foreach (Expediente exped in expedientes_tipo_audiencia) //imprimimos expedientes tipo audiencia
                    {
                        Console.WriteLine($"\nTipo de tramite: {exped.Tramite}\nFecha de presentacion: {exped.FechaDePresentacion}\nAbogado a cargo: {exped.Abogado}");
                    }
                }
            }
        }          
    }
}