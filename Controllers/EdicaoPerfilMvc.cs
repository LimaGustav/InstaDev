using System;
using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("AlterarPerfil")]
    public class EdicaoPerfilController : Controller
    {
        Usuario usuarioModel = new Usuario();


        public IActionResult Index()
        {
            Usuario secao =  usuarioModel.Listar().Find(x => x.RetornaId() == Int32.Parse(HttpContext.Session.GetString("_UsuarioId")));
            ViewBag.Secao = secao;
            ViewBag.Usuarios = usuarioModel.Listar();
            return View();
        }


        [Route("Alterar")]
        public IActionResult Alterar(IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();
            Usuario secao = usuarioModel.Listar().Find(x => x.RetornaId() == Int32.Parse(HttpContext.Session.GetString("_UsuarioId")));
            novoUsuario.AtribuirId(secao.RetornaId());
            novoUsuario.AtribuirEmail(secao.RetornaEmail());
            novoUsuario.AtribuirNome(form["Nome"]);
            novoUsuario.AtribuirNomeUsuario(form["NomeUser"]);
            novoUsuario.AtribuirSenha(form["Senha"]);
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Usuarios");

                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novoUsuario.AtribuirFoto(file.FileName);
            } else {
                novoUsuario.AtribuirFoto(secao.Foto);
            }
                secao.Alterar(novoUsuario);
                return LocalRedirect("~/AlterarPerfil");
        }

        [Route("Excluir")]
        public IActionResult Excluir(int id)
        {
            usuarioModel.Excluir(id);
            ViewBag.Usuarios = usuarioModel.Listar();
            return LocalRedirect("~/Login");
        }
    }
}