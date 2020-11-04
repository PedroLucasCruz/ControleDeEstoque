using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using ControleEstoque.Interface;
using ControleEstoque.Models.Base;
using ControleEstoque.Business.Base;
using System.Web.UI.WebControls;
using System.Collections;

namespace ControleEstoque.Models
{
    //Como uma classe abstrata não serve pra ser estanciada você deve definir 
    //a classe com o a anotação abstract para que ela não seja estanciada
    public abstract class DAOabstract<T> : ICrud<T> where T : AbstractEntidadeDominio
    {   
        //Variavel "conn" com o tipo SqlConnection recebe a string de conexão
        protected SqlConnection conn;
        //Variavel que vai receber a string de conexão como parametro 
        protected String strConnection;
        
        //Variavel que recebe valor boleano que informa o que pode retornar
        protected bool conectado;

        //Cmd é usado na camada de Dao para que 
        protected SqlCommand cmd;

        //Result é implementado por que Dao usa a mesma interface que business
        protected Result<T> result;

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
                var teste = conn.State;
                conn.Open();                
                return conectado = true;                                
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        protected void desconectar()
        {
            if (conn.State.ToString() == "Open")
            {
                conn.Close();
            }          
        }

        protected bool VerificarConexao()
        {
            if(conn.State.ToString() == "Open")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Esse metodo de conexão conectar com o parametro de string passado 
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
        
        protected Object tipoDado(SqlDataReader sqlData, int indice)
        {
            try
            {
                int inCallBackData = Int32.Parse(sqlData.GetString(indice));
                return inCallBackData;
            }
            catch
            {
                string strCallBackData = sqlData.GetString(indice);
                return strCallBackData;
            }
        }
           

        public abstract Result<T> Alterar(T entidade);
        public abstract Result<T> Excluir(T entidade);
        public abstract Result<T> GetById(T entidade);
        public abstract Result<T> Listar();
        public abstract Result<T> Salvar(T entidade);

        public V CheckNull<V>(object obj)
        {
            return (obj == DBNull.Value ? default(V) : (V)obj);
        }

    }
}