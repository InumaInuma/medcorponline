
//////////////VALIDACION DE FECHAS 



document.addEventListener("DOMContentLoaded", function () {
    const masculino = window.masculino || 0;
    const femenino = window.femenino || 0;
    const total = window.totalGenero || (masculino + femenino);

    new Chart(document.getElementById("masculinoChart"), {
        type: "doughnut",
        data: {
            labels: ["MASCULINO","FEMENINO"],
            datasets: [
                {
                    data: [masculino, total - masculino],
                    backgroundColor: ['rgb(255, 99, 132)',
                        'rgb(54, 162, 235)'],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },
        options: {
            responsive: true,
            
           
            plugins: {
                legend: {
                    display: false,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });

    new Chart(document.getElementById("femeninoChart"), {
        type: "doughnut",
        data: {
            labels: ["FEMENINO"],
            datasets: [
                {
                    data: [femenino, total - femenino],
                    backgroundColor: ["#E91E63", "#e0e0e0"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },
        options: {
            responsive: true,
            rotation: -90,
            circumference: 180,
            plugins: {
                legend: {
                    display: true,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                  enabled: true,
              },
            },
        },
    });
});
// Doughnut: ATENDIDOS  Y NO ATENDIDOS
document.addEventListener("DOMContentLoaded", function () {
    const atendido = window.atendido || 0;
    const noatendidos = window.noatendidos || 0;
    const totalatenn = window.totalaten || (atendido + noatendidos);

    new Chart(document.getElementById("asistenciasChartAtendidos"), {
         type: "doughnut",
         data: {
           labels: ["ATENDIDOS", "NO ATENDIDOS"],
           datasets: [
             {
               data: [atendido, noatendidos],
               backgroundColor: ['rgb(255, 99, 132)',
                                 'rgb(54, 162, 235)'],
               borderWidth: 0,
               hoverOffset: 4,
               borderWidth: 3,
             },
           ],
         },
         options: {
           responsive: true,
           plugins: {
             legend: {
               display: false,
               position: "bottom",
               align: "center",
               labels: {
                 boxWidth: 10,
                 padding: 15,
                 usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                 textAlign: "center",
               },
             },
             tooltip: {
               enabled: true,
               },
               datalabels: {
                   display: false, // ¡CLAVE! Mostrar los labels para este dataset 
                   color: "#333", // Color del texto del label
                   anchor: "end",  // Posicionar el label al final de la barra
                   align: "top",  // Alinear el label en la parte superior del punto de anclaje
                   offset: 4, // Desplazamiento desde el punto de anclaje
                   font: {
                       weight: "bold",
                       family: "Arial",
                       size: 13,
                   },
                   backgroundColor: "rgba(255, 255, 255, 0.8)",
                   borderRadius: 6,
                   padding: {
                       top: 6,
                       bottom: 4,
                       left: 8,
                       right: 8,
                   },

                   borderWidth: 1,
                   borderColor: "#D1D5DB", // gris claro
                   formatter: function (value, context) {
                       const label = context.chart.data.labels[context.dataIndex];
                       return `${label}: ${value}`;
                   }
               }
           }
        },
        plugins: [ChartDataLabels] // Activa el plugin aquí
      });
////Doughnut: No Asistidos
    new Chart(document.getElementById("asistenciasChartNoAsistidos"), {
           type: "doughnut",
           data: {
             labels: ["NO ASISTIDOS"],
             datasets: [
               {
                 data: [noatendidos, totalatenn - noatendidos],
                 backgroundColor: ["#E91E63", "#e0e0e0"],
                 borderWidth: 0,
                 hoverOffset: 4,
                 borderWidth: 3,

               },
             ],
           },
           options: {
             responsive: true,
             plugins: {
               legend: {
                 display: true,
                 position: "bottom",
                 align: "center",
                 labels: {
                   boxWidth: 10,
                   padding: 15,
                   usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                   textAlign: "center",
                 },
               },
               tooltip: {
                 enabled: true,
               },
             },
         },
      });
});
// Doughnut: TIPOS DE EMOOOOOOOO

document.addEventListener("DOMContentLoaded", function () {

    const pre = window.pre || 0;
    const egreso = window.egreso || 0;
    const anual = window.anual || 0;
    const total = window.total || (pre + egreso + anual);

    new Chart(document.getElementById("emoChartPre"), {
        type: "doughnut",
        data: {
            labels: ["PRE","EGRESO","ANUAL"],
            datasets: [
                {
                    data: [pre, egreso , anual],
                    backgroundColor: ["rgba(37, 43, 245, 0.8)", "rgba(0, 0, 248, 0.47)",
                       "rgba(9, 9, 125, 0.95)"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    display: false,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });

    // Doughnut: Tipo de EGRESO
    new Chart(document.getElementById("emoChartEgreso"), {
        type: "doughnut",
        data: {
            labels: ["EGRESO"],
            datasets: [
                {
                    data: [egreso, total - egreso],
                    backgroundColor: ["#dce91eff", "#e0e0e0"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    display: true,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                        // Esto evitará que se apilen por ancho
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });

    //Doughnut: Tipo de ANUAL
    new Chart(document.getElementById("emoChartAnual"), {
        type: "doughnut",
        data: {
            labels: ["ANUAL"],
            datasets: [
                {
                    data: [anual, total - anual],
                    backgroundColor: ["#14ec55ff", "#e0e0e0"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    display: true,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });


});

//  Doughnut: APTIDUDES
document.addEventListener("DOMContentLoaded", function () {

    const apto = window.apto || 0;
    const aptores = window.aptores || 0;
    const noapto = window.noapto || 0;
    const observado = window.observado || 0;
    const totalapt = window.totalapt || (apto + aptores + noapto + observado);

    // Doughnut: Aptitud APTO
    new Chart(document.getElementById("aptitudChartApto"), {
        type: "doughnut",
        data: {
            labels: ["APTO","APTO RES","NO APTO","OBSERVADO"],
            datasets: [
                {
                    data: [apto, aptores , noapto,observado],
                    backgroundColor: ["rgba(37, 43, 245, 0.8)", "rgba(0, 0, 248, 0.47)",
                        "rgba(9, 9, 125, 0.95)","rgb(54, 162, 235)"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },

        options: {
            responsive: true,
          
            plugins: {
                legend: {
                    display: false,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });

    // Doughnut: Aptitud APTO RES
    new Chart(document.getElementById("aptitudChartAptoRes"), {
        type: "doughnut",
        data: {
            labels: ["APTO RES"],
            datasets: [
                {
                    data: [aptores, totalapt - aptores],
                    backgroundColor: ["#da5c08ff", "#e0e0e0"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },

        options: {
            responsive: true,
            rotation: -90,
            circumference: 180,
            plugins: {
                legend: {
                    display: true,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });

    // Doughnut: Aptitud NO APTO
    new Chart(document.getElementById("aptitudChartNoApto"), {
        type: "doughnut",
        data: {
            labels: ["NO APTO"],
            datasets: [
                {
                    data: [noapto, totalapt - noapto],
                    backgroundColor: ["#af2e93ff", "#e0e0e0"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },

        options: {
            responsive: true,
            rotation: -90,
            circumference: 180,
            plugins: {
                legend: {
                    display: true,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });

    // Doughnut: Aptitud OBSERVADO
    new Chart(document.getElementById("aptitudChartObservado"), {
        type: "doughnut",
        data: {
            labels: ["OBSERVADO"],
            datasets: [
                {
                    data: [observado, totalapt - observado],
                    backgroundColor: ["#c98c1cff", "#e0e0e0"],
                    borderWidth: 0,
                    hoverOffset: 4,
                    borderWidth: 3,
                },
            ],
        },

        options: {
            responsive: true,
            rotation: -90,
            circumference: 180,
            plugins: {
                legend: {
                    display: true,
                    position: "bottom",
                    align: "center",
                    labels: {
                        boxWidth: 10,
                        padding: 15,
                        usePointStyle: true, // íconos tipo punto en lugar de cuadrados
                        textAlign: "center",
                    },
                },
                tooltip: {
                    enabled: true,
                },
            },
        },
    });



});



// Doughnut: BARRAS GRAFICO
document.addEventListener("DOMContentLoaded", function () {

    const hfData = document.getElementById(window.hfDataId);


    if (!hfData) {
        console.error("hfData o canvas no encontrados.");
        return;
    }

    const dataDesdeServidor = hfData.value.split(',').map(Number);
    new Chart(document.getElementById("barrasMesChart"), {
        type: "bar",// Usamos 'bar' directamente para el gráfico principal
        data: {
            labels: [
                "Ene",
                "Feb",
                "Mar",
                "Abr",
                "May",
                "Jun",
                "Jul",
                "Ago",
                "Sep",
                "Oct",
                "Nov",
                "Dic",
            ],
            datasets: [
                {
                    label: "Atenciones",
                    data: dataDesdeServidor, // Usamos los datos pasados a la función
                    backgroundColor: "rgba(54, 162, 235, 0.6)", // Opacidad aumentada
                    borderColor: "rgba(54, 162, 235, 1)",
                    borderWidth: 1,
                    // Configuración del plugin datalabels para este dataset de barras
                    datalabels: {
                        display: true, // ¡CLAVE! Mostrar los labels para este dataset 
                        color: "#333", // Color del texto del label
                        anchor: "end",  // Posicionar el label al final de la barra
                        align: "top",  // Alinear el label en la parte superior del punto de anclaje
                        offset: 4, // Desplazamiento desde el punto de anclaje
                        font: { 
                            weight: "bold",
                            family: "Arial",
                            size: 13,
                        },
                        backgroundColor: "rgba(255, 255, 255, 0.8)",
                        borderRadius: 6,
                        padding: {
                            top: 6,
                            bottom: 4,
                            left: 8,
                            right: 8,
                        },

                        borderWidth: 1,
                        borderColor: "#D1D5DB", // gris claro
                        formatter: function (value, context) {
                            return value; // Mostrar el valor real del dato
                        }
                        //formatter: (value) => `${value}`, // puedes personalizar con texto
                    },
                },
                {
                    type: "line",
                    label: "Tendencia",
                    display: false,
                    data: dataDesdeServidor,
                    borderColor: "rgb(54, 162, 235)",
                    borderWidth: 4,
                    fill: false,
                    
                    pointRadius: 6,
                    datalabels: {
                        display: false // NO mostrar labels para el dataset de línea
                    }
                },
            ],
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            layout: {
                padding: {
                    top: 20, // Espacio superior para los labels del gráfico
                    bottom: 40 // Espacio inferior para los labels del eje X y asegurar que no se corten los datalabels
                    //bottom: 40 // 👈 AÑADIMOS ESTO para dar espacio a las etiquetas del eje X
                }
            },
            plugins: {
                legend: { display: false },
                datalabels: {
                    display: true,
                    anchor: "end",
                    align: "top",
                    color: "#000",
                    font: {
                        size: 12,
                        weight: "bold",
                    },

                    formatter: (value) => value,
                },
            },
            scales: {
                x: {
                    grid: { display: false }, // ❌ Oculta línea del eje X
                    ticks: {
                        display: true,
                        autoSkip: false, // Evita que Chart.js oculte labels automáticamente
                        maxRotation: 0, // Evita rotación de labels
                        minRotation: 0,
                        padding: 10 // Espacio entre el label del eje X y la barra
                    }, // ✅ Muestra etiquetas del eje X
                    offset: true // Desplaza las barras y labels ligeramente del borde
                },
                y: {
                    grid: { display: false }, // ❌ Oculta líneas del eje Y
                    ticks: { display: false }, // ✅ Muestra números del eje Y
                    beginAtZero: true, // Asegura que el eje Y comience en 0
                    // Asegura que el rango del eje Y sea suficiente para los labels
                    suggestedMax: Math.max(...dataDesdeServidor) + (Math.max(...dataDesdeServidor) * 0.2) // Añade un 20% extra al valor máximo
                },
            },
        },
        plugins: [ChartDataLabels], // 👈 Asegúrate de cargar esto
    });
});


function verPdf(ruta) {
    document.getElementById("pdfViewer").src = ruta;
    var modal = new bootstrap.Modal(document.getElementById('pdfModal'));
    modal.show();
}
