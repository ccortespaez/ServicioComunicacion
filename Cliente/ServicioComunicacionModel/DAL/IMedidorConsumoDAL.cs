﻿using ServicioComunicacionModel.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioComunicacionModel.DAL
{
    public interface IMedidorConsumoDAL
    { 
        List<MedidorConsumo> ObtenerMedidores();
    }
}
