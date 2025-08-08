using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_ENTIDAD
{
    public class Auditoria
    {
        public DateTime FecAte { get; set; }
        public string Pacien{ get; set; }
        public string DesTCh { get; set; }
        public string Actitud { get; set; }
        public int CodCli { get; set; }
        public string NomCom { get; set; }
    }
}
