using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class BaseDatosException : Exception
    {
        public BaseDatosException(string mensaje) : base(mensaje) { }
    }
}
