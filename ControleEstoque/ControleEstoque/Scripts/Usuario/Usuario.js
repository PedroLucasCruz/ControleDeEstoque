var gService = {

    //Carrega a lista dos status da solicitacao
    LoadTabela: () => {

        event.preventDefault();

        let vResponse = POST('/controller/actionDoController', JSON.stringify(gObjects.Filtro()));

        if (vResponse.Status) {
            gVariable.ListTabela = vResponse.Response;
            gView.RefreshTable();
        }
    }
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

    RefreshTable: () => {
    
        var linha = alimentarTabela(gVariable.ListTabela);
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
        }
    }

}

function criarLinhaTabelaUsuario(ListTabela) {

    var retorno = '';

    for (var i = 0; i < ListTabela.length; i++) {
       retorno = retorno + '<tr>'
            + '<th scope = "row" >'+ 1 +'</th>'
            + '<td>'+Mark+'</td>'
            + '<td>'+Otto+'</td>'
            + '<td>'+fat+'</td>'
            + '<td>'+Básico+'</td>'
            + '<td>'
            + '<a class="btn btn-warning" role="button">'
            + '<i class="glyphicon glyphicon-pencil" >  </i >'
            + '</a>'
            + '<a class="btn btn-danger btn-excluir" role="button">'
            + '<i class="glyphicon glyphicon-trash" >  </i >'
            + '</a>'
            + '</td>'
            + '</tr >';
    }  
    return retorno;
}

var gVariable = {

    ListTabela: [],
}


window.addEventListener('load', function () {
    gService.LoadTabela();
});