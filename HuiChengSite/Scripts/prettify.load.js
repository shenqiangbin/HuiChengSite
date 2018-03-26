window.onload = function () {
    var pres = document.getElementsByTagName('pre');
    for (var i = 0; i < pres.length; i++) {
        var item = pres[i];
        item.setAttribute('class', 'prettyprint');
    }
    prettyPrint();
};