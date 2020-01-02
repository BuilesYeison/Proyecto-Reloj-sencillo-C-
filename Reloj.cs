using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;//libreria necesaria para el reloj

namespace ProyectoReloj
{
    class Reloj : ConfiguracionHoraria//la clase "Reloj" heredará todos los atributos y metodos de la clase "ConfiguracionHoraria"
    {
        public Reloj()//constructor 
        {
            ZonaHoraria();//llamado del metodo de la clase ConfiguracionHoraria cuya funcion es configurar el reloj            
            RelojDigital();//llamado del metodo ReloDigital cuya funcion es mostrar el reloj en pantalla con grafico
        }
        public void Grafico()
        {
            #region Grafico tipo RelojDigital
            Console.ForegroundColor = ConsoleColor.Cyan;//color de las letras, nuemros etc
            Console.SetCursorPosition(50, 10);//ubicacion en pantalla
            Console.WriteLine("╔");//impresion
            Console.SetCursorPosition(50, 11);
            Console.WriteLine("║");
            Console.SetCursorPosition(50, 12);
            Console.WriteLine("╚");

            Console.SetCursorPosition(62, 10);
            Console.WriteLine("╗");
            Console.SetCursorPosition(62, 11);
            Console.WriteLine("║");
            Console.SetCursorPosition(62, 12);
            Console.WriteLine("╝");

            int x = 51;//ubicacion en x necesaria
            for (int i = 0; i < 4; i++)//ciclo for 
            {
                Console.SetCursorPosition(x, 10);
                Console.WriteLine("═");
                Console.SetCursorPosition(x + 1, 10);//ubicacion x+1
                Console.WriteLine("═");//imprimir

                Console.SetCursorPosition(x, 12);//se le da 2 valores mas a Y
                Console.WriteLine("═");
                Console.SetCursorPosition(x + 1, 12);
                Console.WriteLine("═");
                x = x + 3;//se suma x por 3
            }

            x = 53;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, 10);
                Console.WriteLine("╦");
                Console.SetCursorPosition(x, 12);
                Console.WriteLine("╩");
                Console.SetCursorPosition(x, 11);
                Console.WriteLine(":");

                x = x + 3;
            }
            #endregion
        }

        public void RelojDigital()
        {
            int x = 0, y = 1;//variables necesarias para la logica del reloj

            while (x == 0)//mientras x siempre sea 0, esto es para que el reloj siempre funcione asi acaben los ciclos
            {
                for (int hrs = bHora; hrs <= 12; hrs++)//ciclo for para las horas se le pasa la hora que ingreso el usuario
                {
                    

                    for (int min = bMinuto; min < 60; min++)//ciclo for para los minutos y se le pasa los minutos que ingreso el usuario
                    {
                        if (bMinuto == 59)//daba un error cuando se ingresaba por ejemplo 11:59:55 cuando pasaba a las 12 pasaba de la siguiente manera 12:59:00
                            bMinuto = 0;//esta condicional arregla el error. Si minuto es igual a 59 entonces que pase directamente a 0
                        if (y == 0)//Condicional para no se repita infinitamente el segundo que ingreso el usuario, si y es igual a 0
                            bSegundo = 0;//elsegundo comenzara en 0
                        for (int seg = bSegundo; seg < 60; seg++)//ciclo for para los segundos y se le pasa los segundos que ingreso el usuario
                        {
                            if (hrs == 11&&min==59&&seg==59)//cuando sean las 11 y 59 y 59 segundos
                            {
                                if (sPeriodo == "am" || sPeriodo == "AM" || sPeriodo == "Am")//y si el usuario ingreso que es de mañana
                                    sPeriodo = "PM";//entonces que cambie a pm
                                else if (sPeriodo == "pm" || sPeriodo == "PM" || sPeriodo == "Pm")//sino
                                    sPeriodo = "AM";//que cambie a am
                            }

                            Console.Clear();//limpiara cada vez que aumente de segundo 
                            #region mensajes
                            if (sPeriodo=="AM")//si son las am
                            {
                                Console.SetCursorPosition(45,14);//imprimira el siguientes mensaje en estas ubicaciones
                                Console.WriteLine("Comenzar tu dia con una sonrisa");
                                Console.SetCursorPosition(45, 15);
                                Console.WriteLine("hara que tu destino se pinte");
                                Console.SetCursorPosition(45, 16);
                                Console.WriteLine("de colores. ¡Buenos Dias!");
                            }
                            else if (sPeriodo == "PM")//sino si son las PM
                            {
                                Console.SetCursorPosition(40, 14);//imprima el siguiente mensaje en las siguientes posiciones
                                Console.WriteLine("Aprende del ayer. Pero vive siempre");
                                Console.SetCursorPosition(40, 15);
                                Console.WriteLine("en el dia a dia, mira hacia el horizonte");
                                Console.SetCursorPosition(40, 16);
                                Console.WriteLine("del mañana esta bella tarde que nos acompaña");
                                Console.SetCursorPosition(50, 17);
                                Console.WriteLine("¡Feliz Tarde!");
                            }
                            if (hrs>=6&&hrs!=12&&sPeriodo == "PM")//si son mas  de las 6 pm
                            {
                                Console.Clear();//limpie el mensaje de feliz tarde 
                                Console.SetCursorPosition(40, 14);//imprimir el siguiente mensaje en las siguientes posiciones
                                Console.WriteLine("Cuando te vayas a la cama ");
                                Console.SetCursorPosition(40, 15);
                                Console.WriteLine("no olvides dejar tus problemas");
                                Console.SetCursorPosition(40, 16);
                                Console.WriteLine("bien lejos. ¡Feliz Noche!");                               
                            }
                            #endregion
                            Grafico();//imprimira infinitamente el grafico
                            Console.SetCursorPosition(51, 11);//ubicacion dentro del grafico
                            Console.Write(hrs);//se imprimira la hora
                            Console.SetCursorPosition(54, 11);//ubicacion dentro del grafico
                            Console.Write(min);//imprimira minuto
                            Console.SetCursorPosition(57, 11);//posicion dentro del grafico
                            Console.Write(seg);//impresion segundos
                            Console.SetCursorPosition(60, 11);//ubicacion dentro del grafico
                            Console.Write(sPeriodo);//impresion periodo
                            Thread.Sleep(1000);//tiempo equivalente a 1 segundo
                            y = 0;//cuando llega a 59 y sera = a 0                            
                        }
                    }
                }
                //cuando termine de hacer todos los ciclos
                bHora = 1;//hora equivale a 1
                bMinuto = 0;//minuto a 0
                bSegundo = 0;//segundo a 0
            }
        }
        
    }
}
