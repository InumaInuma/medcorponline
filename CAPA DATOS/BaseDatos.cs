using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class BaseDatos
    {
        private string _cadenaConexion;
        private SqlConnection _conexion;
        private SqlTransaction _transaccion;
        private SqlCommand _comando;

        // constructor que recibe la cadena de conexion
        public BaseDatos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _conexion = new SqlConnection(_cadenaConexion);
        }

        // metodo para abrir la conexión a la base de datos
        public void ConectarDB()
        {
            try
            {
                if (_conexion.State != ConnectionState.Open)
                {
                    _conexion.Open(); // Abrimos la conexión
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        // metodo para comenzar una transacción
        public void ComenzarTransaccion()
        {
            try
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _transaccion = _conexion.BeginTransaction(); // Iniciamos la transacción
                }
                else
                {
                    throw new BaseDatosException("La conexion a la base de datos no esta abierta.");
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al comenzar la transaccion: " + ex.Message);
            }
        }

        // metodo para crear un procedimiento almacenado sp en el comando sql
        public void CrearStoreProc(string nombreSp)
        {
            try
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _comando = new SqlCommand(nombreSp, _conexion);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Transaction = _transaccion; // Asignamos la transacción al comando
                }
                else
                {
                    throw new BaseDatosException("La conexion a la base de datos no está abierta.");
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al crear el comando para el procedimiento almacenado: " + ex.Message);
            }
        }

        // metodo para agregar un parámetro al comando
        public void AgregarParametro(DbType tipo, string nombreParametro, object valor, bool esSalida)
        {
            try
            {
                if (_comando == null)
                {
                    throw new BaseDatosException("El comando Sql no ha sido inicializado.");
                }

                SqlParameter parametro = new SqlParameter(nombreParametro, tipo)
                {
                    Value = valor ?? DBNull.Value, // Si el valor es null, asignamos DBNull.Value
                    Direction = esSalida ? ParameterDirection.Output : ParameterDirection.Input
                };

                _comando.Parameters.Add(parametro); // Agregar el parámetro al comando
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al agregar el parametro: " + ex.Message);
            }
        }

        //agregar parametro para mi lista 
        public void AgregarParametros(string nombre, object valor)
        {
            var parametro = _comando.CreateParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor ?? DBNull.Value;
            _comando.Parameters.Add(parametro);
        }

        // metodo para ejecutar el comando sql
        public void EjecutarComando()
        {
            try
            {
                if (_comando != null)
                {
                    _comando.ExecuteNonQuery(); // ejecutar el comando (procedimiento almacenado)
                }
                else
                {
                    throw new BaseDatosException("El comando Sql no ha sido inicializado.");
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al ejecutar el comando: " + ex.Message);
            }
        }


        // metodo para confirmar la transaccion
        public void ConfirmarTransaccion()
        {
            try
            {
                if (_transaccion != null)
                {
                    _transaccion.Commit(); // confirmar la transaccion
                }
                else
                {
                    throw new BaseDatosException("No se ha iniciado ninguna transaccion.");
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al confirmar la transaccion: " + ex.Message);
            }
        }

        // metodo para deshacer la transaccion
        public void DeshacerTransaccion()
        {
            try
            {
                if (_transaccion != null)
                {
                    _transaccion.Rollback(); // deshacer la transaccion en caso de error
                }
                else
                {
                    throw new BaseDatosException("No se ha iniciado ninguna transaccion.");
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al deshacer la transaccion: " + ex.Message);
            }
        }

        // metodo para cerrar la conexion
        public void DesconectarDB()
        {
            try
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close(); // cerrar la conexion
                }
            }
            catch (SqlException ex)
            {
                throw new BaseDatosException("Error al cerrar la conexionn: " + ex.Message);
            }
        }
        //en el caso que mandemos un string como consulta ala base datos se usa el CommandType.Text
        public void CrearComando(string nombreProcedimiento, CommandType tipoComando = CommandType.StoredProcedure)
        {
            try
            {
                _comando = _conexion.CreateCommand();
                _comando.CommandText = nombreProcedimiento;
                _comando.CommandType = tipoComando;
                _comando.Connection = _conexion;
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("Error al crear el comando: " + ex.Message);
            }
        }
        //Ejecutar consulta y devolver un DbDataReader
        public DbDataReader EjecutarConsulta()
        {
            try
            {
                if (_comando == null)
                    throw new BaseDatosException("El comando no ha sido creado.");

                return _comando.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new BaseDatosException("Error al ejecutar la consulta: " + ex.Message);
            }
        }
    }

}
