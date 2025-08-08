using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CAPA_ENTIDAD;
using CAPA_NEGOCIO;

namespace medcorponline
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected HtmlInputGenericControl fechaInicio;
        protected HtmlInputGenericControl fechaFin;
       
        reporteBL negocio = new reporteBL();

        // Literal para la tabla y la paginación
        //protected Literal litTabla;
        protected Literal litPaginacion;

        // Parámetros de paginación
        private const int pageSize = 15; // Ahora con 2 registros por página, según tu pedido
        private int pageIndex = 1; // Índice de página actual, comienza en 1

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                // 🚀 ¡CAMBIO AQUÍ! Establecemos la fecha de hoy por defecto para los inputs visualmente.
                fechaInicio.Value = DateTime.Now.ToString("yyyy-MM-dd");
                fechaFin.Value = DateTime.Now.ToString("yyyy-MM-dd");
                CargarEmpresas();
              
                CargarDatosGraficoBarra();

                CargarDatosGeneroTable();
                CargarDatosGeneroGrafico();

                CargarDatosTipoEmoTable();
                CargarDatosTipoEmoGraficos();

                CargarDatosTipoAptitudTable();
                CargarDatosTipoAptitudGraficos();

                CargarDatosTipoAtendidosYNoAtendidosTable();
                CargarDatosTipoAtendidosYNoAtendidosGraficos();
               
            }
            // 2. Cargar la tabla con los filtros, ya sea del ViewState o de la URL.
            CargarTablaFiltrada();
        }


        #region TABLA DE INICIO Y PAGINACION Y BOTON FILTRAR
        private void CargarTablaFiltrada()
        {
            DateTime? fechaInicioDT = null;
            DateTime? fechaFinDT = null;
            int idEmpresaSeleccionada = 0;
            string rutaPdf = ResolveUrl("~/pdf/dpf.pdf");

            // Leer los valores de los filtros directamente desde la URL.
            string fechaInicioStr = Request.QueryString["fechaInicio"];
            string fechaFinStr = Request.QueryString["fechaFin"];
            string idEmpresaStr = Request.QueryString["idEmpresa"];

            // 1. Leer los filtros de los CONTROLES HTML (no solo de la URL)
            // Esto asegura que se capture lo que el usuario ve en la página.
            string fechaInic = fechaInicio.Value;
            string fechaF = fechaFin.Value;
            string idEmpre = empresa.Value; // Asumiendo que 'empresa' es un HtmlSelect

            // Asignar los valores a los controles HTML para que se muestren en la interfaz.
            //fechaInicio.Value = fechaInicioStr ?? "";
            //fechaFin.Value = fechaFinStr ?? "";
            //empresa.Value = idEmpresaStr ?? "";

            // Limpiar mensaje de error anterior
            litMensajeError.Text = "";

            // Si hay filtros en la URL, los usamos. Si no, los campos de fecha se quedarán con los valores
            // que establecimos en el Page_Load, o los que el usuario haya seleccionado.
            fechaInicio.Value = fechaInicioStr ?? fechaInicio.Value;
            fechaFin.Value = fechaFinStr ?? fechaFin.Value;
            if (empresa != null)
            {
                empresa.Value = idEmpresaStr ?? "";
            }

            // Convertir los valores a los tipos correctos para la capa de negocio.
            if (!string.IsNullOrEmpty(fechaInicioStr) && DateTime.TryParse(fechaInicioStr, out DateTime tempFechaInicio))
            {
                fechaInicioDT = tempFechaInicio;
            }

            if (!string.IsNullOrEmpty(fechaFinStr) && DateTime.TryParse(fechaFinStr, out DateTime tempFechaFin))
            {
                fechaFinDT = tempFechaFin;
            }

            if (!string.IsNullOrEmpty(idEmpresaStr) && int.TryParse(idEmpresaStr, out int tempIdEmpresa))
            {
                idEmpresaSeleccionada = tempIdEmpresa;
            }

            // 🌟 ¡NUEVA VALIDACIÓN AQUÍ! 🌟
            // Validar que la fecha de inicio no sea mayor que la de fin.
            if (fechaInicioDT.HasValue && fechaFinDT.HasValue && fechaInicioDT.Value > fechaFinDT.Value)
            {
                litMensajeError.Text = "<br><div class='alert alert-danger' role='alert'>La fecha de inicio no puede ser mayor que la fecha de fin. Por favor, corrija las fechas.</div>";
                litTabla.Text = "";
                litPaginacion.Text = "";
                return; // Detenemos la ejecución del método si la validación falla
            }   

            // Leer el índice de página de la URL si existe.-
            if (int.TryParse(Request.QueryString["page"], out int page))
            {
                pageIndex = page;
            }
            else
            {
                pageIndex = 1;
            }

            // --- Lógica de Paginación ---
            int totalRecords = negocio.ContarAtencionesFiltradasB(fechaInicioDT, fechaFinDT, idEmpresaSeleccionada);
            // Calcular el total de páginas basado en el número total de registros y el tamaño de página.
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
           
            if (pageIndex < 1) pageIndex = 1;
            if (pageIndex > totalPages && totalPages > 0) pageIndex = totalPages;
                
            // Llamar al método de negocio con los parámetros de paginación.
            List<Auditoria> lista = negocio.ListarAtencionesFiltradasConPaginacionB(fechaInicioDT, fechaFinDT, idEmpresaSeleccionada, pageIndex, pageSize);

            StringBuilder sb = new StringBuilder();
            foreach (var item in lista)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.FecAte.ToString("dd/MM/yyyy"));
                sb.AppendFormat("<td>{0}</td>", item.Pacien);
                sb.AppendFormat("<td>{0}</td>", item.DesTCh);
                sb.AppendFormat("<td>{0}</td>", item.Actitud);
                //< td >< i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                //sb.Append("<td><i class='bi bi-file-earmark-excel fs-5 text-success'></i></td>");
                //sb.AppendFormat("<td><a href='{0}' target='_blank' download><i class='bi bi-file-earmark-pdf fs-5 text-danger'></i></a></td>", item.Pacien);
                // Suponiendo que item.RutaPdf ya contiene la ruta del certificado PDF
                //sb.AppendFormat("<td><a href='{0}' target='_blank'><i class='bi bi-file-earmark-pdf fs-5 text-danger'></i></a></td>", item.Pacien);
                // Botón PDF (abre en otra pestaña)
                // Botón que abre modal con el PDF
                // Botón que abre modal
                // Botón que llama a la función JS pasando la ruta del PDF
                sb.AppendFormat(
                    "<td><button type='button' class='btn btn-sm btn-danger' onclick=\"verPdf('{0}')\">📄<i class='bi bi-file-earmark-excel-fill'></i></button></td>",
                    rutaPdf
                );

               
                sb.Append("</tr>");
            }
            litTabla.Text = sb.ToString();

            // Generar paginación con los filtros actuales.
            GenerarPaginacion(totalPages, fechaInicioStr, fechaFinStr, idEmpresaStr);
        }

        private void GenerarPaginacion(int totalPages, string fechaInicio, string fechaFin, string idEmpresa)
        {
            if (totalPages <= 1)
            {
                litPaginacion.Text = "";
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class='pagination justify-content-center'>");

            fechaInicio = fechaInicio ?? "";
            fechaFin = fechaFin ?? "";
            idEmpresa = idEmpresa ?? "";

            string urlBase = $"Dashboard.aspx?fechaInicio={HttpUtility.UrlEncode(fechaInicio)}&fechaFin={HttpUtility.UrlEncode(fechaFin)}&idEmpresa={HttpUtility.UrlEncode(idEmpresa)}"; /* */

            string prevDisabled = (pageIndex == 1) ? "disabled" : "";
            sb.Append($"<li class='page-item {prevDisabled}'>");
            sb.Append($"<a class='page-link' href='{urlBase}&page={pageIndex - 1}' tabindex='-1' aria-disabled='true'>Anterior</a></li>");

            for (int i = 1; i <= totalPages; i++)
            {
                string activeClass = (i == pageIndex) ? "active" : "";
                sb.Append($"<li class='page-item {activeClass}'><a class='page-link' href='{urlBase}&page={i}'>{i}</a></li>");
            }

            string nextDisabled = (pageIndex == totalPages) ? "disabled" : "";
            sb.Append($"<li class='page-item {nextDisabled}'>");
            sb.Append($"<a class='page-link' href='{urlBase}&page={pageIndex + 1}'>Siguiente</a></li>");

            sb.Append("</ul>");

            litPaginacion.Text = sb.ToString();
        }

   

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Se leen los valores directamente de la colección Request.Form.
            // Esta es la forma más fiable de obtener los valores de los controles HTML
            // durante un postback en ASP.NET Web Forms.
            string fechaInicioValue = Request.Form[fechaInicio.UniqueID];
            string fechaFinValue = Request.Form[fechaFin.UniqueID];
            string idEmpresaValue = Request.Form[empresa.UniqueID];


            // Construir el URL de redirección con los nuevos filtros.
            string url = $"Dashboard.aspx?fechaInicio={HttpUtility.UrlEncode(fechaInicioValue)}&fechaFin={HttpUtility.UrlEncode(fechaFinValue)}&idEmpresa={HttpUtility.UrlEncode(idEmpresaValue)}&page=1";
            Response.Redirect(url);


        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            // 1. Leer los filtros de la URL (si existen).
            string fechaInicioStr = Request.QueryString["fechaInicio"];
            string fechaFinStr = Request.QueryString["fechaFin"];
            string idEmpresaStr = Request.QueryString["idEmpresa"];

            DateTime? fechaInicioDT = null;
            DateTime? fechaFinDT = null;
            int idEmpresaSeleccionada = 0;

            if (string.IsNullOrEmpty(fechaInicioStr) && string.IsNullOrEmpty(fechaFinStr) && string.IsNullOrEmpty(idEmpresaStr))
            {

               

                List<Auditoria> lista = negocio.ListarAtencionesFiltradasConPaginacionB(fechaInicioDT, fechaFinDT, idEmpresaSeleccionada, pageIndex, pageSize);

                // 3. Generar el archivo Excel.
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Atenciones_Medcorponline.csv");
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                StringBuilder sb = new StringBuilder();

                // Agregar encabezados de columna
                sb.Append("FECHA CITA;PACIENTE;TIPO DE ATENCION;APTITUD");
                sb.Append("\r\n");

                // Agregar datos
                foreach (var item in lista)
                {
                    // Limpiar los campos para evitar errores de formato en el CSV
                    string fechaCita = item.FecAte.ToString("dd/MM/yyyy");
                    string paciente = item.Pacien.Replace(";", ",");
                    string tipoAtencion = item.DesTCh.Replace(";", ",");
                    string aptitud = item.Actitud.Replace(";", ",");


                    sb.AppendFormat("{0};{1};{2};{3}", fechaCita, paciente, tipoAtencion, aptitud);
                    sb.Append("\r\n");
                }

                Response.Output.Write(sb.ToString());
                Response.Flush();
                Response.End();

            }
            else
            {

                if (!string.IsNullOrEmpty(fechaInicioStr) && DateTime.TryParse(fechaInicioStr, out DateTime tempFechaInicio))
                {
                    fechaInicioDT = tempFechaInicio;
                }

                if (!string.IsNullOrEmpty(fechaFinStr) && DateTime.TryParse(fechaFinStr, out DateTime tempFechaFin))
                {
                    fechaFinDT = tempFechaFin;
                }

                if (!string.IsNullOrEmpty(idEmpresaStr) && int.TryParse(idEmpresaStr, out int tempIdEmpresa))
                {
                    idEmpresaSeleccionada = tempIdEmpresa;
                }
                // 2. Obtener la lista COMPLETA de atenciones filtradas.
                //    Se debe usar un método de negocio que no aplique paginación.
                List<Auditoria> listaCompleta = negocio.ListarAtencionesFiltradasB(fechaInicioDT, fechaFinDT, idEmpresaSeleccionada);


                // 3. Generar el archivo Excel.
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Atenciones_Medcorponline.csv");
                Response.Charset = "UTF-8";
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                StringBuilder sb = new StringBuilder();

                // Agregar encabezados de columna
                sb.Append("FECHA CITA;PACIENTE;TIPO DE ATENCION;APTITUD");
                sb.Append("\r\n");

                // Agregar datos
                foreach (var item in listaCompleta)
                {
                    // Limpiar los campos para evitar errores de formato en el CSV
                    string fechaCita = item.FecAte.ToString("dd/MM/yyyy");
                    string paciente = item.Pacien.Replace(";", ",");
                    string tipoAtencion = item.DesTCh.Replace(";", ",");
                    string aptitud = item.Actitud.Replace(";", ",");


                    sb.AppendFormat("{0};{1};{2};{3}", fechaCita, paciente, tipoAtencion, aptitud);
                    sb.Append("\r\n");
                }

                Response.Output.Write(sb.ToString());
                Response.Flush();
                Response.End();
            }
       
        }
        #endregion

        #region GRAFICO DE BARRA 
        private void CargarDatosGraficoBarra()
        {
            int[] atencionesPorMes = new int[12]; // Arreglo con 12 posiciones (enero a diciembre)
            
            // Llama a la capa de negocio y trae una lista de objetos, cada uno con Mes y Cantidad
            List<AtencionMesEntity> lista = negocio.ListarAtencionesMensualesB();
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
        #endregion
        #region TABLA Y GRAFICO DE GENERO
        private void CargarDatosGeneroTable()
        {
            List<AtencionesPorGenero> lista = negocio.ListarAtencionesPorGeneroB();
            StringBuilder sb = new StringBuilder();

            foreach (var item in lista)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.Genero);
                sb.AppendFormat("<td>{0}</td>", item.Cantidad);
                sb.Append("</tr>");
            }
            // litTablaGenero donde insertar el HTML generado
            litTablaGenero.Text = sb.ToString();
        }
        private void CargarDatosGeneroGrafico()
        {
            List<AtencionesPorGenero> lista = negocio.ListarAtencionesPorGeneroB();
            //int masculino = lista.Where(x => x.Genero.ToUpper() == "M").Sum(x => x.Cantidad);
            //int femenino = lista.Where(x => x.Genero.ToUpper() == "F").Sum(x => x.Cantidad);
            int masculino = lista.FirstOrDefault(x => x.Genero.ToUpper() == "M")?.Cantidad ?? 0;
            int femenino = lista.FirstOrDefault(x => x.Genero.ToUpper() == "F")?.Cantidad ?? 0;

            hfMasculino.Value = masculino.ToString();
            hfFemenino.Value = femenino.ToString();
            //hfTotal.Value = total.ToString();
        }

        #endregion
        #region TABLA Y GRAFICO DE TIPOS DE EMO
        private void CargarDatosTipoEmoTable()
        {
            List<AtencionPorTipoEmo> lista = negocio.ListarAtencionesPorTipoEmoB();
            StringBuilder sb = new StringBuilder();

            foreach (var item in lista)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.TipoEMO);
                sb.AppendFormat("<td>{0}</td>", item.Total);
                sb.Append("</tr>");
            }
            // litTablaGenero donde insertar el HTML generado
            litTablaTipoEMO.Text = sb.ToString();
        }
        
        private void CargarDatosTipoEmoGraficos()
        {
            List<AtencionPorTipoEmo> lista = negocio.ListarAtencionesPorTipoEmoB();
            //int masculino = lista.Where(x => x.Genero.ToUpper() == "M").Sum(x => x.Cantidad);
            //int femenino = lista.Where(x => x.Genero.ToUpper() == "F").Sum(x => x.Cantidad);
            int pre = lista.FirstOrDefault(x => x.TipoEMO.ToUpper() == "PRE")?.Total ?? 0;
            int egreso = lista.FirstOrDefault(x => x.TipoEMO.ToUpper() == "EGRESO")?.Total ?? 0;
            int anual = lista.FirstOrDefault(x => x.TipoEMO.ToUpper() == "ANUAL")?.Total?? 0;

            hfTotal.Value = (pre + egreso + anual).ToString();

            hfPre.Value = pre.ToString();
            hfEgreso.Value = egreso.ToString();
            hfAnual.Value = anual.ToString();
                    
        }

        #endregion
        #region TABLA Y GRAFICO DE APTITUDES
        private void CargarDatosTipoAptitudTable()
        {
            List<AtencionesPorAptitud> lista = negocio.ListarAtencionesPorTipoAptitudB();
            StringBuilder sb = new StringBuilder();

            foreach (var item in lista)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.Aptitud);
                sb.AppendFormat("<td>{0}</td>", item.Total);
                sb.Append("</tr>");
            }
            // litTablaGenero donde insertar el HTML generado
            litTablaAptitudes.Text = sb.ToString();
        }
       
        private void CargarDatosTipoAptitudGraficos()
        {
            List<AtencionesPorAptitud> lista = negocio.ListarAtencionesPorTipoAptitudB();
            //int masculino = lista.Where(x => x.Genero.ToUpper() == "M").Sum(x => x.Cantidad);
            //int femenino = lista.Where(x => x.Genero.ToUpper() == "F").Sum(x => x.Cantidad);
            int apto = lista.FirstOrDefault(x => x.Aptitud.ToUpper() == "APTO")?.Total ?? 0;
            int aptores = lista.FirstOrDefault(x => x.Aptitud.ToUpper() == "APTO RES")?.Total ?? 0;
            int noapto = lista.FirstOrDefault(x => x.Aptitud.ToUpper() == "NO APTO")?.Total ?? 0;
            int observado = lista.FirstOrDefault(x => x.Aptitud.ToUpper() == "OBSERVADO")?.Total ?? 0;

            hfTotalApt.Value = (apto + aptores+ noapto + observado ).ToString();

            hfApto.Value = apto.ToString();
            hfAptoRes.Value = aptores.ToString();
            hfNoApto.Value = noapto.ToString();
            hfObservado.Value = observado.ToString();

        }
        #endregion
        #region TABLA Y GRAFICO DE ATENDIDOS Y NO ANTENDIDOS
        private void CargarDatosTipoAtendidosYNoAtendidosGraficos()
        {
            List<AtendidosYNoAtendidos> lista = negocio.ObtenerAtencionesPorTipoAtencionYNoAtendidosB();
            //int masculino = lista.Where(x => x.Genero.ToUpper() == "M").Sum(x => x.Cantidad);
            //int femenino = lista.Where(x => x.Genero.ToUpper() == "F").Sum(x => x.Cantidad);
            int noatendidos = lista.FirstOrDefault(x => x.EstadoAtencion.ToUpper() == "NO ATENDIDO")?.Total ?? 0;
            int atendido = lista.FirstOrDefault(x => x.EstadoAtencion.ToUpper() == "ATENDIDO")?.Total ?? 0;
           

            hfTotalATen.Value = (noatendidos + atendido).ToString();

            hfNoAtendidos.Value = noatendidos.ToString();
            hfAtendido.Value = atendido.ToString();
           

        }

        private void CargarDatosTipoAtendidosYNoAtendidosTable()
        {
            List<AtendidosYNoAtendidos> lista = negocio.ObtenerAtencionesPorTipoAtencionYNoAtendidosB();
            StringBuilder sb = new StringBuilder();

            foreach (var item in lista)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.EstadoAtencion);
                sb.AppendFormat("<td>{0}</td>", item.Total);
                sb.Append("</tr>");
            }
            // litTablaGenero donde insertar el HTML generado
            //litTablaAsistidos.Text = sb.ToString();
        }
        #endregion

        #region TABLA AUDITORIA Y COMBO DE EMPRESAS
        private void CargarEmpresas()
        {
            //METODO CARGAR CLIENTES =  EMPRESAS 
           var lista = negocio.ListarComboEmpresaB(new List<ClsOperador>(), new List<ClsOperador>());

            //Cuando hagas clic en "Buscar" o "Filtrar", puedes obtener el ID de la empresa seleccionada así:
            //int idEmpresaSeleccionada = string.IsNullOrEmpty(empresa.Value) ? 0 : Convert.ToInt32(empresa.Value);
            //var empresas = lista
            //.Where(a => a.CodCli != 0 && !string.IsNullOrWhiteSpace(a.NomCom))
            //.Select(a => new { a.CodCli, a.NomCom })
            //.Distinct()
            //.OrderBy(e => e.NomCom)
            //.ToList();

            empresa.Items.Clear();
            empresa.Items.Add(new ListItem("-- Todas --", ""));  // Sin filtro

            foreach (var e in lista)
            {
                //empresa.Items.Add(new ListItem(e, e));
                empresa.Items.Add(new ListItem(e.NomCom, e.CodCli.ToString()));
            }
        }

        //private void CargarTabla()
        //{
        //    List<Auditoria> lista = negocio.ListarAuditoriaB(new List<ClsOperador>(), new List<ClsOperador>());

        //    StringBuilder sb = new StringBuilder();

        //    foreach (var item in lista)
        //    {
        //        sb.Append("<tr>");
        //        sb.AppendFormat("<td>{0}</td>", item.FecAte.ToString("dd/MM/yyyy"));
        //        sb.AppendFormat("<td>{0}</td>", item.Pacien);
        //        sb.AppendFormat("<td>{0}</td>", item.DesTCh);
        //        sb.AppendFormat("<td>{0}</td>", item.Actitud);
        //        sb.Append("<td><i class='bi bi-file-earmark-excel fs-5 text-success'></i></td>");
        //        sb.Append("</tr>");
        //    }

        //    // Literal donde insertar el HTML generado
        //    litTabla.Text = sb.ToString();
        //}

        #endregion


        //private void CargarTablaFiltrada()
        //{
        //    DateTime? fechaInicioDT = null;
        //    DateTime? fechaFinDT = null;

        //    // Captura como string
        //    string fechaInicioStr = fechaInicio.Value;
        //    string fechaFinStr = fechaFin.Value;
        //    var idEmpresaSeleccionada = string.IsNullOrEmpty(empresa.Value) ? 0 : Convert.ToInt32(empresa.Value);
        //    // Valida y convierte
        //    if (!string.IsNullOrEmpty(fechaInicioStr))
        //    {
        //        fechaInicioDT = Convert.ToDateTime(fechaInicioStr);
        //    }

        //    if (!string.IsNullOrEmpty(fechaFinStr))
        //    {
        //        fechaFinDT = Convert.ToDateTime(fechaFinStr);
        //    }


        //    List<Auditoria> lista = negocio.ListarAtencionesFiltradasB(fechaInicioDT, fechaFinDT, idEmpresaSeleccionada);


        //    StringBuilder sb = new StringBuilder();

        //    foreach (var item in lista)
        //    {
        //        sb.Append("<tr>");
        //        sb.AppendFormat("<td>{0}</td>", item.FecAte.ToString("dd/MM/yyyy"));
        //        sb.AppendFormat("<td>{0}</td>", item.Pacien);
        //        sb.AppendFormat("<td>{0}</td>", item.DesTCh);
        //        sb.AppendFormat("<td>{0}</td>", item.Actitud);
        //        sb.Append("<td><i class='bi bi-file-earmark-excel fs-5 text-success'></i></td>");
        //        sb.Append("</tr>");
        //    }

        //    litTabla.Text = sb.ToString();



        //}

    }
}