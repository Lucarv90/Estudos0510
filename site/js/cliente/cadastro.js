$(document).ready(function(){
    $("#btncadastro").click(function(){
        cadastrarCliente();
    });
});

function cadastrarCliente(){

    $("#mensagem").html("Processando, aguarde...");
    $("#errosvalidacao").html("");

    var model = {
        Nome : $("#nome").val(),
        Email : $("#email").val()
    };

    $.ajax({
        type : "POST",
        url  : "http://localhost:3763/api/cliente/cadastrar",
        data : model,
        success : function(d){

            $("#mensagem").html(d);

            $("#nome").val("");
            $("#email").val("");
        },
        error: function(e){

            if(e.status == 500){
                $("#mensagem").html(e.status);
            }
            else if(e.status == 400){
                console.log(e);
                var conteudo = "<ul>";
                         for(var i = 0; i < e.responseJSON.length; i++){
                            conteudo += "<li>";
                            conteudo += e.responseJSON[i];
                            conteudo += "</li>";                         
                    }
                conteudo += "</ul>";

                $("#errosvalidacao").html(conteudo);
                $("#mensagem").html("");
            }            
        }
    });
}