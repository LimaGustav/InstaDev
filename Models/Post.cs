using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class Post : ClasseBase
    {
        private string Titulo { get; set; }
        
        public string Imagem { get; private set; }
        
        public Usuario PostadoPor { get; private set; }
        
        private DateTime HoraPostagem { get; set; }

        private int IdPost { get; set; }

        private const string CAMINHO = "Database/Post.csv";
        
        public Post() {
            CriarPasta(CAMINHO);
        }

        public string PrepararPost(Post p) {
            return $"{p.Titulo};{p.Imagem};{p.PostadoPor.IdUsuario};{p.HoraPostagem.ToString()};{p.IdPost.ToString()}";
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
            posts.Reverse();
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

        public int RetornaId() {
            return IdPost;
        }

        public string RetornaTitulo() {
            return Titulo;
        }
        
        public string RetornaImagem() {
            return Imagem;
        }

        public Usuario RetornaUsuario() {
            return PostadoPor;
        }

        public DateTime RetornaHora() {
            return HoraPostagem;
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