using AplicacaoCliente.Util;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AplicacaoCliente.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Site { get; set; }
        public string QuantidadeFuncionario { get; set; }
      

        public List<EmpresaModel> ListarTodos()
        {
            List<EmpresaModel> retorno = new List<EmpresaModel>();
            string json = WebAPI.RequestGET("listagem", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<EmpresaModel>>(json);
            return retorno; 
        }

        public EmpresaModel Carregar(int? id)
        {
            EmpresaModel retorno = new EmpresaModel();
            string json = WebAPI.RequestGET("Empresa", id.ToString());
            retorno = JsonConvert.DeserializeObject<EmpresaModel>(json);
            return retorno;
        }

        public void Inserir()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            string json = string.Empty;

            if (Id == 0)
            {
                WebAPI.RequestPOST("registrar", jsonData);
            }
            else
            {
                WebAPI.RequestPUT("atualizar/"+Id, jsonData);
            }
        }

        public void Excluir(int id)
        {            
            string json = WebAPI.RequestDELETE("excluir", id.ToString());            
        }
    }
}
