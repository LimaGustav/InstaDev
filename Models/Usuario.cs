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
        private string Senha  { get; set; }
        private const string CAMINHO = "Database/Usuario.csv";

        public void AtribuirEmail(string _email)
        {
            Email = _email;
        }

        public void AtribuirNome(string _nome)
        {
            Nome = _nome;
        }

        public void AtribuirNomeUsuario(string _nomeUsuario)
        {
            NomeUsuario = _nomeUsuario;
        }

        public void AtribuirSenha(string _senha)
        {
            Senha = _senha;
        }

        public Usuario()
        {
            CriarPasta(CAMINHO);
        }

        public string PreparaLinha(Usuario u)
        {
            return $"{u.Email};{u.Nome};{u.NomeUsuario};{u.Senha}";
        }

        public void Criar(Usuario u)
        {
            string[] linha = { PreparaLinha(u) };
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

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();

            return usuarios; 
        }
        
        
    }
}