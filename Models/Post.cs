using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Controllers.Interfaces;

namespace InstaDev.Models
{
    public class Post : ClasseBase, IPost
    {
        private string Titulo { get; set; }
        
        private string Imagem { get; set; }
        
        private Usuario PostadoPor { get; set; }
        
        private DateTime HoraPostagem { get; set; }

        private int IdPost { get; set; }

        private const string CAMINHO = "Database/post.csv";
        
        public Post() {
            CriarPasta(CAMINHO);
        }

        public string PrepararPost(Post p) {
            return $"{p.Titulo};{p.Imagem};{p.PostadoPor.RetornaId().ToString()};{p.HoraPostagem.ToString()};{p.IdPost.ToString()}";
        }

        public void Criar(Post p)
        {
            string[] linha = {PrepararPost(p)};
            File.AppendAllLines(CAMINHO,linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[4] == IdPost.ToString());
            
            ReescreverCSV(CAMINHO,linhas);
        }
    }
}