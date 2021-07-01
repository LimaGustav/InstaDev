using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Usuario : ClasseBase
    {
        private string Nome { get; set; }
    
        private string Email { get; set; }
    
        private string NomeUsuario { get; set; }
    
        private string Foto { get; set; }

        private int IdUsuario { get; set; }

        private const string CAMINHO = "Database/Usuario.csv";

        public Usuario()
        {
            CriarPasta(CAMINHO);
        }

        public string PreparaLinha(Usuario u)
        {
            return $"{u.Nome};{u.Email};{u.NomeUsuario};{u.Foto};{u.IdUsuario}";
        }

        public void Criar(Usuario u)
        {
            string[] linha = {PreparaLinha(j)};
            File.AppendAllLines(CAMINHO, linha);
        }
        
        public void Excluir(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
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