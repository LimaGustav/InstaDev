using System;
using InstaDev.Controllers.Interfaces;

namespace InstaDev.Models
{
    public class Post
    {
        private string Titulo { get; set; }
        
        private string Imagem { get; set; }
        
        private Usuario PostadoPor { get; set; }
        
        private DateTime HoraPostagem { get; set; }

        private int IdPost { get; set; }

        public void Criar(Post p)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}