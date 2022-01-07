
$(document).ready(function () {
    llenarDataTablePrducts();
});
function llenarDataTablePrducts() {
    let table = $('#tablaListaProductos').DataTable({

        'ajax': {
            'url': 'Ahorros/ObtenerUsuariosConAhorros',
            'type': 'POST',
            'datatype': 'json'

        },

        'columns': [
            { 'data': 'IdUsuario', 'autoWith': true },
            { 'data': 'NombreCompleto', 'autoWith': true },
            { 'data': 'Cantidad', 'autoWith': true },
            { 'data': 'Total', 'autoWith': true },
            { 'data': 'FechaCobro', 'autoWith': true },
            { 'defaultContent': '<button type="button" title="Detalles" class="detalle btn btn-primary"><i class="fa fa-eye" aria-hidden="true" ></i></button >' }
        ]
    });

    botonDetalletabla('#tablaListaProductos tbody', table)
}