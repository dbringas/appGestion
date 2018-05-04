$(document).ready(function () {
    var tema = "bootstrap";

    if (document.getElementsByClassName("ctrlButton").length > 0) {
        $(".ctrlButton").jqxButton({
            width: 150,
            height: 25,
            theme: tema
        });
    }

    if (document.getElementsByClassName("ctrlInput").length > 0) {
        $(".ctrlInput").jqxInput({
            width: "100%",
            height: 25,
            theme: tema
        });
    }

    if (document.getElementsByClassName("ctrlPassInput").length > 0) {
        $(".ctrlPassInput").jqxPasswordInput({
            width: 200,
            height: 25,
            theme: tema,
            showPasswordIcon: false
        });
    }

    if (document.getElementsByClassName("ctrlNumInput").length > 0) {
        $(".ctrlNumInput").jqxNumberInput({
            width: "100%",
            height: 23,
            theme: tema,
            inputMode: "simple",
            spinButtons: true,
            decimalDigits: 0,
            min: 0
        });
    }

    if (document.getElementsByClassName("ctrlDecInput").length > 0) {
        $(".ctrlDecInput").jqxNumberInput({
            width: "100%",
            height: 23,
            theme: tema,
            inputMode: "simple",
            spinButtons: true,
            decimalDigits: 2,
            min: 0.0
        });
    }

    if (document.getElementsByClassName("ctrlDateTime").length > 0) {
        $(".ctrlDateTime").jqxDateTimeInput({
            width: 150,
            height: 23,
            theme: tema,
            culture: "es-PE",
            formatString: "dd/MM/yyyy",
            showCalendarButton: true
        });
    }

    if (document.getElementsByClassName("ctrlTextArea").length > 0) {
        $(".ctrlTextArea").jqxTextArea({
            width: "100%",
            height: 69,
            theme: tema,
            minLength: 1
        });
    }

    if (document.getElementsByClassName("ctrlCheckbox").length > 0) {
        $(".ctrlCheckbox").jqxCheckBox({
            theme: tema
        });
    }

    if (document.getElementsByClassName("ctrlRadio").length > 0) {
        $(".ctrlRadio").jqxRadioButton({
            theme: tema
        });
    }

    if (document.getElementsByClassName("ctrlDropDown").length > 0) {
        $(".ctrlDropDown").jqxDropDownList({
            width: "100%",
            height: 23,
            theme: tema,
            selectedIndex: 0,
            placeHolder: "Seleccione:"
        });
    }

    if (document.getElementsByClassName("ctrlComboBox").length > 0) {
        $(".ctrlComboBox").jqxComboBox({
            width: "100%",
            height: 23,
            theme: tema,
            placeHolder: "Seleccione:",
            autoComplete: false
        });
    }

    if (document.getElementsByClassName("ctrlListBox").length > 0) {
        $(".ctrlListBox").jqxListBox({
            width: "100%",
            height: 200,
            theme: tema
        });
    }

    if (document.getElementsByClassName("ctrlListBoxCheck").length > 0) {
        $(".ctrlListBoxCheck").jqxListBox({
            width: "100%",
            height: 200,
            theme: tema,
            checkboxes: true
        });
    }
    
    if (document.getElementsByClassName("ctrlGridFull").length > 0) {
        $(".ctrlGridFull").jqxGrid({
            width: "100%",
            height: 500,
            theme: tema,
            localization: getLocalization("es"),
            filterable: true,
            showfilterrow: true,
            sortable: true,
            showsortmenuitems: false,
            columnsresize: true
        });
    }

    if (document.getElementsByClassName("ctrlGridBasic").length > 0) {
        $(".ctrlGridBasic").jqxGrid({
            width: "100%",
            height: 500,
            theme: tema,
            localization: getLocalization("es"),
            filterable: false,
            sortable: false,
            columnsResize: true
        });
    }

    if (document.getElementsByClassName("ctrlGridMini").length > 0) {
        $(".ctrlGridMini").jqxGrid({
            width: "100%",
            height: 500,
            theme: tema,
            localization: getLocalization("es"),
            filterable: false,
            sortable: false,
            columnsResize: true,
            selectionmode: "none"
        });
    }

    if (document.getElementsByClassName("ctrlGridMiniCorto").length > 0) {
        $(".ctrlGridMiniCorto").jqxGrid({
            width: "100%",
            height: 200,
            theme: tema,
            localization: getLocalization("es"),
            filterable: false,
            sortable: false,
            columnsResize: true,
            selectionmode: "none"
        });
    }

    if (document.getElementsByClassName("ctrlGridMiniEdit").length > 0) {
        $(".ctrlGridMiniEdit").jqxGrid({
            width: "100%",
            height: 500,
            theme: tema,
            localization: getLocalization("es"),
            filterable: false,
            sortable: false,
            columnsResize: true,
            selectionmode: "multiplecellsadvanced",
            editable: true,
            enabletooltips: true
        });
    }

    if (document.getElementsByClassName("ctrlExplorador").length > 0) {
        $(".ctrlExplorador").jqxTree({
            width: "100%",
            height: 400,
            theme: tema
        });
    }
});

function datafieldsDinamicos(cabecera) {
    var obj = cabecera;
    var columnas = "[";

    for (var key in obj) {
        columnas += "{'name':'" + key + "', 'type':'string'},";
    }

    if (columnas.length > 1)
        columnas = columnas.substr(0, columnas.length - 1);

    columnas += "]";

    return columnas;
}

function columnasDinamicas(cabecera, clase, desde, ancho, formato = '') {
    var obj = cabecera;
    var columnas = "";
    var anchoCol = "";
    var valorCSS = "";
    var valorFormat = "";
    var acum = 0;

    if (ancho > 0)
        anchoCol = ", 'width':" + ancho;

    if (clase != "")
        valorCSS = ", 'cellclassname':" + clase;

    if (formato != "")
        valorFormat = ", 'cellsformat':'" + formato + "'";

    for (var key in obj) {
        if (acum >= desde)
            columnas += "{'text':'" + key + "', 'datafield':'" + key + "'" + anchoCol + valorCSS + valorFormat + "},";

        acum += 1;
    }

    if (columnas.length > 1)
        columnas = columnas.substr(0, columnas.length - 1);

    return columnas;
}

function exportar(control, nombre) {
    var fila = "";
    var index = $("#" + control).jqxGrid("getrows");

    if (index.length > 0) {
        if (confirm("¿Desea exportar la lista a excel?")) {
            $("#tablaexport").html("");

            var tabla = "<table id='tbTablaExportar'>";

            tabla += "<thead><tr>";

            var cols = $("#" + control).jqxGrid("columns");

            for (var i = 0; i < cols.records.length; i++) {
                tabla += "<th><b>" + cols.records[i].text + "</b></th>";
            }

            tabla += "</tr></thead><tbody>";

            for (var i = 0; i < index.length; i++) {
                fila = index[i];

                tabla += "<tr>";

                for (var j = 0; j < cols.records.length; j++) {
                    tabla += "<td>" + fila[cols.records[j].datafield] + "</td>";
                }

                tabla += "</tr>";
            }

            tabla += "</tbody></table>";

            $("#tablaexport").html(tabla);

            //$("#tablaexport").table2excel({
            //    exclude: ".noExl",
            //    name: nombre,
            //    filename: nombre + ".xls",
            //    fileext: ".xls"
            //});

            var table2excel = new Table2Excel();
            table2excel.export(document.querySelector("#tablaexport"));
        }
    }
    else
        alert("Debe de existir al menos una fila por exportar");
}