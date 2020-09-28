var gService = {

    //Carrega a lista dos status da solicitacao
    LoadTabela: () => {

        event.preventDefault();


        $.ajax({
            url: '/Usuario/UsuariosListar',
            type: 'POST', //URL solicitada
            success: function (data) { //O HTML é retornado em 'data'

                gView.RefreshTable(data.Obj);

            }
        });
    }


        //if (vResponse.Status) {
        //    gVariable.ListTabela = vResponse.Response;
        //    gView.RefreshTable();
        //}
    
    //Exempllo de outro objeto implementado
    //Delete: (pID) => {

    //    let vResponse = POST('/Classificacao/Excluir', JSON.stringify({ id: pID }));

    //    if (vResponse.Status) {
    //        showMessage('success', 'Sucesso', 'Classificação Excluída');
    //        gVariable.ListClassificacao = gVariable.ListClassificacao.filter((data) => data.id != pID);
    //        gView.RefreshTable();
    //    }

    //    else
    //        showMessage('error', 'Oops...', concatMessages(vResponse.MensagemExcessao));
    //}
}

var gView = {

    RefreshTable: (data) => {
    
        var linha = criarLinhaTabelaUsuario(data);
        var table = $('#grid_usuario').find('tbody');
        table.append(linha);
    },

    RemoverClassificacao: (pID) => {

        ConfirmDelete('Deseja excluir a Classificação ?', gService.Delete, pID);
    },

    Forms: {

        Filtro: () => { return document.querySelector('#FormFiltro') }

    },

    Fields: {

        Element: {
            Classificacao: () => { return document.querySelector('#cla_descricao') }
        },

        Value: {
            Classificacao: () => { return document.querySelector('#cla_descricao').value }
        },

        CleanValue: () => {

            gView.Fields.Value.Classificacao() = ''
        },

        LoadTableComplete: () => {
            var tabela = document.createElement("table");
            var cabecalho = document.createElement("thead");
            var corpo = document.createElement("tbody");

            tabela.appendChild(cabecalho);
            tabela.appendChild(corpo);

            document.getElementById("test").appendChild(tabela);
        }
    }

}

function criarLinhaTabelaUsuario(ListTabela) {

    var retorno = '';

    for (var i = 0; i < ListTabela.length; i++) {
       retorno = retorno + '<tr>'
           + '<th scope = "row" data-id=' + ListTabela[i].Id + '>' + ListTabela[i].Id +'</th>'
           + '<td>' + ListTabela[i].Nome+'</td>'
           + '<td>' + ListTabela[i].SobreNome+'</td>'
            + '<td>'+"teste 1"+'</td>'
            + '<td>'+"teste 2"+'</td>'
            + '<td>'
            + '<a class="btn btn-warning" role="button">'
            + '<i class="glyphicon glyphicon-pencil" >  </i >'
            + '</a>'
            + '<a class="btn btn-danger style="margin-right: 3px" btn-excluir" role="button">'
            + '<i class="glyphicon glyphicon-trash" >  </i >'
            + '</a>'
            + '</td>'
            + '</tr >';
    }  
    return retorno;
}

function linhaTabela(){

}

var gVariable = {

    ListTabela: [],
}


window.addEventListener('load', function () {
    gService.LoadTabela();
});