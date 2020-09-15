using Antlr.Runtime.Tree;
using ControleEstoque.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ControleEstoque.Models
{
    public class UsuarioModel
    {
        public static bool ValidarLogin(String Login, String Senha)
        {   
            var ret = false;

            #region
            //Estanciar a conexão com o banco de dados para uso
            #endregion
            var conexao = new SqlConnection(); //Nesta sessão foi retirado o Using que estava isolando a estancia

            #region
            //Definir a conexão da string, para saber qual o banco de dados com conexao.ConnectionString
            //Para a String de conexão você pode utilizar o seguinte texto
            //Data Source: aqui você diz onde esta seu banco,em nuvem ou na sua maquina(local rosto), ou um endereço IP de servidor
            //Initial Catalogo: este é o nome de seu data base(Sua base de dados) que deve ser atribuida
            //User: como todo banco de dados precisa de permissão, aqui você de finie o usuario que será usado para a conexão
            //Passaword: para completar a autenticação dos servidores você utiliza a senha
            //String completa fica da seguinte forma a baixo
            //"Dara Source=localhost;Initial Catalog=controle-estoque; User id=admin;Passaword=123";
            #endregion
            conexao.ConnectionString = @"Data Source=DESKTOP-5U7PVKK;Initial Catalog=controle_estoque;User Id=Controleestoque;Password=controle55";
            #region
            //Abrir a conexão com o banco de dados por padrão toda vez que for usada na aplicação
            #endregion
            conexao.Open();
            #region
            //Para usar o comando você precisa estanciar lo antes de tudo
            #endregion
            var comando = new SqlCommand(); //Nesta sessão foi retirado o Using que estava isolando a estancia
          
            #region
            //Aqui você associa a sua conexão com o seu comando 
            #endregion
            comando.Connection = conexao;
            #region
            //Aqui você define o tipo de uso do seu Comando, o que vc vai executar no banco
            //Por se estar usando o provider do Sql(System.Data.sqlCliente) essa query usada é especifica para o Sql
            //String format pegar as variaveis definidas nos campos com '{}' e alinha o que vc digitar sequencialmente
            //Nessa linha você retorna o a quantidade de linhas encontradas no banco de dados de acordo com os parametros informados
            #endregion
            comando.CommandText = string.Format("Select count(*) from Logins where Login = @login and Senha = @Senha ");
            
            comando.Parameters.Add("@login", SqlDbType.VarChar).Value = Login;
            comando.Parameters.Add("@Senha", SqlDbType.VarChar).Value = Cryptography.HashMd5(Senha);
            
            #region
            //Quando você precisa retornar valor você utilizar o ExecuteScalar que está dentro do comando
            //No caso da query a cima você está retornando um valor inteiro
            //Como o retorno do banco volta como tipo objeto, é preciso fazer um casting, que é forçar o tipo de retorno
            //Convertendo o que foi retornado do banco para outra coisa, neste caso vamos converte com (int) 
            #endregion
            int valor = (int)comando.ExecuteScalar();

            #region
            //Como "ret" é uma variavel tipada, ela vai ter seu tipo definido de acordo com o que for recebido
            //Ou Seja, na condição a baixo esxite uma condição booleada, então seu tipo vai ser booleano 
            //Ou "ret" recebe falso ou Recebe true
            #endregion
            ret = ((int)comando.ExecuteScalar() > 0);

            return ret;
        }
    }
}