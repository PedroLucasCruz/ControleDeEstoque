function exibir_form(dados) {

    //Aqui você pega toda a div marcado com Id="modal_cadastro"
    //joga ela para um variavel tipada para ser usado mais adiante na execução
    //
    var modal = $('#modal_cadastro');

    //aqui a função pega os valores passados como pametro e alimenta
    //os campos da modal
    $('#txt_nome').val(dados.Nome);
    $('#cbx_ativo').prop('checked', dados.Ativo);

    //Esse função bootbox.dialog é o que permite o inicio da manipulação da caixa modal
    //dentro da função dialog existe '{}' que representam os objetos para exibir no modal
    //Title o titulo do modal 
    //Messagem é o objeto que será exibido
    bootbox.dialog({
        title: 'Teste',
        message: modal
    })
        //Esta função é usada para exibir o modal, é uma função de dentro do doc
        //do framework do modal(pacote instalado na aplicação)
        .on('shown.bs.modal', function () {

            //A função é chamado com referencia ao objeto modal setado no inicio da função
            //Dentro da função show é usado as propriedades 
            modal.show(0, function () {
                $('#txt_nome').focus()
            });
        })
        .on('hidden.bs.modal', function () {
            //Novamente esta sendo chamado uma função de dentro do modal 
            //A função hide ocula o item 
            //a função appendTo retira o item da modal e devolver para o corpo da pagina
            modal.hide().appendTo('body');
        });
}


$(document).on('click', '#btn_incluir', function () {

    exibir_form({ Id: 0, Nome: '', Ativo: true });
})
    .on('click', '.btn-alterar', function () {
        var btn = $(this),
            id = btn.closest('tr').attr('data-id'),
            url = '@Url.Action("RecuperarGrupoProduto","Cadastro")',
            param = { 'id': id };

        $.post(url, param, function (response) {
            if (response) {
                exibir_form(response)
            }
        });

    })


    .on('click', '.btn-excluir', function () {
        alert('3');
    })

