using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAPA_ENTIDAD;
using CAPA_NEGOCIO;

namespace medcorponline
{
    public partial class Dashboard : System.Web.UI.Page
    {
        reporteBL negocio = new reporteBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosGrafico();
                CargarDatosGenero();
            }
        }
        private void CargarDatosGrafico()
        {
            int[] atencionesPorMes = new int[12]; // Arreglo con 12 posiciones (enero a diciembre)
            
            // Llama a la capa de negocio y trae una lista de objetos, cada uno con Mes y Cantidad
            List<AtencionMesEntity> lista = negocio.ListarAtencionesMensuales();
            int i = 0;
            foreach (var item in lista)
            {
               
                int mes = item.Mes; // Ejemplo: mes = 3 (marzo)
                int cantidad = item.Cantidad; // Ejemplo: cantidad = 25
                atencionesPorMes[i] = item.Cantidad;
                i++;


            }
            // Convierte el arreglo en un string separado por comas: "10,15,25,0,..."
            hfData.Value = string.Join(",", atencionesPorMes);

            
        }

        private void CargarDatosGenero()
        {
            List<AtencionesPorGenero> lista = negocio.ListarAtencionesPorGenero();
            List<Auditoria> listaOrdenada = negocio.ListarFichaEspaciosConfinadosB(new List<ClsOperador>(), new List<ClsOperador>());

            //int masculino = lista.Where(x => x.Genero.ToUpper() == "M").Sum(x => x.Cantidad);
            //int femenino = lista.Where(x => x.Genero.ToUpper() == "F").Sum(x => x.Cantidad);
            int masculino = lista.FirstOrDefault(x => x.Genero.ToUpper() == "M")?.Cantidad ?? 0;
            int femenino = lista.FirstOrDefault(x => x.Genero.ToUpper() == "F")?.Cantidad ?? 0;

            hfMasculino.Value = masculino.ToString();
            hfFemenino.Value = femenino.ToString();
            //hfTotal.Value = total.ToString();
        }


    }
}