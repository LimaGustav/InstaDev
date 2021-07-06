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
            ViewBag.Posts = postModel.Listar();
            ViewBag.Usuario = usuarioModel.Listar();
            ViewBag.NomeUsuario = HttpContext.Session.GetString("_nomeUsuario");
            ViewBag.Nome = HttpContext.Session.GetString("_nome");
            ViewBag.Foto = HttpContext.Session.GetString("_foto");
            return View();
        }
    }
}