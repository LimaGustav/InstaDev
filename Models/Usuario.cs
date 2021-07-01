using System.Collections.Generic;

namespace InstaDev.Models
{
    public class Usuario
    {
        private string Nome { get; set; }
    
        private string Email { get; set; }
    
        private string NomeUsuario { get; set; }
    
        private string Foto { get; set; }

        private int IdUsuario { get; set; }

        

        public void Criar(Usuario u)
        {

        }
        
        public void Excluir(Usuario u)
        {

        }
        
        public void AlterarNome(Usuario u)
        {

        }
        
        public void AlterarNomeUsuario(Usuario u)
        {

        }
        
        public void AlterarSenha(Usuario u)
        {

        }
        
        public void AlterarImagem(Usuario u)
        {

        }
        
       public int RetornaId() {
           return IdUsuario;
       }
    }
}