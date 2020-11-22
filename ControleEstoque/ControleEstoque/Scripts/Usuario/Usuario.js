
var gService = {

    //Carrega a lista dos status da solicitacao
    LoadTabela: () => {

        let retorno = requisiçãoAjax('/Usuario/UsuariosListar', 'POST', '');
        gView.RefreshTable(retorno.Obj);
    },

    Inserir: (obj) => {
        let objetoUsuario = montarObjetoUsuario(obj);
        let callback = requisiçãoAjax('/Usuario/UsuarioSalvar', 'POST', objetoUsuario);
        if (callback) {
            alert('Incluido com sucesso');
        }
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


function requisiçãoAjax(urlRequisicao, tipoRequisicao, dados) {
    let retorno;
    $.ajax({
        url: urlRequisicao, //'/Usuario/UsuariosListar',
        async: false,
        type: tipoRequisicao, //URL solicitada
        data: dados,
        success: function (data) { //O HTML é retornado em 'data'

            retorno = data;
            //  gView.RefreshTable(data.Obj);

        }
    });
    return retorno;
}

function montarObjetoUsuario(obj) {

    var form = document.forms[0]
    var elements = form.elements;

    let retorno = {};

    retorno = {

        obj: {
            Nome: document.getElementById('inputNome').value,
            SobreNome: document.getElementById('inputSobreNome').value,
            Email: document.getElementById('inputEmail').value,
            Telefone: document.getElementById('inputTelefone').value,
            Celular: document.getElementById('inputCelular').value,
            Cnpj: document.getElementById('inputCnpj').value,
            Cpf: document.getElementById('inputCpf').value,
            Rg: document.getElementById('inputRg').value,
        } 
    };
    return retorno;
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
            retorno += strEstruturaTabela(ListTabela, i);
        }
        return retorno;
    }

    //caso você queira gerar apenas uma linha desta estrutura basta passar o objeto para preencher como parametro e o indice 0
    function strEstruturaTabela(ListTabela, i) {
        var retorno = retorno + '<tr>'
            + '<th scope = "row" data-id=' + ListTabela[i].Id + '>' + ListTabela[i].Id + '</th>'

            + '<td>' + ListTabela[i].Nome + '</td>'
            + '<td>' + ListTabela[i].SobreNome + '</td>'
            + '<td>' + formatContato(ListTabela, i) + '</td>'
            + '<td>' + formatarTipoPes(ListTabela, i) + '</td>'
            + '<td>' + FormatDateHours(ListTabela[i].DataNascimento) + '</td>'

            + '<td>'
            + '<a class="btn btn-warning" style="margin-right: 3px" role="button">'
            + '<i class="glyphicon glyphicon-pencil" >  </i >'
            + '</a>'
            + '<a class="btn btn-danger  btn-excluir" role="button">'
            + '<i class="glyphicon glyphicon-trash" >  </i>'
            + '</a>'
            + '</td>'
            + '</tr>';
        return retorno;
    }


    function formatContato(data, i) {

        if (data[i].Celular.length > 0) {
            return data[i].Celular;
        }
        else {
            return data[i].Telefone;
        }
    }

    function formatarTipoPes(data, i) {

        if (data[i].Cpf.length > 0) {
            return data[i].Cpf;
        }
        else if (data[i].cnpj != undefined) {
            if (data[i].cnpj.length > 0)
                return data[i].cnpj;
        }
        else if (data[i].Rg.length > 0) {
            return data[i].Rg;
        }
    }

    function FormatDateHours(paramValue) {
        var date, day, month, year, hour;

        date = new Date(parseInt(paramValue.substr(6)));

        day = date.getDate().toString().padStart(2, '0');
        month = (date.getMonth() + 1).toString().padStart(2, '0')
        year = date.getFullYear();

        hour = date.getHours().toString().padStart(2, '0');
        min = date.getMinutes().toString().padStart(2, '0');
        secs = date.getSeconds().toString().padStart(2, '0');

        return day + '/' + month + '/' + year + ' ' + hour + ':' + min + ':' + secs;
    }


    var gVariable = {

        ListTabela: [],
    }

    function enviarDadosBack(obj) {
        gService.Inserir(obj)
    }

    window.addEventListener('load', function () {
        gService.LoadTabela();
    });