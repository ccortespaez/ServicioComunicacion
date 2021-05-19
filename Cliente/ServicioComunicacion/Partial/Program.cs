using ServicioComunicacionModel.DAL;
using ServicioComunicacionModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacion
{
    public partial class Program
    {
        static ILecturaDAL lDAL = LecturaFactory.CreateDal();
        static IMedidorConsumoDAL mcDAL = MedidorConsumoFactory.CreateDal();
        static IMedidorTraficoDAL mtDAL = MedidorTraficoFactory.CreateDal();

        static Boolean validarFecha(string fecha)
        {
            DateTime formatoFecha = DateTime.Parse(fecha);
            TimeSpan diferencia = formatoFecha - DateTime.Now;
            double diferenciaMinutos = diferencia.TotalMinutes;
            if (diferenciaMinutos < 30 || diferenciaMinutos > 30)
            {
                return true;
            }
            else
            {
                Console.WriteLine(diferenciaMinutos); Console.WriteLine(diferenciaMinutos);
                return false;
            }
        }
    }
}
