<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="medcorponline.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  <!-- NAVBAR solo visible en pantallas pequeñas y medianas -->
  <nav class="navbar navbar-dark bg-dark d-lg-none">
    <div class="container-fluid">
      <span class="navbar-brand">Mi Panel</span>
      <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#sidebarOffcanvas">
        <span class="navbar-toggler-icon"></span>
      </button>
    </div>
  </nav>

  <!-- SIDEBAR como OFFCANVAS para pantallas medianas y pequeñas -->
  <div class="offcanvas offcanvas-start bg-dark text-white d-lg-none" tabindex="-1" id="sidebarOffcanvas">
    <div class="offcanvas-header">
      <h5 class="offcanvas-title">Mi Panel</h5>
      <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas"></button>
    </div>
    <div class="offcanvas-body">
      <ul class="nav flex-column">
        <li class="nav-item">
          <a href="#" class="nav-link text-white">Inicio</a>
        </li>
        <li class="nav-item">
          <a href="#" class="nav-link text-white">Dashboard</a>
        </li>
        <li class="nav-item">
          <a href="#" class="nav-link text-white">Reportes</a>
        </li>
      </ul>
    </div>
  </div>

  <div class="d-flex" id="wrapper">
      <div id="sidebar" class="bg-dark text-white p-3 d-none d-lg-block">
            <h4 class="text-center">Mi Panel</h4>
            <ul class="nav flex-column">
                <li class="nav-item">
                    <a href="#" class="nav-link text-white">Inicio</a>
                </li>
                <li class="nav-item">
                    <a href="#" class="nav-link text-white">Dashboard</a>
                </li>
                <li class="nav-item">
                    <a href="#" class="nav-link text-white">Reportes</a>
                </li>
            </ul>
        </div>
    <!-- Contenido principal -->
    <div id="content" class="container-fluid px-0">
      <div class="d-lg-flex">

       
        <div class="col-12 p-3">
               <!-- 🔍 Filtros -->

                    <div class="filtros-header">
                        <!-- 🧠 FILTROS HEADER Bootstrap -->
                        <div class="row g-3 align-items-end mb-2">
                            <div class="col-md-3">
                                <label for="fechaInicio" class="form-label">Desde</label>
                                 <!-- Usamos ClientIDMode="Static" para que el ID sea exactamente "fechaInicio" -->
                                <input type="date" class="form-control"  id="fechaInicio"  runat="server" name="fechaInicio" >
                            </div>

                            <div class="col-md-3">
                                <label for="fechaFin" class="form-label">Hasta</label>
                                <!-- Usamos ClientIDMode="Static" para que el ID sea exactamente "fechaFin" -->
                                <input type="date" class="form-control"  id="fechaFin"  runat="server" name="fechaFin" >
                            </div>

                            <div class="col-md-2">
                                <label for="empresa" class="form-label">Empresa</label>
                                <select class="form-select" id="empresa" runat="server">
                                       <option value="">-- Todas --</option>
                                </select>
                            </div>

                            <div class="col-md-2 d-grid">
                               <%-- <button class="btn btn-success" onclick="Filtrar()">📥 FILTRO</button>--%>
                                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="🔍 BUSCAR" OnClick="btnFiltrar_Click" />

                            </div>
                            <div class="col-md-2 d-grid">
                              <%-- <button class="btn btn-success" onclick="Filtrar()">📥 FILTRO</button>--%>
                                  <asp:Button ID="btnExportar" runat="server" CssClass="btn btn-success" Text="📄 EXPORTAR" OnClick="btnExportar_Click" />
                           
                           </div>
                            <!-- Contenedor para el mensaje de error de validación -->
                           <div class="row">
                               <div class="col-12">
                                   <asp:Literal ID="litMensajeError" runat="server"></asp:Literal>
                               </div>
                           </div>
                        </div>
                        
                    </div>

            <!-- INICIO TABLA -->
                    <div class="row mb-4">
                        <div class="col-12">
                            <div class="card card-kpi">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">Listado de Atenciones</h5>
                                    </div>
                                    <div class="table-responsive">
                                        <table class="table table-hover table-bordered text-center">
                                            <thead class="table-primary">
                                                <tr>
                                                    <th>Fecha Cita</th>
                                                    <th>Paciente</th>
                                                    <th>Tipo de Atención</th>
                                                    <th>Aptitud</th>
                                                    <th>Certificado</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <!-- Aquí se renderizan las filas dinámicas (<tr>...</tr>) -->
                                                 <asp:Literal ID="litTabla" runat="server"></asp:Literal>
                                                <!-- Puedes agregar más filas aquí <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td> -->
                                            </tbody>

                                        </table>
                                    </div>

                                    <!-- PAGINACIÓN -->
                                    <nav aria-label="Paginación de ejemplo" class="mt-4">
                                       <%-- <ul class="pagination justify-content-center">
                                            <li class="page-item disabled">
                                                <a class="page-link" href="#" tabindex="-1"
                                                    aria-disabled="true">Anterior</a>
                                            </li>
                                            <li class="page-item active"><a class="page-link" href="#">1</a></li>
                                            <li class="page-item"><a class="page-link" href="#">2</a></li>
                                            <li class="page-item"><a class="page-link" href="#">3</a></li>
                                            <li class="page-item"><a class="page-link" href="#">4</a></li>
                                            <li class="page-item">
                                                <a class="page-link" href="#">Siguiente</a>
                                            </li>
                                        </ul>--%>
                                      <%--  <asp:Literal ID="litPaginacion" runat="server"></asp:Literal>--%>
                                        <!-- Aquí se renderiza la paginación generada en el código-behind -->
                                            <asp:Literal ID="litPaginacion" runat="server"></asp:Literal>

                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN TABLA -->
             <h2 class="mb-4 text-center bg-primary text-white"> DASHBOARD DE ATENCIONES MEDICAS</h2>
            <!-- HiddenField con datos -->
                     <asp:HiddenField ID="hfData" runat="server" />
                    
                    
                    <div class="row mb-4">
                        <!-- Barras por mes -->
                        <div class="col-md-12 ">
                            <div class="card card-kpi">
                                <div class="card-body">
                                       <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                          <h5 class="card-title mb-0">ATENCIONES POR MES</h5>
                                       </div>
                                    <%--<canvas id="barrasMesChart" class="grafico-ancho"></canvas>--%>
                                     
                                         <canvas id="barrasMesChart" class="grafico-ancho"></canvas>
                                </div>
                            </div>
                        </div>
                    </div>


         
            <asp:HiddenField ID="hfMasculino" runat="server" />
            <asp:HiddenField ID="hfFemenino" runat="server" />
         
                    <!-- GENERO -->
                   <%-- <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">GÉNERO</h5>
                                    </div>
                                    <p></p>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary ">
                                            <tr>
                                                <th>Género</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <asp:Literal ID="litTablaGenero" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <!-- Gráficos -->
                        <div class="col-12 col-lg-6">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">GÉNERO</h5>
                                    </div>
                                    <div class="row  p-1">
                                        <div class="col-6 text-center">
                                            <h6>MASCULINO</h6>
                                            <canvas id="masculinoChart" class="grafico-pequeno"></canvas>
                                        </div>
                                        <div class="col-6 text-center">
                                            <h6>FEMENINO</h6>
                                            <canvas id="femeninoChart" class="grafico-pequeno"></canvas>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <!-- ATENDIDOS NO ASISTIDOS -->
                    <!-- Fila horizontal con dos cards lado a lado -->
                      <asp:HiddenField ID="hfAtendido" runat="server" />
                      <asp:HiddenField ID="hfNoAtendidos" runat="server" />
                      <asp:HiddenField ID="hfTotalATen" runat="server" />
                   <%-- <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">ATENCIONES</h5>
                                    </div>
                                    <p></p>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>ATENCIONES</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                         <asp:Literal ID="litTablaAsistidos" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <!-- Gráficos -->
                        <!-- Atendidos vs No Asistidos -->
                        <div class="col-12 col-lg-6">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">ATENCIONES</h5>
                                    </div>
                                    <div class="row  p-1">
                                        <!-- Atendidos -->
                                        <div class="col-6 text-center">
                                            <h6>ATENDIDOS</h6>
                                            <canvas id="asistenciasChartAtendidos" class="grafico-pequeno"></canvas>
                                        </div>
                                        <!-- No Atendidos -->
                                        <div class="col-6 text-center">
                                            <h6>NO ASISTIDOS</h6>
                                            <canvas id="asistenciasChartNoAsistidos" class="grafico-pequeno"></canvas>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <div class="row mb-4">
                         <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                             <div class="card card-kpi h-100">
                                 <div class="card-body">
                                     <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                         <h5 class="card-title mb-0">GÉNERO</h5>
                                     </div>
                         
                                     <!-- Contenedor interior: tabla + gráficos en columnas -->
                                     <div class="row mt-3">
                                         <!-- Tabla -->
                                         <div class="col-6">
                                             <table class="table table-bordered text-center">
                                                 <thead class="table-primary">
                                                     <tr>
                                                         <th>Género</th>
                                                         <th>Cantidad</th>
                                                     </tr>
                                                 </thead>
                                                 <tbody>
                                                     <asp:Literal ID="litTablaGenero" runat="server"></asp:Literal>
                                                 </tbody>
                                             </table>
                                         </div>
                         
                                         <!-- Gráfico -->
                                         <div class="col-6 col-md-6 text-center">
                                             <div class="text-center mb-2">
                                                 <h6>GENERO</h6>
                         
                                                 <canvas id="masculinoChart" class="grafico-pequeno"></canvas>
                                             </div>
                                            <%-- <div class="text-center">
                                                 <h6>FEMENINO</h6>
                                                 <canvas id="femeninoChart" class="grafico-pequeno"></canvas>
                                             </div>--%>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
                    
                    <!-- Repite lo mismo para la otra card en la fila -->
                         <div class="col-12 col-lg-6">
                             <div class="card card-kpi h-100">
                                 <div class="card-body">
                                     <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                         <h5 class="card-title mb-0">ATENCIONES</h5>
                                     </div>
                         
                                     <!-- Contenedor interior: tabla + gráficos en columnas -->
                                     <div class="row mt-3">
                                         <!-- Tabla -->
                                         <div class="col-6">
                                             <table class="table table-bordered text-center">
                                                 <thead class="table-primary">
                                                     <tr>
                                                         <th>ATENCIONES</th>
                                                         <th>Cantidad</th>
                                                     </tr>
                                                 </thead>
                                                 <tbody>
                                                     <asp:Literal ID="litTablaAsistidos" runat="server"></asp:Literal>
                                                 </tbody>
                                             </table>
                                         </div>
                         
                                         <!-- Gráfico -->
                                         <div class="col-6 col-md-6 text-center">
                                             <div class="text-center mb-2">
                                                 <h6>ATENCIONES</h6>
                                                 <canvas id="asistenciasChartAtendidos" class="grafico-pequeno"></canvas>
                                             </div>
                                             <%--<div class="text-center">
                                                 <h6>NO ASISTIDOS</h6>
                                                 <canvas id="asistenciasChartNoAsistidos" class="grafico-pequeno"></canvas>
                                             </div>--%>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
                    </div>

                    <!-- TIPO DE EMO -->
                      <asp:HiddenField ID="hfPre" runat="server" />
                      <asp:HiddenField ID="hfEgreso" runat="server" />
                      <asp:HiddenField ID="hfAnual" runat="server" />
                      <asp:HiddenField ID="hfTotal" runat="server" />
                <%--    <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">EMO</h5>
                                    </div>
                                    <p></p>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>Tipo</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <asp:Literal ID="litTablaTipoEMO" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <!-- Gráficos -->
                        <div class="col-12 col-lg-6">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">EMO</h5>
                                    </div>
                                    <div class="row  p-1">
                                        <div class="col-6 col-lg-4 text-center mb-3">
                                            <h6>PRE</h6>
                                            <canvas id="emoChartPre" class="grafico-pequeno"></canvas>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    
                       <div class="row mb-4">
                            <div class="col-12 col-lg-6">
                                <div class="card card-kpi h-100">
                                    
                                    <div class="card-body">
                                        <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                            <h5 class="card-title mb-0">EMO</h5>
                                        </div>
                                        <div class="row mt-3">
                                            <!-- Tabla -->
                                            <div class="col-6 ">
                                                <table class="table table-bordered text-center mb-0">
                                                    <thead class="table-primary">
                                                        <tr>
                                                            <th>Tipo</th>
                                                            <th>Cantidad</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Literal ID="litTablaTipoEMO" runat="server"></asp:Literal>
                                                    </tbody>
                                                </table>
                                            </div>
                            
                                            <!-- Gráfico -->
                                            <div class="col-6 col-md-6 text-center">
                                                <div class="text-center mb-2">
                                                     <h6>EMO</h6>
                                                    <canvas id="emoChartPre" class="grafico-pequeno"></canvas>
                                                </div>
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-lg-6">
                            <div class="card card-kpi h-100">
                                
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">APTITUD</h5>
                                    </div>
                                    <div class="row mt-3">
                                        <!-- Tabla -->
                                        <div class="col-6">
                                            <table class="table table-bordered text-center mb-0">
                                                <thead class="table-primary">
                                                    <tr>
                                                        <th>Aptitud</th>
                                                        <th>Cantidad</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Literal ID="litTablaAptitudes" runat="server"></asp:Literal>
                                                </tbody>
                                            </table>
                                        </div>
                            
                                        <!-- Gráfico -->
                                         <div class="col-6 col-md-6 text-center">
                                             <div class="text-center mb-2">
                                            <h6>APTITUDES</h6>
                                            <canvas id="aptitudChartApto" class="grafico-pequeno"></canvas>
                                             </div>
                                        </div>
                                    </div>
                                </div>
                             </div>
                            </div>
                    </div>

            <!-- APTITUD -->
                       <asp:HiddenField ID="hfApto" runat="server" />
                       <asp:HiddenField ID="hfAptoRes" runat="server" />
                       <asp:HiddenField ID="hfNoApto" runat="server" />
                       <asp:HiddenField ID="hfObservado" runat="server" />
                       <asp:HiddenField ID="hfTotalApt" runat="server" />
                  <%--  <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">APTITUD</h5>
                                    </div>
                                    <p></p>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>Aptitud</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <asp:Literal ID="litTablaAptitudes" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <!-- Gráficos -->
                        <div class="col-12 col-lg-6">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">APTITUD</h5>
                                    </div>
                                    <div class="row p-1">
                                        <div class="col-6 col-lg-3 text-center mb-4">
                                            <h6>APTO</h6>
                                            <canvas id="aptitudChartApto" class="grafico-pequeno"></canvas>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>
        

            <!-- Modal PDF -->
              <div class="modal fade" id="pdfModal" tabindex="-1" aria-labelledby="pdfModalLabel" aria-hidden="true">
               <div class="modal-dialog modal-xl modal-dialog-centered">
                 <div class="modal-content">
                   <div class="modal-header">
                     <h5 class="modal-title" id="pdfModalLabel">Vista previa del Certificado</h5>
                     <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                   </div>
                   <div class="modal-body p-0">
                     <iframe id="pdfViewer" src="" width="100%" height="600px" style="border:none;"></iframe>
                   </div>
                 </div>
               </div>
              </div>
            
             <script>
                 /*VALIDACION FILTRO FECHAS DATA PIKER   */
               <%--  window.fechaInicio = parseInt("<%= hffechaInicio.Value %>");
                 window.fechaFin = parseInt("<%= hffechaFin.Value %>");--%>
                 /*GRAFICO BARRA*/
                 var hfDataId = "<%= hfData.ClientID %>";
                 /*GRAFICO DONA GENERO*/
                 window.masculino = parseInt("<%= hfMasculino.Value %>");
                 window.femenino = parseInt("<%= hfFemenino.Value %>");
                 /* GRAFICO DONA ATENCIONES*/
                 window.atendido = parseInt("<%= hfAtendido.Value %>");
                 window.noatendidos = parseInt("<%= hfNoAtendidos.Value %>");
                 window.totalaten = parseInt("<%= hfTotalATen.Value %>");
                 /* GRAFICO DONA EMO*/
                 window.pre = parseInt("<%= hfPre.Value %>");
                 window.egreso = parseInt("<%= hfEgreso.Value %>");
                 window.anual = parseInt("<%= hfAnual.Value %>");
                 window.total = parseInt("<%= hfTotal.Value %>");
                 /* GRAFICO DONA APTITUD*/
                 window.apto = parseInt("<%= hfApto.Value %>");
                 window.aptores = parseInt("<%= hfAptoRes.Value %>");
                 window.noapto = parseInt("<%= hfNoApto.Value %>");
                 window.observado = parseInt("<%= hfObservado.Value %>");
                 window.totalapt = parseInt("<%= hfTotalApt.Value %>");

             </script>
             </div>
           </div>
    </div>

  </div>
   
</asp:Content>
