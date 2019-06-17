using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MinhaWebAPI.Util;
using MinhaWebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace MinhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        readonly Autenticacao AutenticacaoServico;

        public EmpresaController(IHttpContextAccessor context)
        {            
            AutenticacaoServico = new Autenticacao(context);
        }
   
        [HttpGet]
        [Route("listagem")]
        public List<EmpresaModel> Listagem()
        {            
            return new EmpresaModel().Listagem();
        }
  
        [HttpGet]
        [Route("empresa/{id}")]
        public EmpresaModel RetornarEmpresa(int id)
        {
            return new EmpresaModel().RetornarEmpresa(id);
        }

        [HttpPost]        
        [Route("registrar")]
        public ReturnAllServices Registrar([FromBody]EmpresaModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Registrar();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar: " + ex.Message;
            }

            return retorno;
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody]EmpresaModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Id = id;
                dados.Atualizar();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar: " + ex.Message;
            }

            return retorno;
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Empresa excluída com sucesso!";
                AutenticacaoServico.Autenticar();
                new EmpresaModel().Excluir(id);

            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}
