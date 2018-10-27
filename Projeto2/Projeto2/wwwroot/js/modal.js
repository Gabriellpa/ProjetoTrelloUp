var oListas = JSON.parse(localStorage.getItem('listas'));
var backlog = [];
var todo = [];
var done = [];
function popularCampos() {
    var corpo;
    var att;

    corpo = document.getElementById('divModalAtiv'); 
    var ul = newElement('ul');
    for (let i = 0; i < oListas.length; i++) {
        var element = newElement('li');
		element.id = 'item' + i;
		element.onclick = function () { addLista(this) };
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

//Captura o item selecionado no Objeto oListas;
function addLista(el) {
	var dataValue = $('#' + el.id).attr('data-value');
	var oLista = oListas.filter(function (i, n) {
		return i.id === dataValue;
	});

	//Adicionar o oLista backlog, todo etc
	//se é backlog add no backlog
	backlog.push(oLista);
	//se é todo add no todo
	todo.push(oLista);
	//se é done add no done
	done.push(oLista);
}

function enviar() {
	//Ainda precisa tratar os dados de todos pois existe arrays dentro de arrays.
	var dados = {backlog: backlog , todo: todo, done: done};

	let url = 'Post';
	$.ajax({
		type: 'POST',
		data: JSON.stringify(dados),
		url: url,
		contentType: 'application/json'
	}).done(function (res) {
		console.log('enviou' , res);
		});

}