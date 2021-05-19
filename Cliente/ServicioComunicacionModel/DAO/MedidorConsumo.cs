using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAO
{
    public class MedidorConsumo : Medidor
    {
        private int nroMedidor;

        public MedidorConsumo(int nro_medidor, int pId)
            : base(pId)
        {
            this.id = pId;
            this.NroMedidor = nro_medidor;
        }

        public int NroMedidor { get => nroMedidor; set => nroMedidor = value; }

        public override string ToString()
        {
            return id + ";" + NroMedidor;
        }

    }
}
