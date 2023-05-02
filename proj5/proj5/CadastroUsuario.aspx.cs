using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Item 7.a  
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace proj5
{
   public partial class CadastroUsuario : System.Web.UI.Page
   {
      //Item 7.b
      private SqlConnection conexao; //declaracao 

      protected void Page_Load(object sender, EventArgs e)
      {

      }
      //Item 7.c
       public void criarObjetoConexao (){
         try{
         //receber em STRCON a string conexao do web.config
           string strcon = 
              ConfigurationManager.ConnectionStrings["strBDLoja"].ToString();
          //instanciar o objeto conexao;
               conexao = new SqlConnection(strcon);
         }catch (Exception ex){
           throw new Exception("Erro Conexao:"+ex.Message);               
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
           //Item 8.a
           criarObjetoConexao();
           //abre conexao - uso a string conexao - CONECTAR
           conexao.Open();
           //Item 8.b
           msgGeral.Text = "Conexao com sucesso";
           conexao.Close();
         } catch (Exception ex){
               msgGeral.Text = ex.Message;
           }
       }

       public void IncluirUsuarioSessao(Usuario objUsu)
       {
           Session.Add("vUsuario", objUsu);
       }


      
   }
}