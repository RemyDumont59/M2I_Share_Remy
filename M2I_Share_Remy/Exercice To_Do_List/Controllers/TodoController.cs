using Exercice02.Models;
using Exercice02.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercice02.Controllers
{
    public class TodoController : Controller
    {
        private readonly IRepository<Todo> _todoRepository;
        public TodoController(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {
            return View(_todoRepository.GetAll());
        }

        public IActionResult AfficherFormulaire()
        {
            return View("Formulaire");
        }

        public IActionResult ValiderFormulaire(Todo todo)
        {
            _todoRepository.Add(todo);
            return RedirectToAction("Index");
        }
        
        public IActionResult Check(int id)
        {
            var todoCheck = _todoRepository.GetById(id);
            

            todoCheck.Checked = !todoCheck.Checked;

            _todoRepository.Update(todoCheck);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {

            var todoDelete = _todoRepository.GetById(id);
            var todoCheck = _todoRepository.GetById(id);

            if (todoDelete.Checked != todoCheck.Checked)
                return View("Error");

            if (todoDelete == null)
                return View("Error");

            _todoRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}