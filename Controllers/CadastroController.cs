using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Usuario")]
    public class CadastroController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Usuario UsuarioModel = new Usuario();

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

            var usuarioJaCadastrado = UsuariosCSV.Find(
                x =>
                x.Split(";")[0] == form["Email"]
            );

            if (usuarioJaCadastrado == null)
            {
                novoUsuario.AtribuirEmail(form["Email"]);
                novoUsuario.AtribuirNome(form["Nome"]);
                novoUsuario.AtribuirNomeUsuario(form["NomeUsuario"]);
                novoUsuario.AtribuirSenha(form["Senha"]);
                novoUsuario.AtribuirFoto("padrao.png");
                novoUsuario.AtribuirID();

                UsuarioModel.Criar(novoUsuario);
                return LocalRedirect("~/Login");
            }
            else
            {
                Mensagem = "Email já cadastrado";
                return LocalRedirect("~/Usuario/Index");
            }
        }
    }
}