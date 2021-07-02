using System;
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
        private string Senha { get; set; }
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

        public void AtribuirFoto(string _foto)
        {
            Foto = _foto;
        }

        public Usuario()
        {
            CriarPasta(CAMINHO);
        }

        public string PreparaLinha(Usuario u)
        {
            return $"{u.Email};{u.Nome};{u.NomeUsuario};{u.Senha};{u.Foto};{u.IdUsuario}";
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

            
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario usuario = new Usuario();
                
                usuario.Email = linha[0];
                usuario.Nome = linha[1];
                usuario.NomeUsuario = linha[2];
                usuario.Senha = linha[3];
                usuario.Foto = linha[4];
                usuario.IdUsuario = Int32.Parse(linha[5]);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public List<int> ReturnIds()
        {
            List<int> Ids = new List<int>();

            foreach (var item in Listar())
            {
                Ids.Add(item.IdUsuario);
            }

            return Ids;
        }

        public void AtribuirID()
        {
            IdUsuario = GerarId(ReturnIds());
        }

    }
}