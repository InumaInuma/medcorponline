
//////////////VALIDACION DE FECHAS 



document.addEventListener("DOMContentLoaded", function () {
    const masculino = window.masculino || 0;
    const femenino = window.femenino || 0;
    const total = window.totalGenero || (masculino + femenino);

    const porcentajeMasculino = ((masculino / total) * 100).toFixed(2);
    const porcentajeFemenino = ((femenino / total) * 100).toFixed(2);

    new Chart(document.getElementById("masculinoChart"), {
        type: "doughnut",
        data: {
            labels: ["M (♂)","F (♀)"],
            datasets: [
                {
                    data: [porcentajeMasculino, porcentajeFemenino],
                    backgroundColor: ['rgb(54, 162, 235)', 'rgb(255, 99, 132)'],
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
                    callbacks: {
                        label: function (context) {
                            return context.label + ": " + context.parsed.toFixed(2) + "%";
                        }
                    }
                },
            },
        },
    });

    //new Chart(document.getElementById("femeninoChart"), {
    //    type: "doughnut",
    //    data: {
    //        labels: ["FEMENINO"],
    //        datasets: [
    //            {
    //                data: [femenino, total - femenino],
    //                backgroundColor: ["#E91E63", "#e0e0e0"],
    //                borderWidth: 0,
    //                hoverOffset: 4,
    //                borderWidth: 3,
    //            },
    //        ],
    //    },
    //    options: {
    //        responsive: true,
    //        rotation: -90,
    //        circumference: 180,
    //        plugins: {
    //            legend: {
    //                display: true,
    //                position: "bottom",
    //                align: "center",
    //                labels: {
    //                    boxWidth: 10,
    //                    padding: 15,
    //                    usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //                    textAlign: "center",
    //                },
    //            },
    //            tooltip: {
    //              enabled: true,
    //          },
    //        },
    //    },
    //});


});
// Doughnut: ATENDIDOS  Y NO ATENDIDOS
document.addEventListener("DOMContentLoaded", function () {
    const atendido = window.atendido || 0;
    const noatendidos = window.noatendidos || 0;
    const totalatenn = window.totalaten || (atendido + noatendidos);

    const porcentajeAtendido = ((atendido / totalatenn) * 100).toFixed(2);
    const porcentajeNoatendidos = ((noatendidos / totalatenn) * 100).toFixed(2);

    new Chart(document.getElementById("asistenciasChartAtendidos"), {
         type: "doughnut",
         data: {
           labels: ["ATEN", "NO ATEN"],
           datasets: [
             {
               data: [porcentajeAtendido, porcentajeNoatendidos],
                   backgroundColor: ['rgb(54, 162, 235)', 'rgb(255, 99, 132)'],
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
                 callbacks: {
                     label: function (context) {
                         return context.label + ": " + context.parsed.toFixed(2) + "%";
                     }
                 }
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
    //new Chart(document.getElementById("asistenciasChartNoAsistidos"), {
    //       type: "doughnut",
    //       data: {
    //         labels: ["NO ASISTIDOS"],
    //         datasets: [
    //           {
    //             data: [noatendidos, totalatenn - noatendidos],
    //             backgroundColor: ["#E91E63", "#e0e0e0"],
    //             borderWidth: 0,
    //             hoverOffset: 4,
    //             borderWidth: 3,

    //           },
    //         ],
    //       },
    //       options: {
    //         responsive: true,
    //         plugins: {
    //           legend: {
    //             display: true,
    //             position: "bottom",
    //             align: "center",
    //             labels: {
    //               boxWidth: 10,
    //               padding: 15,
    //               usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //               textAlign: "center",
    //             },
    //           },
    //           tooltip: {
    //             enabled: true,
    //           },
    //         },
    //     },
    //  });
});
// Doughnut: TIPOS DE EMOOOOOOOO

document.addEventListener("DOMContentLoaded", function () {

    const pre = window.pre || 0;
    const egreso = window.egreso || 0;
    const anual = window.anual || 0;
    const total = window.total || (pre + egreso + anual);

    const porcentajePre = ((pre / total) * 100).toFixed(2);
    const porcentajeEgreso = ((egreso / total) * 100).toFixed(2);
    const porcentajeAnual = ((anual / total) * 100).toFixed(2);


    new Chart(document.getElementById("emoChartPre"), {
        type: "doughnut",
        data: {
            labels: ["PRE","EGRESO","ANUAL"],
            datasets: [
                {
                    data: [porcentajePre, porcentajeEgreso, porcentajeAnual],
                    backgroundColor: ['rgb(54, 162, 235)',  // Azul
                        'rgb(255, 99, 132)',  // Rosa fuerte
                        'rgb(255, 206, 86)'],
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
                    callbacks: {
                        label: function (context) {
                            return context.label + ": " + context.parsed.toFixed(2) + "%";
                        }
                    }
                },
            },
        },
    });

    // Doughnut: Tipo de EGRESO
    //new Chart(document.getElementById("emoChartEgreso"), {
    //    type: "doughnut",
    //    data: {
    //        labels: ["EGRESO"],
    //        datasets: [
    //            {
    //                data: [egreso, total - egreso],
    //                backgroundColor: ["#dce91eff", "#e0e0e0"],
    //                borderWidth: 0,
    //                hoverOffset: 4,
    //                borderWidth: 3,
    //            },
    //        ],
    //    },
    //    options: {
    //        responsive: true,
    //        plugins: {
    //            legend: {
    //                display: true,
    //                position: "bottom",
    //                align: "center",
    //                labels: {
    //                    boxWidth: 10,
    //                    padding: 15,
    //                    usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //                    textAlign: "center",
    //                    // Esto evitará que se apilen por ancho
    //                },
    //            },
    //            tooltip: {
    //                enabled: true,
    //            },
    //        },
    //    },
    //});

    //Doughnut: Tipo de ANUAL
    //new Chart(document.getElementById("emoChartAnual"), {
    //    type: "doughnut",
    //    data: {
    //        labels: ["ANUAL"],
    //        datasets: [
    //            {
    //                data: [anual, total - anual],
    //                backgroundColor: ["#14ec55ff", "#e0e0e0"],
    //                borderWidth: 0,
    //                hoverOffset: 4,
    //                borderWidth: 3,
    //            },
    //        ],
    //    },
    //    options: {
    //        responsive: true,
    //        plugins: {
    //            legend: {
    //                display: true,
    //                position: "bottom",
    //                align: "center",
    //                labels: {
    //                    boxWidth: 10,
    //                    padding: 15,
    //                    usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //                    textAlign: "center",
    //                },
    //            },
    //            tooltip: {
    //                enabled: true,
    //            },
    //        },
    //    },
    //});


});

//  Doughnut: APTIDUDES
document.addEventListener("DOMContentLoaded", function () {

    const apto = window.apto || 0;
    const aptores = window.aptores || 0;
    const noapto = window.noapto || 0;
    const observado = window.observado || 0;
    const totalapt = window.totalapt || (apto + aptores + noapto + observado);

    const porcentajeApto = ((apto / totalapt) * 100).toFixed(2);
    const porcentajeAptores = ((aptores / totalapt) * 100).toFixed(2);
    const porcentajeNoapto = ((noapto / totalapt) * 100).toFixed(2);
    const porcentajeObservado = ((observado / totalapt) * 100).toFixed(2);

    // Doughnut: Aptitud APTO
    new Chart(document.getElementById("aptitudChartApto"), {
        type: "doughnut",
        data: {
            labels: ["APTO","APT RES","NO APTO","OBSER"],
            datasets: [
                {
                    data: [porcentajeApto, porcentajeAptores, porcentajeNoapto, porcentajeObservado],
                    backgroundColor: ['rgb(54, 162, 235)',  // Azul
                        'rgb(255, 99, 132)',  // Rosa fuerte
                        'rgb(255, 206, 86)',  // Amarillo cálido
                        'rgb(75, 192, 192)'],
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
                    callbacks: {
                        label: function (context) {
                            return context.label + ": " + context.parsed.toFixed(2) + "%";
                        }
                    }
                },
            },
        },
    });

    // Doughnut: Aptitud APTO RES
    //new Chart(document.getElementById("aptitudChartAptoRes"), {
    //    type: "doughnut",
    //    data: {
    //        labels: ["APTO RES"],
    //        datasets: [
    //            {
    //                data: [aptores, totalapt - aptores],
    //                backgroundColor: ["#da5c08ff", "#e0e0e0"],
    //                borderWidth: 0,
    //                hoverOffset: 4,
    //                borderWidth: 3,
    //            },
    //        ],
    //    },

    //    options: {
    //        responsive: true,
    //        rotation: -90,
    //        circumference: 180,
    //        plugins: {
    //            legend: {
    //                display: true,
    //                position: "bottom",
    //                align: "center",
    //                labels: {
    //                    boxWidth: 10,
    //                    padding: 15,
    //                    usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //                    textAlign: "center",
    //                },
    //            },
    //            tooltip: {
    //                enabled: true,
    //            },
    //        },
    //    },
    //});

    // Doughnut: Aptitud NO APTO
    //new Chart(document.getElementById("aptitudChartNoApto"), {
    //    type: "doughnut",
    //    data: {
    //        labels: ["NO APTO"],
    //        datasets: [
    //            {
    //                data: [noapto, totalapt - noapto],
    //                backgroundColor: ["#af2e93ff", "#e0e0e0"],
    //                borderWidth: 0,
    //                hoverOffset: 4,
    //                borderWidth: 3,
    //            },
    //        ],
    //    },

    //    options: {
    //        responsive: true,
    //        rotation: -90,
    //        circumference: 180,
    //        plugins: {
    //            legend: {
    //                display: true,
    //                position: "bottom",
    //                align: "center",
    //                labels: {
    //                    boxWidth: 10,
    //                    padding: 15,
    //                    usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //                    textAlign: "center",
    //                },
    //            },
    //            tooltip: {
    //                enabled: true,
    //            },
    //        },
    //    },
    //});

    // Doughnut: Aptitud OBSERVADO
    //new Chart(document.getElementById("aptitudChartObservado"), {
    //    type: "doughnut",
    //    data: {
    //        labels: ["OBSERVADO"],
    //        datasets: [
    //            {
    //                data: [observado, totalapt - observado],
    //                backgroundColor: ["#c98c1cff", "#e0e0e0"],
    //                borderWidth: 0,
    //                hoverOffset: 4,
    //                borderWidth: 3,
    //            },
    //        ],
    //    },

    //    options: {
    //        responsive: true,
    //        rotation: -90,
    //        circumference: 180,
    //        plugins: {
    //            legend: {
    //                display: true,
    //                position: "bottom",
    //                align: "center",
    //                labels: {
    //                    boxWidth: 10,
    //                    padding: 15,
    //                    usePointStyle: true, // íconos tipo punto en lugar de cuadrados
    //                    textAlign: "center",
    //                },
    //            },
    //            tooltip: {
    //                enabled: true,
    //            },
    //        },
    //    },
    //});



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
                    backgroundColor: "#BCBEC0", // Opacidad aumentada
                    borderColor: "#7C8087",
                    borderWidth: 1,
                    barPercentage: 0.6,       // 👈 Aquí
                    categoryPercentage: 0.6,  // 👈 Aquí
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
                    borderWidth: 1,
                    fill: false,
                    
                    pointRadius: 2,
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
                    offset: true, // Desplaza las barras y labels ligeramente del borde
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
