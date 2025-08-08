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
        //public DataTable AtencionesPorMes()
        //{
        //    var adapter = new DsGraficosTableAdapters.sp_AtencionesPorMesTableAdapter();
        //    return adapter.GetData();
        //}

        public List<AtencionMesEntity> ObtenerAtencionesMensualesDB()
        {
            List<AtencionMesEntity> lista = new List<AtencionMesEntity>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {
                db.ConectarDB();
                db.CrearComando("sp_AtencionesPorMes", CommandType.StoredProcedure);
                using (DbDataReader dr = db.EjecutarConsulta())
                {
                    while (dr.Read())
                    {
                        lista.Add(new AtencionMesEntity
                        {    
                            Mes = Convert.ToInt32(dr["Mes"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"])
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            return lista;
        }
        public List<AtencionesPorGenero> ObtenerAtencionesPorGeneroDB()
        {
            List<AtencionesPorGenero> lista = new List<AtencionesPorGenero>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {

                db.ConectarDB();
                db.CrearComando("sp_Genero", CommandType.StoredProcedure);
                    using (DbDataReader dr = db.EjecutarConsulta())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new AtencionesPorGenero
                            {
                                Genero = Convert.ToString(dr["Genero"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"])
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


            return lista;
        }
        public List<AtencionPorTipoEmo> ObtenerAtencionesPorTipoEmoDB()
        {
            List<AtencionPorTipoEmo> lista = new List<AtencionPorTipoEmo>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {

                db.ConectarDB();
                db.CrearComando("SP_EMO", CommandType.StoredProcedure);
                using (DbDataReader dr = db.EjecutarConsulta())
                {
                    while (dr.Read())
                    {
                        lista.Add(new AtencionPorTipoEmo
                        {
                            TipoEMO = Convert.ToString(dr["TipoEMO"]),
                            Total = Convert.ToInt32(dr["Total"])
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


            return lista;
        }
        public List<AtencionesPorAptitud> ObtenerAtencionesPorTipoAptitudDB()
        {
            List<AtencionesPorAptitud> lista = new List<AtencionesPorAptitud>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {

                db.ConectarDB();
                db.CrearComando("sp_Aptitud", CommandType.StoredProcedure);
                using (DbDataReader dr = db.EjecutarConsulta())
                {
                    while (dr.Read())
                    {
                        lista.Add(new AtencionesPorAptitud
                        {
                            Aptitud = Convert.ToString(dr["Aptitud"]),
                            Total = Convert.ToInt32(dr["Total"])
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


            return lista;
        }

        public List<AtendidosYNoAtendidos> ObtenerAtencionesPorTipoAtencionYNoAtendidosDB()
        {
            List<AtendidosYNoAtendidos> lista = new List<AtendidosYNoAtendidos>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {

                db.ConectarDB();
                db.CrearComando("SP_ATENCIONES", CommandType.StoredProcedure);
                using (DbDataReader dr = db.EjecutarConsulta())
                {
                    while (dr.Read())
                    {
                        lista.Add(new AtendidosYNoAtendidos
                        {
                            EstadoAtencion = Convert.ToString(dr["EstadoAtencion"]),
                            Total = Convert.ToInt32(dr["Total"])
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


            return lista;
        }

        public List<Auditoria> ListarAuditoriaDB(List<ClsOperador> lstWhere,
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
                            // Para DateTime (tipo de valor no anulable): Tu solución actual es buena.
                            // Si FecAte puede ser null en la BD y quieres que tu propiedad sea DateTime?, usa la otra forma.
                            FecAte = drDatos["FecAte"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drDatos["FecAte"]),
                            // Para string (tipo de referencia):
                            // Si es DBNull.Value, asigna null. De lo contrario, convierte a string y recorta.
                            Pacien = drDatos["NomPer"] == DBNull.Value ? null : drDatos["NomPer"].ToString().Trim(),
                            DesTCh = drDatos["DesTCh"] == DBNull.Value ? null : drDatos["DesTCh"].ToString().Trim(),
                            Actitud = drDatos["ConDic"] == DBNull.Value ? null : drDatos["ConDic"].ToString().Trim(),
                            CodCli = drDatos["CodCli"] == DBNull.Value ? 0 : Convert.ToInt32(drDatos["CodCli"]), // Asumiendo que CodCli es un int no anulable
                            NomCom = drDatos["NomCom"] == DBNull.Value ? null : drDatos["NomCom"].ToString().Trim(),
                            // Ejemplo para un int (tipo de valor no anulable)
                            // Id = drDatos["Id"] == DBNull.Value ? 0 : Convert.ToInt32(drDatos["Id"]),

                            // Ejemplo para un int? (tipo de valor anulable)
                            // Cantidad = drDatos["Cantidad"] == DBNull.Value ? (int?)null : Convert.ToInt32(drDatos["Cantidad"]),

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

        public List<Auditoria> ListarComboEmpresaDB(List<ClsOperador> lstWhere,
         List<ClsOperador> lstOrder)
        {
            List<Auditoria> auditorias = new List<Auditoria>();
            BaseDatos db = new BaseDatos(_sCn);
            try
            {
                string sWhere = ClsFormato.RetornaWhere(lstWhere);
                string sOrder = ClsFormato.RetornaOrder(lstOrder);

                db.ConectarDB();


                db.CrearComando("SP_COMBO_EMPRESA", CommandType.StoredProcedure);

                db.AgregarParametros("@WHERE", sWhere);
                db.AgregarParametros("@ORDER", sOrder);

                using (DbDataReader drDatos = db.EjecutarConsulta())
                {
                    while (drDatos.Read())
                    {
                        auditorias.Add(new Auditoria
                        {
                            CodCli = drDatos["CodCli"] == DBNull.Value ? 0 : Convert.ToInt32(drDatos["CodCli"]), // Asumiendo que CodCli es un int no anulable
                            NomCom = drDatos["NomCom"] == DBNull.Value ? null : drDatos["NomCom"].ToString().Trim(),
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

        public List<Auditoria> ListarAtencionesFiltradasDB(DateTime? fechaInicio, DateTime? fechaFin, int? codCli)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_LISTAR_FILTROFECHA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value;
                    cmd.Parameters.Add("@CodCli", SqlDbType.Int).Value = codCli.HasValue ? (object)codCli.Value : DBNull.Value;

                    conn.Open();
                    using (SqlDataReader drDatos = cmd.ExecuteReader())
                    {
                        while (drDatos.Read())
                        {
                            var atencion = new Auditoria
                            {
                                FecAte = drDatos["FecAte"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drDatos["FecAte"]),

                                // Para string (tipo de referencia):
                                // Si es DBNull.Value, asigna null. De lo contrario, convierte a string y recorta.
                                Pacien = drDatos["NomPer"] == DBNull.Value ? null : drDatos["NomPer"].ToString().Trim(),
                                DesTCh = drDatos["DesTCh"] == DBNull.Value ? null : drDatos["DesTCh"].ToString().Trim(),
                                Actitud = drDatos["ConDic"] == DBNull.Value ? null : drDatos["ConDic"].ToString().Trim(),
                                CodCli = drDatos["CodCli"] == DBNull.Value ? 0 : Convert.ToInt32(drDatos["CodCli"]), // Asumiendo que CodCli es un int no anulable
                                NomCom = drDatos["NomCom"] == DBNull.Value ? null : drDatos["NomCom"].ToString().Trim(),
                            };

                            lista.Add(atencion);
                        }
                    }
                }
            }

            return lista;
        }


         //1. Método actualizado para listar atenciones con paginación

        public List<Auditoria> ListarAtencionesFiltradasConPaginacionDB(DateTime? fechaInicio, DateTime? fechaFin, int? codCli, int pageIndex, int pageSize)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_LISTAR_ATENCIONES_FILTROFECHA_PAGINADO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value;
                    cmd.Parameters.Add("@CodCli", SqlDbType.Int).Value = codCli.HasValue ? (object)codCli.Value : DBNull.Value;
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                    conn.Open();
                    using (SqlDataReader drDatos = cmd.ExecuteReader())
                    {
                        while (drDatos.Read())
                        {
                            var atencion = new Auditoria
                            {
                                FecAte = drDatos["FecAte"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(drDatos["FecAte"]),
                                Pacien = drDatos["NomPer"] == DBNull.Value ? null : drDatos["NomPer"].ToString().Trim(),
                                DesTCh = drDatos["DesTCh"] == DBNull.Value ? null : drDatos["DesTCh"].ToString().Trim(),
                                Actitud = drDatos["ConDic"] == DBNull.Value ? null : drDatos["ConDic"].ToString().Trim(),
                                CodCli = drDatos["CodCli"] == DBNull.Value ? 0 : Convert.ToInt32(drDatos["CodCli"]),
                                NomCom = drDatos["NomCom"] == DBNull.Value ? null : drDatos["NomCom"].ToString().Trim(),
                            };
                            lista.Add(atencion);
                        }
                    }
                }
            }
            return lista;
        }

        public int ContarAtencionesFiltradasDB(DateTime? fechaInicio, DateTime? fechaFin, int? codCli)
        {
            int totalRecords = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_CONTAR_ATENCIONES_FILTROFECHA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value;
                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value;
                    cmd.Parameters.Add("@CodCli", SqlDbType.Int).Value = codCli.HasValue ? (object)codCli.Value : DBNull.Value;

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalRecords = Convert.ToInt32(result);
                    }
                }
            }
            return totalRecords;
        }

    }
}
