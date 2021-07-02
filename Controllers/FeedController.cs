using System;
using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Post postModel = new Post();
        Usuario usuarioModel = new Usuario();

        [Route("Listar")]
        public IActionResult Index() {
            ViewBag.Posts = postModel.Listar();
            ViewBag.Usuarios = usuarioModel.Listar();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form) {
            Post novoPost = new Post();

            novoPost.AtribuiTitulo(form["TituloPost"]);
            novoPost.AtribuiId();

            // UPLOAD IMAGEM

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Posts");

                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/",folder,file.FileName);

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novoPost.AtribuiImagem(file.FileName);
            } else {
                novoPost.AtribuiImagem("padrao.png");
            }

            // FIM UPLOAD DE IMAGEM

            novoPost.AtribuiHoraPostagem(DateTime.Now);

            return LocalRedirect("~/Feed/Listar");
        }
    }
}