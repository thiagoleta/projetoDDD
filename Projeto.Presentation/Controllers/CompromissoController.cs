using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Application.Contracts;
using Projeto.Application.ViewModels;

namespace Projeto.Presentation.Controllers
{
    [RoutePrefix("api/Compromisso")]
    public class CompromissoController : ApiController
    {
        //atributo
        private readonly ICompromissoAppService appService;

        //construtor para injeção de dependência
        public CompromissoController(ICompromissoAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        public HttpResponseMessage Post(CompromissoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appService.Cadastrar(model);
                    return Request.CreateResponse
                        (HttpStatusCode.OK, "Contato cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }



        [HttpPut]
        public HttpResponseMessage Put(CompromissoEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appService.Atualizar(model);
                    return Request.CreateResponse
                        (HttpStatusCode.OK, "Contato atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse
                        (HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                appService.Excluir(id);

                return Request.CreateResponse
                       (HttpStatusCode.OK, "Contato excluido com sucesso");
            }
            catch (Exception e)
            {

                return Request.CreateResponse
                       (HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var model = appService.ConsultarTodos();

                return Request.CreateResponse
                       (HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {

                return Request.CreateResponse
                       (HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var model = appService.ConsultarPorId(id);

                return Request.CreateResponse
                       (HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {

                return Request.CreateResponse
                       (HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
