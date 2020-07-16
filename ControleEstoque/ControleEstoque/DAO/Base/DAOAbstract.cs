﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using ControleEstoque.Interface;

namespace ControleEstoque.Models
{
    //Como uma classe abstrata não serve pra ser estanciada você deve definir 
    //a classe com o a anotação abstract para que ela não seja estanciada
    public abstract class DAOabstract<T> : ICrud<T>
    {
        //Variavel "conn" com o tipo SqlConnection recebe a string de conexão
        protected SqlConnection conn;
        //Variavel que vai receber a string de conexão como parametro 
        protected String strConnection;

        //Variavel que recebe valor boleano que informa o que pode retornar
        protected bool conectado;


        protected bool conectar()
        {
            try
            {
                #region
                //Configuração de string vinda direto do webConfigu, segue trecho da chamada n webCofig abaixo

                //A string colocada no webcConfig deve ser 

                //<connectionStrings>
                //<add name="ConexaoStringPadrao" connectionString="Data Source=DESKTOP-5U7PVKK;Initial Catalog=controle_estoque;User Id=Controleestoque; Password=controle55" />
                //</connectionStrings>
                #endregion

                strConnection = ConfigurationManager.ConnectionStrings["ConexaoStringPadrao"].ConnectionString;

                //Para o trecho abaixo deve ser configurado a classe de criptografia 
                //strConnection = Criptografar.Decrypt(strConnection);

                conn = new SqlConnection(strConnection);
                conn.Open();
                return conectado = true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected bool conectar(String strConnection)
        {
            try
            {
                this.strConnection = ConfigurationManager.ConnectionStrings[strConnection].ConnectionString;
                //strConnection = Criptografar.Decrypt(strConnection);    
                conn = new SqlConnection(this.strConnection);
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public abstract bool Alterar(T entidade);
        public abstract bool Excluir(T entidade);
        public abstract List<T> GetById(T entidade);
        public abstract List<T> Listar(T entidade);
        public abstract bool Salvar(T entidade);
        

    }
}