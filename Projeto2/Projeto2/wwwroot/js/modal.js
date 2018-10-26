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
	debugger;
	//Ainda precisa tratar os dados de todos pois existe arrays dentro de arrays.
	var data = { backlog: backlog, todo: todo, done: done}; //{ backlog: backlog, todo: todo, done: done};
	console.log(data);
	var data = { card: oListas[0] };
	// {empresa: empresa, datainicial: datainicial, datafinal: datafinal},
	let url = 'DataTrello';
	$.ajax({
		type: 'POST',
		data: JSON.stringify(oListas[0] ),
		url: url,
		contentType: 'application/json'
	}).done(function (res) {
		console.log('enviou' , res);
		});

	//var aaa = { folha: 'afdfr' }
	//let urls = 'teste';
	//$.ajax({
	//	type: "POST",
	//	data: JSON.stringify({ card: aaa }),
	//	url: urls,
	//	contentType: "application/json"
	//}).done(function (res) {
	//	console.log('enviou', res);
	//});

}