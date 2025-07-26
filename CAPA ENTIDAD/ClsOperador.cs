using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class ClsOperador
    {
        public const string C_Empiece = "Empiece";

        public const string C_Termine = "Termine";

        public const string C_Contenga = "Contenga";

        public const string C_NoContenga = "NoContenga";

        public const string C_Igual = "Igual";

        public const string C_NoIgual = "NoIgual";

        public const string C_Mayor = "Mayor";

        public const string C_MayorIgual = "MayorIgual";

        public const string C_Menor = "Menor";

        public const string C_MenorIgual = "MenorIgual";

        public const string C_Incluya = "Incluya";

        public const string C_NoIncluya = "No Incluya";

        public const string C_ISNULL = "IsNull";

        public const string C_ISNOTNULL = "IsNotNull";

        public const string C_EsVacio = "EsVacio";



        public ClsOperador()

        {

            NomCampo = string.Empty;

            Operador = string.Empty;

            AntesValor = string.Empty;

            DespuesValor = string.Empty;

            Valor = string.Empty;

            Ordernado = string.Empty;

        }



        public string NomCampo { get; set; }

        public string Operador { get; set; }

        public string Valor { get; set; }

        public string AntesValor { get; set; }

        public string DespuesValor { get; set; }

        public string Ordernado { get; set; }
    }
}
