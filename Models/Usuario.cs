using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Usuario : classeBase
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
            string[] linha = {PreparaLinha(u)};
            File.AppendAllLines(CAMINHO, linha);
        }
        
        public void Excluir(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }
        
        public void Alterar(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[4] == u.IdUsuario.ToString());
            linhas.Add(PreparaLinha(u));
            ReescreverCSV(CAMINHO,linhas);
        }
            
    }
}