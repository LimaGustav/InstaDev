using System.Collections.Generic;
using InstaDev.Models;

namespace InstaDev.Interfaces
{
    public interface IPost
    {
        void Criar(Post p);

        void Excluir(int id);

        List<Post> Listar();
    }
}