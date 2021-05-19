using ServicioComunicacionModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAL
{
    public class MedidorTraficoDALArchivos : IMedidorTraficoDAL
    {
        private MedidorTraficoDALArchivos()
        {
        }

        private static IMedidorTraficoDAL instancia;

        public static IMedidorTraficoDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorTraficoDALArchivos();
            return instancia;
        }

        public List<MedidorTrafico> ObtenerMedidores()
        {
            List<MedidorTrafico> medidorTrafico = new List<MedidorTrafico>();
            MedidorTrafico mt1 = new MedidorTrafico(1, 001);
            MedidorTrafico mt2 = new MedidorTrafico(2, 002);
            MedidorTrafico mt3 = new MedidorTrafico(3, 003);
            MedidorTrafico mt4 = new MedidorTrafico(4, 004);
            medidorTrafico.Add(mt1);
            medidorTrafico.Add(mt2);
            medidorTrafico.Add(mt3);
            medidorTrafico.Add(mt4);
            return medidorTrafico;
        }

    }
}
