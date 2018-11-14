var oListas = JSON.parse(localStorage.getItem('listas'));
var backlog = [];
var todo = [];
var done = [];

function popularCampos(div) {    
    var corpo;
    var att;

    corpo = document.getElementById(div);
    corpo.style.display = "block";
    corpo.getElementsByClassName('titulo')[0].innerHTML = "Selecione lista para " + div.toUpperCase();


    var lista = new Array();
    var oListas = JSON.parse(localStorage.getItem('listas'));

    var usados = localStorage.getItem('listaUsadas');
    if (typeof (usados) !== undefined && usados !== 'undefined') {
        lista = usados.split(" ");
    }


    var ul = newElement('ul');    
    ul.classList.add("lista");
    for (let i = 0; i < oListas.length; i++) {

        if (lista.indexOf(oListas[i].id) < 0) {

            var element = newElement('li');
            var id = 'item' + i;
            element.id = id;
            att = document.createAttribute("data-value");
            att.value = oListas[i].id;
            element.setAttributeNode(att);
            element.innerHTML = oListas[i].name;
            element.onclick = function () {
                esconder(this);
                selectItem(oListas[i].id, div);
            };

            ul.append(element);
        }
    }
    corpo = document.getElementById(div + "List");
    corpo.innerHTML = "";
    corpo.append(ul);
}



function newElement(tipo) {
    var element = document.createElement(tipo);
    return element;
}


function finalizarEscolhas() {    
    addLista();
    enviar();
    limparLista();

}

//Captura o item selecionado no Objeto oListas;
function addLista() {

    var backlogList = localStorage.getItem('listasEscolhidasbackLog');
    var toDoList = localStorage.getItem('listasEscolhidastoDo');
    var doneList  = localStorage.getItem('listasEscolhidasdone');

    if (typeof backlogList !== undefined && backlogList !== "undefined") {
        backlogList = backlogList.split(" ");

        for (let j in backlogList) {
            let oLista = oListas.filter(function (i, n) {
                return i.id === backlogList[j];
            });
            backlog.push(oLista[0].id);
        }	
    }

    if (typeof toDoList !== undefined && toDoList !== "undefined") {
        toDoList = toDoList.split(" ");

        for (let j in toDoList) {
            let oLista = oListas.filter(function (i, n) {
                return i.id === toDoList[j];
            });
            todo.push(oLista[0].id);
        }	
    }

    if (typeof doneList !== undefined && doneList !== "undefined") {
        doneList = doneList.split(" ");

        for (let j in doneList) {
            let oLista = oListas.filter(function (i, n) {
                return i.id === doneList[j];
            });
            done.push(oLista[0].id);
        }	
    }

    
    

   



}

function enviar() {
	//Ainda precisa tratar os dados de todos pois existe arrays dentro de arrays.
	let dados = {backlog: backlog , todo: todo, done: done};

	let url = 'Post';
	$.ajax({
		type: 'POST',
		data: JSON.stringify(dados),
		url: url,
		contentType: 'application/json'
	}).done(function (res) {
        console.log('enviou', res);
        });
    
}

function voltarLista(listaAtual, listaAnterior) {
    var lista = localStorage.getItem('listasEscolhidas' + listaAtual);
    var listaTodos = localStorage.getItem('listaUsadas');
    var listaTodosArray = listaTodos.split(" ");
    lista = lista.split(" ");

    for (var i = 0; i < lista.length; i++) {
        var indexOf = listaTodosArray.indexOf(lista[i]);
        if (indexOf > 0) {
            listaTodosArray.splice(indexOf, 1);
        }
    }
    listaTodos = "";

    for (i = 0; i < listaTodosArray.length; i++) {
        listaTodos += listaTodosArray[i];

        if (i < listaTodosArray.length - 1) {
            listaTodos += " ";
        }
    }

    document.getElementById(listaAtual).style.display = "none";
    localStorage.setItem('listaUsadas', listaTodos);
    localStorage.setItem('listasEscolhidas' + listaAtual, undefined);
    popularCampos(listaAnterior);

}

function limparLista() {
    localStorage.setItem('listasEscolhidasbackLog', undefined);    
    localStorage.setItem('listasEscolhidastoDo', undefined);
    localStorage.setItem('listasEscolhidasdone', undefined);
	localStorage.setItem('listaUsadas', undefined);
	backlog.length = 0;
	todo.length = 0;
	done.length = 0;
    popularCampos('backLog');
}

function esconder(element) {
    element.style.display = 'none';
}


function selectedList(nomeLista) {

    corpo = document.getElementById(nomeLista);
    corpo.style.display = "none";

    if (nomeLista === 'backLog') {

        popularCampos('toDo');
    }
    if (nomeLista === 'toDo') {

        popularCampos('done');
    }
    if (nomeLista === 'done') {

        finalizarEscolhas();
    }

}


function selectItem(valueId, listName) {

    var nomeLista = 'listasEscolhidas' + listName;
    var selecionados = localStorage.getItem(nomeLista);
    var usados = localStorage.getItem('listaUsadas');

    if (typeof (selecionados) !== undefined && selecionados !== 'undefined') {

        if (selecionados.indexOf(valueId) === -1) {
            selecionados = selecionados + " " + valueId;
        }
    } else {
        selecionados = valueId;
    }

    if (typeof (usados) !== undefined && usados !== 'undefined') {

        if (usados.indexOf(valueId) === -1) {
            usados = usados + " " + valueId;
        }
    } else {

        usados = valueId;
    }



    localStorage.setItem(nomeLista, selecionados);
    localStorage.setItem('listaUsadas', usados);
}

function AtualizarPlanilha() {
    let url = 'Atualizar';
    $.ajax({
        type: 'PUT',        
        url: url,
        contentType: 'application/json'
    }).done(function (res) {
        console.log(res);
        });
    
}
