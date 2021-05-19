using Cliente.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes
{
    public partial class Program
    {
        
        public static string GetFecha()
        {
            string fecha;
            string año = "";
            string mes = "";
            string dia = "";
            string hora = "";
            string minuto = "";
            string segundo = "";
            do
            {
                Console.WriteLine("Ingrese la fecha actual del servidor en el formato yyyy-MM-dd-HH-mm-ss");
                string fechaFormat = Console.ReadLine().Trim();
                string[] formato = fechaFormat.Split('-');
                try
                {
                    año = formato[0];
                    mes = formato[1];
                    dia = formato[2];
                    hora = formato[3];
                    minuto = formato[4];
                    segundo = formato[5];
                    fecha = año + "-" + mes + "-" + dia + " " + hora + ":" + minuto + ":" + segundo;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("La fecha debe tener el formato yyyy-MM-dd-HH-mm-ss");
                    fecha = null;
                }
            } while (año.Length != 4 || mes.Length != 2 || dia.Length != 2 || hora.Length != 2 || minuto.Length != 2 || segundo.Length != 2);
            return fecha;
        }
        
        public static int GetNroMedidor()
        {
            int opcion = -1;
            do
            {
                Console.WriteLine("Ingrese numero de Medidor");
                if (!int.TryParse(Console.ReadLine().Trim(), out opcion))
                {
                    Console.WriteLine("El numero del medidor debe ser numerico");
                    opcion = -1;
                }
                else if (opcion < 0 || opcion > 9)
                {
                    Console.WriteLine("El numero del medidor es de largo 1");
                    opcion = -1;
                }
            } while (opcion == -1);
            return opcion;
        }

        public static int GetNroSerie()
        {
            int opcion = -1;
            do
            {
                Console.WriteLine("Ingresar Numero de Serie");
                if (!int.TryParse(Console.ReadLine().Trim(), out opcion))
                {
                    Console.WriteLine("El numero de serie debe ser numerico");
                    opcion = -1;
                }
            } while (opcion == -1);
            return opcion;
        }

        public static int GetValor()
        {
            int opcion = -1;
            do
            {
                Console.WriteLine("Ingresar valor");
                if (!int.TryParse(Console.ReadLine().Trim(), out opcion))
                {
                    Console.WriteLine("El valor debe ser numerico");
                    opcion = -1;
                }
                else if (opcion < 0 || opcion > 1000)
                {
                    Console.WriteLine("El valor debe ser entre 0 y 1000");
                    opcion = -1;
                }

            } while (opcion == -1);
            return opcion;
        }

        public static int GetEstado()
        {
            int opcion = -1;
            do
            {
                Console.WriteLine("Ingrese un estado");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");
                if (!int.TryParse(Console.ReadLine().Trim(), out opcion))
                {
                    Console.WriteLine("Error al ingresar, la seleccion debe ser 1 o 2");
                    opcion = -1;
                }
                else if (opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Error al ingresar, la seleccion debe ser 1 o 2");
                    opcion = -1;
                }

            } while (opcion == -1);
            return opcion;
        }

        
        public static int GetTipo()
        {
            int opcion = -1;
            do
            {
                Console.WriteLine("Ingrese un tipo de medidor");
                Console.WriteLine("1. Trafico");
                Console.WriteLine("2. Consumo");
                if (!int.TryParse(Console.ReadLine().Trim(), out opcion))
                {
                    Console.WriteLine("Error al ingresar, la seleccion debe ser 1 o 2");
                    opcion = -1;
                }
                else if (opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Error al ingresar, la seleccion debe ser 1 o 2");
                    opcion = -1;
                }
            } while (opcion != 1 && opcion != 2);
            return opcion;
        }

        public static int GetSeleccion()
        {
            int opcion = -2;
            do
            {
                Console.WriteLine("Seleccione un tipo de estado");
                Console.WriteLine("-1. Error de lectura");
                Console.WriteLine("0. OK");
                Console.WriteLine("1. Punto de carga lleno");
                Console.WriteLine("2. Requiere mantencion preventiva");
                if (!int.TryParse(Console.ReadLine().Trim(), out opcion))
                {
                    Console.WriteLine("Error al ingresar, el estado debe ser -1, 0, 1 o 2");
                    opcion = -2;
                }
                else if (opcion != -1 && opcion != 0 && opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Error al ingresar debe seleccionar un estado existente en la lista");
                    opcion = -2;
                }


            } while (opcion == -2);
            return opcion;
        }


        static void Main(string[] args)
        {
            String ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            ClienteSocket clienteSocket = new ClienteSocket(ip, puerto);
            Console.WriteLine("Conectando al servidor {0} en el puerto {1}", ip, puerto);
            if (clienteSocket.Conectar())
            {
                Console.WriteLine("Cliente conectado con exito");
                int tipo = GetTipo();
                string fecha = GetFecha();
                int nroMedidor = GetNroMedidor();
                string mensaje = fecha + "|" + nroMedidor + "|" + tipo;
                clienteSocket.Escribir(mensaje);
                string mensajeRecibido = clienteSocket.Leer();
                Console.WriteLine(mensajeRecibido);
                string[] formato = mensajeRecibido.Split('|');
                string confirmar;
                confirmar = formato[1];
                if (confirmar.Equals("WAIT"))
                {
                    Console.WriteLine("Actualizacion de estado");
                    int nroSerie = GetNroSerie();
                    string fechaActual = GetFecha();
                    int Tipo = GetTipo();
                    int valor = GetValor();
                    int estado = GetEstado();
                    if (estado == 1)
                    {
                        int seleccion = GetSeleccion();
                        if (seleccion == -1)
                        {
                            seleccion = -1;
                        }
                        else if (seleccion == 0)
                        {
                            seleccion = 0;
                        }
                        else if (seleccion == 1)
                        {
                            seleccion = 1;
                        }
                        else if (seleccion == 2)
                        {
                            seleccion = 2;
                        }
                    }
                    else if (estado == 2)
                    {
                        estado = 11;
                    }
                    clienteSocket.Escribir(nroSerie + "|" + fecha + "|" + tipo + "|" + valor + "|" + estado + "|UPDATE");

                }
                else
                {
                    Console.WriteLine("Error al actualizar");
                    clienteSocket.Desconectar();
                }
            }
            else
            {
                Console.WriteLine("Error de conexion");
            }
        }
    }
}
