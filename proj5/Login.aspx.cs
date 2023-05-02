using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proj5
{
    using System;
    using System.Data.SqlClient;

    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection conexao;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void criarConexao()
        {
            string strConexao = ConfigurationManager.ConnectionStrings["Usuarios"].ToString();
            conexao = new SqlConnection(strConexao);
        }

        public Usuario consultarUsuario(string vEmail)
        {
            try
            {
                string consulta = "SELECT nome, email, senha FROM Usuarios WHERE email = @email";
                criarConexao();
                conexao.Open();
                SqlCommand comando = new SqlCommand(consulta, conexao);
                comando.Parameters.AddWithValue("@email", vEmail);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    string nome = reader["nome"].ToString();
                    string email = reader["email"].ToString();
                    string senha = reader["senha"].ToString();
                    return new Usuario(nome, email, senha);
                }
                else
                {
                    throw new Exception("Usuário não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                try
                {
                    Usuario usuario = consultarUsuario(txtEmail.Text);
                    if (usuario.Senha == txtSenha.Text)
                    {
                        Session["NomeUsusario"] = usuario.Nome;
                        Session["EmailUsuario"] = usuario.Email;
                        MsgGeral.Text = "identificação com sucesso"; 
                    }
                    else
                    {
                        MsgGeral.Text = "Senha incorreta";
                    }
                }
                catch (Exception ex)
                {
                    MsgGeral.Text = ex.Message;
                }finally
                {
                    Response.Redirect("Logado.aspx");
                }
            }
            else
            {
                MsgGeral.Text = "Preencha todos os campos";
            }
        }
    }
}




