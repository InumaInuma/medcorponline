using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_ENTIDAD;

namespace CAPA_DATOS.Formato
{
    public class ClsFormato
    {
        private static string FormatoO(string pCampo, string pOperador, string pValor, string pAntesValor, string pDespuesValor)

        {

            string sQuery;

            switch (pOperador)

            {

                case ClsOperador.C_Empiece:

                    sQuery = string.Format("{0} LIKE '{1}%'", pCampo, pValor);

                    break;

                case ClsOperador.C_Termine:

                    sQuery = string.Format("{0} LIKE '%{1}'", pCampo, pValor);

                    break;

                case ClsOperador.C_Contenga:

                    sQuery = string.Format("{0} LIKE '%{1}%'", pCampo, pValor);

                    break;

                case ClsOperador.C_NoContenga:

                    sQuery = string.Format("{0} NOT LIKE '%{1}%'", pCampo, pValor);

                    break;

                case ClsOperador.C_Igual:

                    //sQuery = string.Empty + pCampo + " = " + pAntesValor + string.Format("'{0}'", "'" + pValor + "'") +

                    //         pDespuesValor;

                    sQuery = string.Format("{0} = {1}'{2}'{3}", pCampo, pAntesValor, pValor, pDespuesValor);

                    break;

                case ClsOperador.C_NoIgual:

                    sQuery = string.Format("{0} <> '{1}'", pCampo, pValor);

                    break;

                case ClsOperador.C_Mayor:

                    //sQuery = pValor.Trim().Length > 0

                    //    ? string.Empty + pCampo + " > " + pAntesValor + string.Format("'{0}'", "'" + pValor + "'") + pDespuesValor

                    //    : string.Empty + pCampo + " > " + pAntesValor;

                    sQuery = pValor.Trim().Length > 0

                        ? string.Format("{0} > {1}'{2}'{3}", pCampo, pAntesValor, pValor, pDespuesValor)

                        : string.Format("{0} > {1}", pCampo, pAntesValor);

                    break;

                case ClsOperador.C_MayorIgual:

                    //sQuery = string.Empty + pCampo + " >= " + pAntesValor + string.Format("'{0}'", "'" + pValor + "'") +

                    //         pDespuesValor;

                    sQuery = string.Format("{0} >= {1}'{2}'{3}", pCampo, pAntesValor, pValor, pDespuesValor);

                    break;

                case ClsOperador.C_Menor:

                    //sQuery = string.Empty + pCampo + " < " + pAntesValor + string.Format("'{0}'", "'" + pValor + "'") +

                    //         pDespuesValor;

                    sQuery = string.Format("{0} < {1}'{2}'{3}", pCampo, pAntesValor, pValor, pDespuesValor);

                    break;

                case ClsOperador.C_MenorIgual:

                    //sQuery = string.Empty + pCampo + " <= " + pAntesValor + string.Format("'{0}'", "'" + pValor + "'") +

                    //         pDespuesValor;

                    sQuery = string.Format("{0} <= {1}'{2}'{3}", pCampo, pAntesValor, pValor, pDespuesValor);

                    break;

                case ClsOperador.C_Incluya:

                    sQuery = string.Format(" {0} IN ({1})", pCampo, pValor);

                    break;

                case ClsOperador.C_NoIncluya:

                    sQuery = string.Format(" {0} NOT IN ({1})", pCampo, pValor);

                    break;

                case ClsOperador.C_ISNULL:

                    sQuery = string.Format(" {0} IS NULL", pCampo);

                    break;

                case ClsOperador.C_ISNOTNULL:

                    sQuery = string.Format(" {0} IS NOT NULL", pCampo);

                    break;

                case ClsOperador.C_EsVacio:

                    sQuery = string.Format(" RTRIM(LTRIM(ISNULL(CONVERT(VARCHAR,{0}),''))) = ''", pCampo);

                    break;

                default:

                    sQuery = string.Format("{0} LIKE '{1}%'", pCampo, pValor);

                    break;

            }

            return sQuery;

        }



        public static string RetornaWhere(List<ClsOperador> lstWhere)

        {
            //si no envia nada
            if (lstWhere == null || lstWhere.Count == 0)
                return "1=1"; // ← Condición por defecto para evitar errores


            string sWhere = string.Empty;

            lstWhere.ForEach(o =>

            {

                string sAddString = FormatoO(o.NomCampo, o.Operador, o.Valor, o.AntesValor, o.DespuesValor);

                sWhere = sWhere == string.Empty ? sAddString : string.Format("{0} AND {1}", sWhere, sAddString);

            });

            return sWhere;

        }



        public static string RetornaOrder(List<ClsOperador> lstOrder)

        {

            string sOrder = string.Empty;

            lstOrder.ForEach(o => sOrder = sOrder == string.Empty ? o.Ordernado : string.Format("{0},{1}", sOrder, o.Ordernado));

            return sOrder;

        }



        #region Nullable



        public static T? DbValueToNullable<T>(Object dbValue) where T : struct

        {

            T? returnValue = null;

            if (dbValue != null && !dbValue.Equals(DBNull.Value))

                returnValue = (T)dbValue;

            return returnValue;

        }



        #endregion
    }
}
