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
                                <input type="date" class="form-control" id="fechaInicio">
                            </div>

                            <div class="col-md-3">
                                <label for="fechaFin" class="form-label">Hasta</label>
                                <input type="date" class="form-control" id="fechaFin">
                            </div>

                            <div class="col-md-3">
                                <label for="empresa" class="form-label">Empresa</label>
                                <select class="form-select" id="empresa">
                                    <option value="">-- Todas --</option>
                                    <option>Empresa A</option>
                                    <option>Empresa B</option>
                                    <option>Empresa C</option>
                                </select>
                            </div>

                            <div class="col-md-3 d-grid">
                                <button class="btn btn-success" onclick="exportarExcel()">📥 Exportar Excel</button>
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
                                                <tr>
                                                    <td>21/07/2025</td>
                                                    <td>Juan Pérez</td>
                                                    <td>EMO PRE</td>
                                                    <td>APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <tr>
                                                    <td>20/07/2025</td>
                                                    <td>Lucía Gómez</td>
                                                    <td>EMO ANUAL</td>
                                                    <td>NO APTO</td>
                                                    <td><i class="bi bi-file-earmark-excel fs-5 text-success"></i></td>
                                                </tr>
                                                <!-- Puedes agregar más filas aquí -->
                                            </tbody>

                                        </table>
                                    </div>

                                    <!-- PAGINACIÓN -->
                                    <nav aria-label="Paginación de ejemplo" class="mt-4">
                                        <ul class="pagination justify-content-center">
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
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN TABLA -->
          <h2 class="mb-4 text-center"> DASHBOARD DE ATENCIONES MEDICAS</h2>
            <asp:HiddenField ID="hfMasculino" runat="server" />
            <asp:HiddenField ID="hfFemenino" runat="server" />
         
          <!-- GENERO -->
                    <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">GENERO</h5>
                                    </div>

                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>Género</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Masculino</td>
                                                <td>120</td>
                                            </tr>
                                            <tr>
                                                <td>Femenino</td>
                                                <td>95</td>
                                            </tr>
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
                                    <div class="row">
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
                    </div>
                    <!-- ATENDIDOS NO ASISTIDOS -->
                    <!-- Fila horizontal con dos cards lado a lado -->
                    <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">ATENCIONES</h5>
                                    </div>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>ATENCIONES</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>ATENDIDOS</td>
                                                <td>120</td>
                                            </tr>
                                            <tr>
                                                <td>NO ASISTIDOS</td>
                                                <td>95</td>
                                            </tr>
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
                                    <div class="row p-3">
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
                    </div>
                    <!-- TIPO DE EMO -->
                    <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">EMO</h5>
                                    </div>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>Tipo</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>PRE</td>
                                                <td>150</td>
                                            </tr>
                                            <tr>
                                                <td>EGRESO</td>
                                                <td>100</td>
                                            </tr>
                                            <tr>
                                                <td>ANUAL</td>
                                                <td>80</td>
                                            </tr>
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
                                    <div class="row p-3">
                                        <div class="col-6 col-lg-4 text-center mb-3">
                                            <h6>PRE</h6>
                                            <canvas id="emoChartPre" class="grafico-pequeno"></canvas>
                                        </div>
                                        <div class="col-6 col-lg-4 text-center mb-3">
                                            <h6>EGRESO</h6>
                                            <canvas id="emoChartEgreso" class="grafico-pequeno"></canvas>
                                        </div>
                                        <div class="col-6 offset-3 col-lg-4 offset-lg-0 text-center mb-3">
                                            <h6>ANUAL</h6>
                                            <canvas id="emoChartAnual" class="grafico-pequeno"></canvas>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- APTITUD -->
                    <div class="row mb-4">
                        <!-- Tabla -->
                        <div class="col-12 col-lg-6 mb-3 mb-lg-0">
                            <div class="card card-kpi h-100">
                                <div class="card-body">
                                    <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">APTITUD</h5>
                                    </div>
                                    <table class="table table-bordered text-center">
                                        <thead class="table-primary">
                                            <tr>
                                                <th>Aptitud</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>APTO</td>
                                                <td>200</td>
                                            </tr>
                                            <tr>
                                                <td>APTO RES</td>
                                                <td>50</td>
                                            </tr>
                                            <tr>
                                                <td>NO APTO</td>
                                                <td>30</td>
                                            </tr>
                                            <tr>
                                                <td>OBSERVADO</td>
                                                <td>20</td>
                                            </tr>
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
                                    <div class="row p-3">
                                        <div class="col-6 col-lg-3 text-center mb-4">
                                            <h6>APTO</h6>
                                            <canvas id="aptitudChartApto" class="grafico-pequeno"></canvas>
                                        </div>
                                        <div class="col-6 col-lg-3 text-center mb-4">
                                            <h6>APTO RES</h6>
                                            <canvas id="aptitudChartAptoRes" class="grafico-pequeno"></canvas>
                                        </div>
                                        <div class="col-6 col-lg-3 text-center mb-4">
                                            <h6>NO APTO</h6>
                                            <canvas id="aptitudChartNoApto" class="grafico-pequeno"></canvas>
                                        </div>
                                        <div class="col-6 col-lg-3 text-center mb-4">
                                            <h6>OBSERVADO</h6>
                                            <canvas id="aptitudChartObservado" class="grafico-pequeno"></canvas>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
        <!-- HiddenField con datos -->
                   <asp:HiddenField ID="hfData" runat="server" />
                  
                  
                  <div class="row mb-4">
                      <!-- Barras por mes -->
                      <div class="col-md-12">
                          <div class="card card-kpi">
                              <div class="card-body">
                                     <div class="card-header bg-primary text-white text-center py-2 rounded-top">
                                        <h5 class="card-title mb-0">ATENCIONES POR MES</h5>
                                      </div>
                                  <canvas id="barrasMesChart" class="grafico-ancho"></canvas>
                              </div>
                          </div>
                  </div>
              </div>
             <script>
                 var hfDataId = "<%= hfData.ClientID %>";
                
                 window.masculino = parseInt("<%= hfMasculino.Value %>");
                 window.femenino = parseInt("<%= hfFemenino.Value %>");
                 
             </script>
             </div>
           </div>
    </div>

  </div>
   
</asp:Content>
