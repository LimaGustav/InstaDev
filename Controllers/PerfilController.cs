using System;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        Usuario usuarioModel = new Usuario();
        Post postModel = new Post();

        [Route("Usuario")]
        public IActionResult Index()
        {
            Usuario secao =  usuarioModel.Listar().Find(x => x.RetornaId() == Int32.Parse(HttpContext.Session.GetString("_UsuarioId")));
            
            ViewBag.Posts = postModel.Listar();
            ViewBag.Usuario = usuarioModel.Listar();
            ViewBag.Secao = secao;

            return View();
        }
    }
}