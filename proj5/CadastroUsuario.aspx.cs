using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Item 7.a  Ex.Lab 4 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace proj5
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        //Item 7.b Ex.Lab 4
        private SqlConnection conexao; //declaracao 

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Item 7.c Ex.Lab 4
        public void criarObjetoConexao() {
            try {
                //receber em STRCON a string conexao do web.config
                string strcon =
                   ConfigurationManager.ConnectionStrings["Usuarios"].ToString();
                //instanciar o objeto conexao;
                conexao = new SqlConnection(strcon);
            }
            catch (Exception ex) {
                throw new Exception("Erro Conexao:" + ex.Message);
            }
        }
        //========================= PROCESSA EVENTO CLICK DO BOTÃO FINALIZAR
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try {
                if (txtNomeUsuario.Text == String.Empty)
                    msgGeral.Text = "digite nome usuário";
                else
                if (txtEmail.Text == String.Empty)
                    msgGeral.Text = "digite email";
                else
                if (txtSenha.Text == String.Empty)
                    msgGeral.Text = "digite senha";
                else
                if (txtConfSenha.Text == String.Empty)
                    msgGeral.Text = "digite conf. senha";
                else
                if (txtConfSenha.Text != txtSenha.Text)
                    msgGeral.Text = "senhas não conferem";
                else
                {
                    Usuario objUsuario = new Usuario(txtNomeUsuario.Text, txtEmail.Text, txtSenha.Text);
                    IncluirUsuarioSessao(objUsuario);
                    try
                    {
                        // Chamar o método incluirUsuario para inserir o novo usuário no banco de dados
                        int idGerado = incluirUsuario(objUsuario);

                        // Mostrar uma mensagem de sucesso com o ID gerado
                        msgGeral.Text = "Usuário cadastrado com sucesso. ID gerado: " + idGerado.ToString() +Session["Usuario"];
                       
                    }
                    catch (Exception ex)
                    {
                        // Mostrar uma mensagem de erro caso ocorra uma exceção durante a inserção no banco de dados
                        msgGeral.Text = "Erro ao cadastrar usuário: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                msgGeral.Text = ex.Message;
            }
           
        }

        protected void btnConexao_Click(object sender, EventArgs e)
        {
            try {
                //Item 8.a Ex.Lab 4
                criarObjetoConexao();
                //abre conexao - uso a string conexao - CONECTAR
                conexao.Open();
                //Item 8.b Ex.Lab 4
                msgGeral.Text = "Conexao com sucesso";

            } catch (Exception ex) {
                msgGeral.Text = ex.Message;
            } finally
            {
                conexao.Close();
            }
        }

        public void IncluirUsuarioSessao(Usuario objUsu)
        {
            Session.Add("vUsuario", objUsu);
        }
        /*recebe um objeto "Usuario" como parâmetro*/
        public int incluirUsuario(Usuario objUsuario)
        {
            int idGerado = 0;
            try
            {
                /*objeto de Criação de conexão com o banco de dados*/
                criarObjetoConexao();
                /*conexão com o banco de dados é aberta e a instrução SQL é executada usando o método "ExecuteScalar()" do objeto "SqlCommand".*/
                conexao.Open();
                string inclusao = "INSERT INTO Usuarios (Nome, Email, Senha) VALUES(@nome, @email, @senha) SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(inclusao, conexao);
                /*Nessas linhas, um objeto "SqlCommand" é criado, que representa uma instrução SQL a ser executada no banco de dados. A instrução SQL é especificada como a string "inclusao" definida anteriormente.*/
                cmd.Parameters.AddWithValue("@nome", objUsuario.Nome);
                cmd.Parameters.AddWithValue("@email", objUsuario.Email);
                cmd.Parameters.AddWithValue("@senha", objUsuario.Senha);      
                idGerado = Convert.ToInt32(cmd.ExecuteScalar());
                return idGerado;
            } catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            } finally
            {
                conexao.Close();
            }
        }


    }
}
