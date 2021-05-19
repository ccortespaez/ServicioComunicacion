using ServicioComunicacionModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAL
{
    public class MedidorConsumoDALArchivos : IMedidorConsumoDAL
    {
        private MedidorConsumoDALArchivos()
        {
        }
        private static IMedidorConsumoDAL instancia;

        public static IMedidorConsumoDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorConsumoDALArchivos();
            return instancia;
        }

        public List<MedidorConsumo> ObtenerMedidores()
        {
            List<MedidorConsumo> medidorConsumo = new List<MedidorConsumo>();
            MedidorConsumo mc1 = new MedidorConsumo(1, 1);
            MedidorConsumo mc2 = new MedidorConsumo(2, 2);
            MedidorConsumo mc3 = new MedidorConsumo(3, 3);
            MedidorConsumo mc4 = new MedidorConsumo(4, 4);
            medidorConsumo.Add(mc1);
            medidorConsumo.Add(mc2);
            medidorConsumo.Add(mc3);
            medidorConsumo.Add(mc4);
            return medidorConsumo;
        }
    }
}
