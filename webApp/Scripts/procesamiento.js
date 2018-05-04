function processData(controller, view, parametros, seccion) {
    var url = getUrlControladores(controller, view);

    $.ajax({
        type: "post",
        url: url,
        data: parametros,
        dataType: "json",
        //beforeSend: function () {
        //    $("#carga").css("display", "block");
        //},
        //complete: function () {
        //    $("#carga").css("display", "none");
        //},
        contentType: "application/json; charset=utf-8",
        timeout: 180000
    }).done(function (data) {
        var rpta = data.result;
        var mensaje = data.content;

        if (rpta == "OK") {
            switch (seccion) {
                case 1:
                    var datos = $.parseJSON(mensaje);

                    if (datos.length > 0) {
                        var dataAdapter = new $.jqx.dataAdapter({ localdata: datos, datatype: "json", datafields: eval(datafieldsDinamicos(datos[0])) });

                        var columnas = "[" + columnasDinamicas(datos[0], "", 0, 0, "") + "]";

                        $("#listado").jqxGrid({
                            source: dataAdapter,
                            columns: eval(columnas)
                        });

                        $("#listado").jqxGrid("clearselection");
                        $("#listado").jqxGrid("refresh");
                    }
                    else
                        $("#listado").jqxGrid("clear");
                    break;

                case 2:
                    var datos = $.parseJSON(mensaje);

                    if (datos.length > 0) {
                        var fila = datos[0];

                        $("#txtCodigo").attr("data-operacion", "M");
                        $("#txtCodigo").val(fila.inCodCodigo);
                        $("#txtNombre").val(fila.stNombre);
                    }
                    break;

                case 3:
                    $.alert({
                        title: "Confirmación",
                        icon: "fa fa-info",
                        type: "green",
                        content: mensaje,
                        buttons: {
                            ok: function () {
                                window.location.href = getUrlControladores("Home", "Index");
                            }
                        }
                    });
                    break;
            }
        }
        else {
            $.alert({
                title: "Error",
                icon: "fa fa-exclamation",
                type: "red",
                content: mensaje,
            });
        }
    }).fail(function (response) {
        if (response.status != 0) {
            $.alert({
                title: "Error : " + response.status,
                icon: "fa fa-exclamation",
                type: "red",
                content: response.statusText,
            });
        }
        else
            console.log(response.statusText);
    });
}

function ejecutar(tipo) {
    switch (tipo) {
        case 1: // Consultar todo
            $("#listado").jqxGrid("showloadelement");
            processData("Home", "Consultar", "", 1);
            break;

        case 2: // Nuevo
            window.location.href = getUrlControladores("Home", "Detalle");
            break;

        case 3: // Modificar
            var index = $("#listado").jqxGrid("getselectedrowindex");

            if (index != -1) {
                var fila = $("#listado").jqxGrid("getrowdata", index);

                window.location.href = getUrlControladores("Home", "Detalle") + "?codigo=" + fila.inCodCodigo;
            }
            else {
                $.alert({
                    title: "Error",
                    icon: "fa fa-exclamation",
                    type: "orange",
                    content: "Debe de seleccionar una fila.",
                });
            }
            break;

        case 4: // Consultar según parametros url
            var parametros = {};

            parametros["codigo"] = getUrlVars()["codigo"];

            processData("Consultar", JSON.stringify(parametros), 2);
            break;

        case 5: // Eliminar
            $.confirm({
                title: "Confirmar",
                icon: "fa fa-question",
                type: "blue",
                content: "¿Esta seguro de eliminar la fila seleccionada?",
                buttons: {
                    Si: function () {
                        var parametros = {};

                        parametros["operacion"] = "E";
                        parametros["codigo"] = fila.inCodCodigo;

                        processData("Home", "Grabar", JSON.stringify(parametros), 3);
                    },
                    No: function () {
                        console.log("Operacion cancelada!");
                    }
                }
            });
            break;

        case 6: // Grabar
            $.confirm({
                title: "Confirmar",
                icon: "fa fa-question",
                type: "blue",
                content: "¿Esta seguro de grabar los datos ingresados?",
                buttons: {
                    Si: function () {
                        var parametros = {};

                        parametros["operacion"] = $("#txtCodigo").attr("data-operacion");
                        parametros["codigo"] = $("#txtCodigo").val();
                        parametros["nombre"] = $("#txtNombre").val();

                        processData("Home", "Grabar", JSON.stringify(parametros), 3);
                    },
                    No: function () {
                        console.log("Operacion cancelada!");
                    }
                }
            });
            break;

        default:
            $.alert({
                title: "Error",
                icon: "fa fa-exclamation",
                type: "orange",
                content: "No se puede identificar la acción requerida.",
            });
    }
}