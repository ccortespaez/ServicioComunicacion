using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAO
{
    public class TarifaElectrica
    {
        private string codigo;
        private string factor;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Factor { get => factor; set => factor = value; }
    }
}
