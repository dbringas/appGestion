function getUrlParametros() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }

    return vars;
}

function getUrlControladores(controller, ruta) {
    var pathname = window.location.pathname;
    var sitio = window.location.pathname.substr(1, pathname.length - 1);
    var area = sitio.split("/")[0];
    var url = "";

    if (area == "")
        area = "Home";

    if (area != controller)
        url += "/" + area;

    url += "/" + controller + "/" + ruta;

    return url;
}