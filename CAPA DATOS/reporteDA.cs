using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS.Formato;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class reporteDA
    {
        private readonly string _sCn;
        public reporteDA()
        {
            _sCn = Conexion.ObtenerCadenaConexion();
        }
        public DataTable AtencionesPorMes()
        {
            var adapter = new DsGraficosTableAdapters.sp_AtencionesPorMesTableAdapter();
            return adapter.GetData();
        }

        public List<AtencionMesEntity> ObtenerAtencionesMensuales()
        {
            List<AtencionMesEntity> lista = new List<AtencionMesEntity>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AtencionesPorMes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new AtencionMesEntity
                    {
                        Mes = Convert.ToInt32(dr["Mes"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"])
                    });
                }
            }

            return lista;
        }

        public List<AtencionesPorGenero> ObtenerAtencionesPorGenero()
        {
            List<AtencionesPorGenero> lista = new List<AtencionesPorGenero>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Genero", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new AtencionesPorGenero
                    {
                        Genero = Convert.ToString(dr["Genero"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"])
                    });
                }
            }

            return lista;
        }

        public List<Auditoria> ListarFichaEspaciosConfinadosDB(List<ClsOperador> lstWhere,
           List<ClsOperador> lstOrder)
        {
            List<Auditoria> auditorias = new List<Auditoria>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {
                string sWhere = ClsFormato.RetornaWhere(lstWhere);
                string sOrder = ClsFormato.RetornaOrder(lstOrder);

                db.ConectarDB();


                db.CrearComando("SP_AUDITORIA", CommandType.StoredProcedure);

                db.AgregarParametros("@WHERE", sWhere);
                db.AgregarParametros("@ORDER", sOrder);

                using (DbDataReader drDatos = db.EjecutarConsulta())
                {
                    while (drDatos.Read())
                    {
                        auditorias.Add(new Auditoria
                        {

                            FecAte = drDatos["FecAte"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drDatos["FecAte"]),
                            Pacien = drDatos["NomPer"]?.ToString().Trim(),
                            DesTCh = drDatos["DesTCh"]?.ToString().Trim(),

                            Actitud = drDatos["ConDic"]?.ToString().Trim(),
                   

                          
                        });
                    }
                }


            }
            catch (BaseDatosException ex)
            {
                throw new BaseDatosException(ex.Message);
            }
            finally
            {
                db.DesconectarDB();
            }
            return auditorias;
        }

    }
}
