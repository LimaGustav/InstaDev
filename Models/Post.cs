using System;
using System.Collections.Generic;
using System.IO;
using InstaDev.Interfaces;

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

        public void Excluir(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[4] == IdPost.ToString());
            
            ReescreverCSV(CAMINHO,linhas);
        }

        public List<Post> Listar()
        {
            List<Post> posts = new List<Post>();
            Usuario user = new Usuario();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Post post = new Post();
                post.Titulo = linha[0];
                post.Imagem = linha[1];
                post.PostadoPor = user.Listar().Find(x => x.RetornaId().ToString() == linha[2]);
                post.HoraPostagem = Convert.ToDateTime(linha[3]);
                post.IdPost = Int32.Parse(linha[4]);

                posts.Add(post);
            }
            return posts;
        }

        public List<int> RetornaIds() {
            List<int> Ids = new List<int>();
            foreach (var item in Listar())
            {
                Ids.Add(item.IdPost);
            }
            return Ids;
        }

        public void AtribuiTitulo(string _titulo) {
            Titulo = _titulo;
        }

        public void AtribuiImagem(string _imagem) {
            Imagem = _imagem;
        }

        public void AtribuiPostadoPor(Usuario u){
            PostadoPor = u;
        }

        public void AtribuiHoraPostagem(DateTime d) {
            HoraPostagem = d;
        }

        public void AtribuiId() {
            IdPost = GerarId(RetornaIds());
        }

        public void AtribiuValores(string _titulo, string _imagem, Usuario u, DateTime d) {
            Titulo = _titulo;
            Imagem = _imagem;
            PostadoPor = u;
            HoraPostagem = d;
            AtribuiId();
        }
    }
}