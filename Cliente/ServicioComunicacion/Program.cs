using ServicioComunicacion.Comunicacion;
using ServicioComunicacionModel.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacion
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            Thread t = new Thread(new ThreadStart(servidor.Iniciar));
            t.IsBackground = true;
            t.Start();
            {
                while (true)
                {
                    if (servidor.ObtenerCliente())
                    {
                        Console.WriteLine("La solicitud se ha recibido");
                        string mensaje = "";
                        {
                            mensaje = servidor.Leer();
                            string[] formatMensaje = mensaje.Split('|');
                            string fecha, nroMedidor, tipo;
                            fecha = formatMensaje[0];
                            nroMedidor = formatMensaje[1];
                            tipo = formatMensaje[2];
                            Console.WriteLine(fecha + "|" + nroMedidor + "|" + tipo);
                            int tipoInt = int.Parse(tipo);
                            if (tipoInt == 1)
                            {
                                if (validarFecha(fecha))
                                {
                                    servidor.Escribir(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");
                                    string actualizacion = servidor.Leer();
                                    Console.WriteLine(actualizacion);
                                    string[] formatActual = actualizacion.Split('|');
                                    string nroSerieLectura, fechaLectura, tipoLectura, valorLectura, estadoLectura;
                                    nroSerieLectura = formatActual[0];
                                    fechaLectura = formatActual[1];
                                    tipoLectura = formatActual[2];
                                    valorLectura = formatActual[3];
                                    estadoLectura = formatActual[4];
                                    Lectura l = new Lectura()
                                    {
                                        NroSerie = nroSerieLectura,
                                        Fecha = fechaLectura,
                                        Tipo = int.Parse(tipoLectura),
                                        Valor = valorLectura,
                                        Estado = estadoLectura

                                    };
                                    lock (lDAL)
                                    {
                                        lDAL.RegistrarLectura(l, "traficos.txt");
                                    }
                                    servidor.CerrarConexion();
                                }
                                else
                                {
                                    Console.WriteLine("Medidor no encontrado");
                                }
                            }
                            else if (tipoInt == 2)
                            {
                                if (validarFecha(fecha))
                                {
                                    servidor.Escribir(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");
                                    string actualizacion = servidor.Leer();
                                    Console.WriteLine(actualizacion);
                                    string[] formatActua = actualizacion.Split('|');
                                    string nro_Serie, fechaL, tipoL, valor, estado;
                                    nro_Serie = formatActua[0];
                                    fechaL = formatActua[1];
                                    tipoL = formatActua[2];
                                    valor = formatActua[3];
                                    estado = formatActua[4];
                                    Lectura l = new Lectura()
                                    {
                                        NroSerie = nro_Serie,
                                        Fecha = fechaL,
                                        Tipo = int.Parse(tipoL),
                                        Valor = valor,
                                        Estado = estado
                                    };
                                    lock (lDAL)
                                    {
                                        lDAL.RegistrarLectura(l, "consumos.txt");
                                    }
                                    servidor.CerrarConexion();
                                }
                                else
                                {
                                    Console.WriteLine("Medidor no encontrado");
                                }
                            }
                            else
                            {
                                Console.WriteLine("error en el tipo");
                            }
                        }
                    }
                }
            }   
        }
    }
}
