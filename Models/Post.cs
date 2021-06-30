using System;

namespace InstaDev.Models
{
    public class Post
    {
        private string Titulo { get; set; }
        
        private string Imagem { get; set; }
        
        private Usuario PostadoPor { get; set; }
        
        private DateTime HoraPostagem { get; set; }

        private int IdPost { get; set; }
        
    }
}