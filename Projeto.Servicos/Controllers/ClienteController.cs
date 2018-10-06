using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Entidades;
using Projeto.DAL.Repositorios;
using Projeto.Servicos.Models;

namespace Projeto.Servicos.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        /*[HttpGet]
        [Route("hello")]
        public HttpResponseMessage HelloWorld(string nome)
        {
            return Request.CreateResponse(

                HttpStatusCode.OK,
                $"Ola {nome}, unheeeeeeeeee");
            
        }*/

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Cadastrar(ClienteCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = model.Nome;
                    c.Email = model.Email;

                    ClienteRepositorio rep = new ClienteRepositorio();
                    rep.Inserir(c);

                    return Request.CreateResponse(HttpStatusCode.OK,
                        "Cliente cadastrado com sucesso");
                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                List<string> erros = new List<string>();
                foreach(var m in ModelState)
                {
                    if(m.Value.Errors.Count > 0)
                    {
                        erros.Add(m.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
                    }
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, erros);
            }

        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Atualizar(ClienteEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;

                    ClienteRepositorio rep = new ClienteRepositorio();
                    rep.Atualizar(c);

                    return Request.CreateResponse(HttpStatusCode.OK,
                                                    "Cliente atualizado com sucesso.");

                }
                catch(Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                List<string> erros = new List<string>();

                foreach (var m in ModelState)
                {
                    if (m.Value.Errors.Count > 0)
                    {
                        erros.Add(m.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
                    }
                }


                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Excluir(int id)
        {
            try
            {
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ObterPorId(id);

                rep.Excluir(c);

                return Request.CreateResponse(HttpStatusCode.OK,
                                                "Cliente excluído com sucesso.");
            }
            catch(Exception e)
            {
                return Request.CreateResponse
                    (HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultartodos")]
        public HttpResponseMessage ConsultarTodos()
        {
            try
            {
                List<ClienteConsultaModel> lista = new List<ClienteConsultaModel>();

                ClienteRepositorio rep = new ClienteRepositorio();
                foreach(Cliente c in rep.ListarTodos())
                {
                    ClienteConsultaModel model = new ClienteConsultaModel();
                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;

                    lista.Add(model);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("consultarporid")]
        public HttpResponseMessage ConsultarPorId(int id)
        {
            try
            {
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = rep.ObterPorId(id);

                ClienteConsultaModel model = new ClienteConsultaModel();
                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
