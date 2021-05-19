using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAO
{
    public class MedidorTrafico : Medidor
    {
        private int nroMedidor;

        public MedidorTrafico(int nroMedidor, int pId)
            : base(pId)
        {
            this.id = pId;
            this.NroMedidor = nroMedidor;
        }

        public int NroMedidor { get => nroMedidor; set => nroMedidor = value; }

        public override string ToString()
        {
            return id + ";" + NroMedidor;
        }



    }
}
