using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Usuario")]
    public class CadastroController : Controller
    {
        Usuario UsuarioModel = new Usuario();
        public string Mensagem { get; set; }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = UsuarioModel.Listar();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();

            List<string> UsuariosCSV = UsuarioModel.LerTodasLinhasCSV("Database/Usuario.csv");
            novoUsuario.AtribuirEmail(form["Email"]);
            novoUsuario.AtribuirNome(form["Nome"]);
            novoUsuario.AtribuirNomeUsuario(form["NomeUsuario"]);
            novoUsuario.AtribuirSenha(form["Senha"]);

            var verificarEmail = UsuariosCSV.Find(
                x =>
                x.Split(";")[0] == form["Email"]
            );

            var verificarNomeUsuario = UsuariosCSV.Find(
                x =>
                x.Split(";")[2] == form["NomeUsuario"]
            );

            if (verificarEmail != null && verificarNomeUsuario != null)
            {
                UsuarioModel.Criar(novoUsuario);
                Mensagem = "Parábens, você está cadastrado";
            }
            else if (verificarEmail == null && verificarNomeUsuario != null)
            {
                Mensagem = "Email já cadastrado";
            }
            else if (verificarEmail != null && verificarNomeUsuario == null)
            {
                Mensagem = "Nome de usuário já cadastrado";
            }
            else if (verificarEmail == null && verificarNomeUsuario == null)
            {
                Mensagem = "Nome de usuário e Email já cadastrados";
            }

            return LocalRedirect("~/Usuario/Index");
        }
    }
}