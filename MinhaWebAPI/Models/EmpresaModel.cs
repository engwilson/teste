using MinhaWebAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace MinhaWebAPI.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Site { get; set; }
        public string QuantidadeFuncionario { get; set; }

        public Random ran = new Random();

        public void Registrar()
        {
            DAL objDAL = new DAL();
            Id = ran.Next(0,9999);
            string sql = "insert into Empresa(Id,Nome,Site ,QuantidadeFuncionario) " +
                         $"values('{Id}','{Nome}','{Site}','{QuantidadeFuncionario}')";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Atualizar()
        {
            DAL objDAL = new DAL();

            string sql = "update Empresa set " +
                         $"Nome ='{Nome}'," +
                         $"Site='{Site}', " +
                         $"QuantidadeFuncionario='{QuantidadeFuncionario}'," +
                         $"where Id={Id}";            

            objDAL.ExecutarComandoSQL(sql);
        }    
        
        public void Excluir(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"delete from Empresa where Id = {id}";
            objDAL.ExecutarComandoSQL(sql);
        }

        public List<EmpresaModel> Listagem()
        {
            List<EmpresaModel> lista = new List<EmpresaModel>();
            EmpresaModel item;

            DAL objDAL = new DAL();

            string sql = "select * from Empresa order by Nome asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new EmpresaModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome = dados.Rows[i]["Nome"].ToString(),
                    Site = dados.Rows[i]["Site"].ToString(),
                    QuantidadeFuncionario = dados.Rows[i]["QuantidadeFuncionario"].ToString()
                };

                lista.Add(item);
            }
            return lista;
        }

        public EmpresaModel RetornarEmpresa(int id)
        {
            EmpresaModel item;
            DAL objDAL = new DAL();

            string sql = $"select * from Empresa where Id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);
       
            item = new EmpresaModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome = dados.Rows[0]["Nome"].ToString(),
                Site = dados.Rows[0]["Site"].ToString(),
                QuantidadeFuncionario = dados.Rows[0]["QuantidadeFuncionario"].ToString()
            };

            return item;
        }
    }
}
