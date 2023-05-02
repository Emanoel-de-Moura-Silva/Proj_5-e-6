using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj5
{
    public class Usuario
    {
       //propriedades
        public int ID { get; set;}
        public string Nome { get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}

        //construtor 4 parametros
        public Usuario(int ID, string Nome, string Email, string Senha)
        {
            this.ID = ID;
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }
        //construtor com 3 parametros
        public Usuario(string Nome, string Email, string Senha)
        {

            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }
        
    }
}