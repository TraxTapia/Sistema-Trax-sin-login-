
$(document).ready(function () {


    //$('#formProveedor').on('submit', function (e) {
    //e.preventDefault();

    //var object = {
    //    numeroProveedor: $('#txtNroProveedor').val().trim(),
    //    Nombre: $('#txtNameProveedor').val().trim()
    //};
    $.ajax({
        //beforeSend: function () {
        //    //closeModalNuevo();
        //    $.blockUI({
        //        theme: true,
        //        title: 'Buscando registros.',
        //        message: '<div class="row"><div class="col-lg-10"><br /><p><img src="/SASE/Content/assets/img/loading.gif" style="width: 35px;" /></p><p> Espere un momento por favor...</p><br /></div></div>',
        //        baseZ: 10000
        //    });
        //},

        url: 'Ahorros/ObtenerUsuariosConAhorros',
        type: 'POST',
        datatype: 'json',

        success: function (data) {
            if (data.IsOK === true) {

                $('#tablaListaProductos').DataTable({
                    "data": data.List,

                    destroy: true,
                    language: {
                        "decimal": "",
                        "emptyTable": "No hay información",
                        "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                        "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                        "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                        "infoPostFix": "",
                        "thousands": ",",
                        "lengthMenu": "Mostrar _MENU_ Entradas",
                        "loadingRecords": "Cargando...",
                        "processing": "Procesando...",
                        "search": "Buscar:",
                        "zeroRecords": "Sin resultados encontrados",
                        "paginate": {
                            "first": "Primero",
                            "last": "Ultimo",
                            "next": "Siguiente",
                            "previous": "Anterior"
                        }
                    },
                    'columns': [
                        {
                            'data': 'IdUsuario',
                            "title": "IdUsuario",
                            'autoWith': true
                        },
                        {
                            'data': 'NombreCompleto',
                            "title": "Nombre Completo",
                            'autoWith': true
                        },
                        {
                            'data': 'Cantidad',
                            "title": "Monto $",
                            render: function (data) {
                                if (data > 50) {
                                    return '<span class="badge badge-success">$' + data + '</span>'
                                } else {
                                    return '<span class="badge badge-danger">$' + data + '</span>'
                                }
                            },
                            'autoWith': true
                        },
                        {
                            'data': 'Total',
                            "title": "Total $",
                            render: function (data) {
                                if (data > 50) {
                                    return '<span class="badge badge-success">$'+data+'</span>'
                                } else {
                                    return '<span class="badge badge-danger">$' + data +'</span>'
                                }
                            },
                            'autoWith': true
                        },
                        {
                            'data': 'FechaCobro',
                            render: function (data, type, row) {
                                return moment(data).format('DD/MM/YYYY');
                            },
                            "title": "Fecha de Cobro",
                            'autoWith': true
                        },
                    ]
                })
                //swal({
                //    title: 'Correcto',
                //    text: "El Registro Se Actualizo Correctamente",
                //    icon: "success",
                //});
            }
        },
        error: function (jqXHR, status, error) {
            $.unblockUI();
            swal({
                title: "¡Error!",
                text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                icon: "warning",
            });
        }
    });

    //});















    //llenarDataTablePrducts();
});
function llenarDataTablePrducts() {
    $('#tablaListaProductos').DataTable({

        'ajax': {
            'url': 'Ahorros/ObtenerUsuariosConAhorros',
            'type': 'POST',
            'datatype': 'json',
            dataSrc: ""

        },
        destroy: true,
        'columns': [
            {
                'data': 'IdUsuario',
                "title": "IdUsuario",
                'autoWith': true
            },
            {
                'data': 'NombreCompleto',
                "title": "Nombre Completo",
                'autoWith': true
            },
            {
                'data': 'Cantidad',
                "title": "Cantidad",
                'autoWith': true
            },
            {
                'data': 'Total',
                "title": "Total",
                'autoWith': true
            },
            {
                'data': 'FechaCobro',
                "title": "Fecha de Cobro",
                'autoWith': true
            },
        ]
    });

}