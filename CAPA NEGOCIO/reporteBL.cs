using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_NEGOCIO
{
    public class reporteBL
    {
        private reporteDA datos = new reporteDA();

        public DataTable ObtenerAtencionesPorMesDataset()
        {
            return datos.AtencionesPorMes();
        }

        public List<AtencionMesEntity> ListarAtencionesMensuales()
        {
            return datos.ObtenerAtencionesMensuales();
        }
        public List<AtencionesPorGenero> ListarAtencionesPorGenero()
        {
            return datos.ObtenerAtencionesPorGenero();
        }

        public List<Auditoria> ListarFichaEspaciosConfinadosB(List<ClsOperador> lstWhere, List<ClsOperador> lstOrder)
        {
            return datos.ListarFichaEspaciosConfinadosDB(lstWhere, lstOrder);
        }
    }
}
