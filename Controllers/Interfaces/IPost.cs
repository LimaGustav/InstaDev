using InstaDev.Models;

namespace InstaDev.Controllers.Interfaces
{
    public interface IPost
    {
        void Criar(Post p);

        void Deletar(int id);
    }
}