$(document).ready(function () {
    $('.select2').select2({ width: '100%' });
});
function InitScroll(value) {
    if ($.fn.dataTable.isDataTable(value)) {
        table = $(value).DataTable();
    }
    else {
        $(value).DataTable({
            "scrollX": true,
            "scrollY": "600px",
            "scrollCollapse": true,
            "paging": false,
            "responsive": true,
            "pageLength": 10,
            "lengthChange": false,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Total de registros: _TOTAL_",
                "sInfoEmpty": "0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            },
            dom: 'frtip',
        });
    }
}

function SuccessMessage(mensaje) {
    var opts = {
        "closeButton": true,
        "debug": false,
        "positionClass": rtl() || public_vars.$pageContainer.hasClass('right-sidebar') ? "toast-top-left" : "toast-top-right",
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    toastr.success(mensaje,"Mensaje del sistema", opts);
}

function ErrorMessage(mensaje) {
    var opts = {
        "closeButton": true,
        "debug": false,
        "positionClass": rtl() || public_vars.$pageContainer.hasClass('right-sidebar') ? "toast-top-left" : "toast-top-right",
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    toastr.error(mensaje, "Mensaje del sistema", opts);
}

function LlenarComboDinamico(combo,url_, query, id) {
    $.ajax({
        url: url_,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{query:'" + query + "'}",
        success: function (result) {
            var $select = $(combo);
            $select.find('option').remove();
            $select.append('<option value="0">--Seleccione una opción</option>');
            $.each(result, function (index, item) {
                if (id > 0 && id == item.value) {

                    $select.append('<option value="' + item.value + '" selected>' + item.text + '</option>');
                } else {

                    $select.append('<option value="' + item.value + '">' + item.text + '</option>');
                }
            });
        },
        error: function (xhr, status, error) {
            console.log(xhr.responseText);
            alert("Error al consumir servicio web");
        }
    });

}

function LlenarTablaDinamica(entidadId,table, url_, PK, actionUpdate, actionDelete) {
    $.ajax({
        url: url_,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{entidadId:" + entidadId+"}",
        success: function (result) {
            console.log(result);
            $(table).find('thead').empty();
            $(table).find('tbody').empty();
            var countHead = 0;
            var trHead = '';
            var trBody = '';
            $.each(result, function (index, items) {
                if (countHead == 0) {
                    trHead += '<tr>';
                    trHead += '<th></th>';
                    trHead += '<th></th>';
                    for (var key in items) {
                        if (key != PK) {
                            trHead += '<th>' + key + '</th>';
                        }
                    }
                    trHead += '</tr>';
                    countHead += 1;
                }
                trBody += "<tr>";

                trBody += '<td style="width:50px;text-align:center;"><a class="btn btn-sm btn-default" href="' + actionUpdate +items[PK] +'"><i class="fas fa-pencil-alt"></i></a>';
                trBody += '<td style="width:50px;text-align:center;"><a class="btn btn-sm btn-default" href="' + actionDelete + '"><i class="fas fa-trash"></i></a></td>';
                for (var key in items) {
                    if (key != PK) {
                        trBody += '<td>' + items[key] + '</td>';
                    }
                }
                trBody += "</tr>";
            });

            $(table).find('thead').append(trHead);
            $(table).find('tbody').append(trBody);
            InitScroll(table);
        },
        error: function (xhr, status, error) {
            console.log(xhr.responseText);
            alert("Error al consumir servicio web");
        }
    });

}


function AlertGO(TextMess, URL) {
    swal({
        title: "Mensaje del Sistema",
        text: TextMess,
        icon: "success",
        type: 'success',
        showCancelButton: false,
        confirmButtonColor: "#428bca",
        confirmButtonText: "Aceptar",
        closeOnConfirm: false,
        allowEscapeKey: false,
        button: "Aceptar",
    }).then(function () {
        location.href = URL;
    });
}
