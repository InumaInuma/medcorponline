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

        //public DataTable ObtenerAtencionesPorMesDataset()
        //{
        //    return datos.AtencionesPorMes();
        //}

        public List<AtencionMesEntity> ListarAtencionesMensualesB()
        {
            return datos.ObtenerAtencionesMensualesDB();
        }
        public List<AtencionesPorGenero> ListarAtencionesPorGeneroB()
        {
            return datos.ObtenerAtencionesPorGeneroDB();
        }

        public List<AtencionPorTipoEmo> ListarAtencionesPorTipoEmoB()
        {
            return datos.ObtenerAtencionesPorTipoEmoDB();
        }
        public List<AtencionesPorAptitud> ListarAtencionesPorTipoAptitudB()
        {
            return datos.ObtenerAtencionesPorTipoAptitudDB();
        }
        public List<AtendidosYNoAtendidos> ObtenerAtencionesPorTipoAtencionYNoAtendidosB()
        {
            return datos.ObtenerAtencionesPorTipoAtencionYNoAtendidosDB();
        }

        public List<Auditoria> ListarAuditoriaB(List<ClsOperador> lstWhere, List<ClsOperador> lstOrder)
        {
            return datos.ListarAuditoriaDB(lstWhere, lstOrder);
        }
        public List<Auditoria> ListarComboEmpresaB(List<ClsOperador> lstWhere, List<ClsOperador> lstOrder)
        {
            return datos.ListarComboEmpresaDB(lstWhere, lstOrder);
        }
        public List<Auditoria> ListarAtencionesFiltradasB(DateTime? fechaInicio, DateTime? fechaFin, int? codCli)
        {
            return datos.ListarAtencionesFiltradasDB(fechaInicio, fechaFin, codCli);
        }

        // 1. Método actualizado para listar atenciones con paginación
        // Ahora recibe el índice de página y el tamaño de página
        public List<Auditoria> ListarAtencionesFiltradasConPaginacionB(DateTime? fechaInicio, DateTime? fechaFin, int? codCli, int pageIndex, int pageSize)
        {
            return datos.ListarAtencionesFiltradasConPaginacionDB(fechaInicio, fechaFin, codCli, pageIndex, pageSize);
        }

        public int ContarAtencionesFiltradasB(DateTime? fechaInicio, DateTime? fechaFin, int? codCli)
        {
            return datos.ContarAtencionesFiltradasDB(fechaInicio, fechaFin, codCli);
        }
    }
}
