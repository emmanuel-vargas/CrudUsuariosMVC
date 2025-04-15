using Microsoft.AspNetCore.Mvc;
using CrudUsuariosMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudUsuariosMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private static List<Usuario> usuarios = new();
        private static int contador = 1;

        public IActionResult Index() => View(usuarios);

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            usuario.Id = contador++;
            usuarios.Add(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            var original = usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (original != null)
            {
                original.Nombre = usuario.Nombre;
                original.Correo = usuario.Correo;
                original.Rol = usuario.Rol;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null) usuarios.Remove(usuario);
            return RedirectToAction("Index");
        }
    }
}