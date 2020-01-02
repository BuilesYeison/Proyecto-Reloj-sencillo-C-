using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoReloj
{
    class ConfiguracionHoraria
    {
        public byte bHora, bMinuto, bSegundo;//creacion de variables necesarias
        public string sPeriodo;
        public void ZonaHoraria()
        {
            int z = 0;//variable necesaria para logica
            #region Explicacion y solicitud de datos
            while (z==0)//mientras z sea igual a 0 repita infinitamente lo siguiente
            {
                Console.ForegroundColor = ConsoleColor.Yellow; //Color de las letras
                Console.SetCursorPosition(25, 12);//ubicacion en consola
                Console.WriteLine("         Porfavor a continuacion configura el reloj segun tu zona horaria");
                Console.SetCursorPosition(25, 13);
                Console.WriteLine("Agrega a continuacion hora (formato 12 horas), minutos, segundos y periodo(AM o PM).");
                Console.SetCursorPosition(25, 14);
                Console.Write("             Presiona para continuar con la configuracion.");
                Console.ReadKey();//esperar entrada por teclado

                #region solicitud de datos
                try//intentar lo siguiente...
                {
                    Console.SetCursorPosition(45, 16);
                    Console.Write("Hora: ");//pedir hora
                    bHora = byte.Parse(Console.ReadLine());//convertirla en byte y guardarlo en una variable

                    Console.SetCursorPosition(45, 16);
                    Console.Write("Minuto: ");
                    bMinuto = byte.Parse(Console.ReadLine());

                    Console.SetCursorPosition(45, 16);
                    Console.Write("  Segundo: ");
                    bSegundo = byte.Parse(Console.ReadLine());

                    Console.SetCursorPosition(45, 16);
                    Console.Write("Periodo(PM o AM): ");//pedir periodo
                    sPeriodo = Console.ReadLine();//guardar en variable
                    if (sPeriodo == "am" || sPeriodo == "Am")//condicional para guardar el periodo en mayuscula
                    {
                        sPeriodo = "AM";
                        z = 1;//se le da a z = a 1 porque si pudo realizarse
                    }
                    else if (sPeriodo == "pm" || sPeriodo == "Pm")//condicional para guardar el periodo en mayuscula
                    {
                        sPeriodo = "PM";
                        z = 1;//se le da a z = a 1 porque si pudo realizarse
                    }
                    else if (sPeriodo != "AM" || sPeriodo != "PM")//si lo que ingrese el usuario es diferente a lo que se le pide
                    {
                        Console.SetCursorPosition(45, 18);
                        Console.WriteLine("No ingresaste el dato correcto");//diga que no ingreso lo correcto
                        Console.ReadKey();//entrada por teclado
                        z = 0;//se le da a z = 0 lo que significa que se repetira la solicitud de la configuracion
                    }
                }
                catch //sino pudo realizar las conversiones o el usuario no ingreso datos correctos
                {
                    Console.Clear();//limpiar pantalla
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("Hubo un error!No ingresaste los datos correctos");//imprimir que hubo un error
                    z = 0;//se le da a z = 0 lo que significa que se repetira la solicitud de la configuracion
                    Console.ReadKey();//entrada por teclado
                    Console.Clear();//limpiar pantalla
                }
                Console.Clear();//limpiar pantalla
                #endregion
            }
            Console.Clear();//limpiar pantalla
            #endregion
        }
    }
}
