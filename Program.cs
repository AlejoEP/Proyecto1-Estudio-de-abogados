﻿using System.Collections;

namespace AbogadosExpedientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EstudioJuridico alejo; //Declaro la variable alejo de tipo EstudioJuridico
            alejo = new EstudioJuridico(); //instancia de la clase EstudioJuridico

            //declaro y creo 5 objetos de la clase abogado
            Abogado abogado1 = new Abogado("Javier", "Perez", "2222", "Laboral", 0);
            Abogado abogado2 = new Abogado("Gabriela", "Acosta", "3333", "Penal", 0);
            Abogado abogado3 = new Abogado("Fernando", "Burlando", "4444", "Penal", 0);
            Abogado abogado4 = new Abogado("Matias", "Morla", "5555", "Comercial", 0);
            Abogado abogado5 = new Abogado("Ana", "Rosenfel", "6666", "Familia", 0);            
            
            //metodo que agrega abogados
            alejo.agregarAbogado(abogado1);
            alejo.agregarAbogado(abogado2);
            alejo.agregarAbogado(abogado3);
            alejo.agregarAbogado(abogado4);
            alejo.agregarAbogado(abogado5);

            //Expediente expediente1 = new Expediente(1, "Judicial", "Archivado", abogado1.Apellido, "nose");
            //alejo.agregarExpediente(expediente1);

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
                        alejo.mostrarAbogados(); Console.WriteLine("\n*************************");
                    }
                    else if (num == 2)
                    {
                        agregaAbog(alejo); Console.WriteLine("\n*************************");
                    }
                    else if (num == 3)
                    {
                        Console.WriteLine("Para eliminar un abogado ingrese su dni: ");
                        string dni = Console.ReadLine();
                        borrarAbogado(alejo, dni); Console.WriteLine("\n*************************");
                    }
                    else if (num == 4)
                    {
                        Console.WriteLine("\n\tListado de expedientes\n");
                        alejo.mostrarExpediente(); Console.WriteLine("\n*************************");
                    }
                    else if (num == 5)
                    {
                        agregoExpe(alejo, alejo); Console.WriteLine("\n*************************");
                    }
                    else if (num == 6)
                    {
                        Console.WriteLine("Ingrese el numero del expediente: ");
                        int numero = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el nuevo estado: ");
                        string estado = Console.ReadLine();
                        cambiar_estado_exped(alejo, numero, estado); Console.WriteLine("\n*************************");
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
                }catch (Exception error)
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
                    Console.WriteLine("Expedientes");
                    int exp = int.Parse(Console.ReadLine());
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

            static void agregoExpe(EstudioJuridico exped, EstudioJuridico aboga)
            {
                Console.WriteLine("Numero:");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("Tipo de tramite ");
                string tramite = Console.ReadLine();
                Console.WriteLine("Estado ");
                string estado = Console.ReadLine();
                Console.WriteLine("Abogado");
                string abogado = Console.ReadLine();
                Console.WriteLine("Titular");
                string titular = Console.ReadLine();
                Expediente expediente = new Expediente(num, tramite, estado, abogado, titular);
                exped.agregarExpediente(expediente);
                ArrayList recupero_lista_abogados;
                recupero_lista_abogados = aboga.listAbogado();
                foreach (Abogado abo in recupero_lista_abogados)
                {
                    if (abo.Cant_Expedientes < 6 && abo.Apellido == expediente.Abogado )
                    {
                        aboga.asignarExpediente(abo);
                    }                    
                }
            }
            static void cambiar_estado_exped(EstudioJuridico expedientes, int num, string estado)
            {
                ArrayList lista_exped = expedientes.listExpediente();//recupero la lista de expedientes
                bool existe = false;
                foreach (Expediente exped in lista_exped)
                {
                    if (num == exped.Numero)
                    {
                        exped.Estado = estado;
                        existe = true;
                    }
                }
                if (existe)
                {
                    Console.WriteLine($"El estado del expediente numero {num} se modifico con exito");
                }
            }
        }

        class EstudioJuridico
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
                    Console.WriteLine($"{xabogado.Nombre} {xabogado.Apellido} - DNI: {xabogado.Dni} - Expedientes: {xabogado.Cant_Expedientes}");
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
                        Console.WriteLine($"{expediente.Numero} {expediente.Estado} {expediente.Abogado}");
                    }
                }
                else
                {
                    Console.WriteLine("NO HAY EXPEDIENTES CARGADOS");
                }
                    
            }
            public void asignarExpediente(Abogado xabogado)
            {
                xabogado.Cant_Expedientes += 1;
            }
            
        }      
    }
}