function popularCampos() {
    var corpo;
    var att;

    corpo = document.getElementById('divModalAtiv');
    var oListas = JSON.parse(localStorage.getItem('listas'));
    var ul = newElement('ul');
    for (let i = 0; i < oListas.length; i++) {
        var element = newElement('li');
        element.id = 'item' + i;
        att = document.createAttribute("data-value");
        att.value = oListas[i].id;
        element.setAttributeNode(att);
        element.innerHTML = oListas[i].name;
        ul.append(element);
    }
    corpo.append(ul);
}

function newElement(tipo) {
    var element = document.createElement(tipo);
    return element;
}