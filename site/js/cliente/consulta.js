$(document).ready(function(){
    consultarClientes();
});

function consultarClientes(){
    $.ajax({
        type : "GET",
        url : "http://localhost:3763/api/cliente/consultartodos",
        data : {},
        success : function(d){
            var conteudo = "";
            for(var i = 0; i < d.length; i++){
                conteudo += "<tr>";
                     conteudo += "<td>" + d[i].IdCliente + "</td>";
                     conteudo += "<td>" + d[i].Nome + "</td>";
                     conteudo += "<td>" + d[i].Email + "</td>";
                    conteudo += "<td>";
                        conteudo += "<button class='btn btn-primary'>Alterar</button>";
                        conteudo += "&nbsp";
                        conteudo += "<button class='btn btn-danger' onclick='excluirCliente("+ d[i].idCliente +")'>Excluir</button>";
                    conteudo += "</td>";
                conteudo += "</tr>";
            }
            
            $("#tabela tbody").html(conteudo);
            $("#quantidade").html(d.length);
        },
        error : function(e){
            $("#mensagem").html(e.responseText);
        }

    });
}

function excluirCliente(idCliente){
    if(window.confirm('Deseja excluir?')){

        $.ajax({
            type : "DELETE",
            url : "http://localhost:3763/api/cliente/excluir?id=" + idCliente,
            success : function(d){
                $("#mensagem").html(d);
                consultarClientes();
            },
            error : function(e){
                $("#mensagem").html(e.responseText);
            }
        });
    };
}