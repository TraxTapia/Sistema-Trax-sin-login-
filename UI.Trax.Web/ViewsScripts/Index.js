
function getCopagoByCodPrducto() {

    var object = {
        IdUsuario: $('#txtCodProducto').val(),

    };
    //ValidatorCodProducto.resetForm();
    $.ajax({
        //beforeSend: function () {
        //    $.blockUI({
        //        theme: true,
        //        message: '<div class="row"><div class="col-lg-12"><br /><p style="font-size:small; text-align: center;"><img src="/SASE/Content/assets/img/loading.gif" style="width: 35px;" /></p><p style="font-size:small; text-align: center;">Buscando Registros Espere un Momento Por favor...</p><br /></div></div>',
        //        baseZ: 10000
        //    });
        //},
        url: 'Home/ObtenerUsuarioById',
        type: 'POST',
        data: object,
        success: function (data) {
            if (data != undefined || data != null) {
                $('#divResult').html(data);
            }
        },
    });
}