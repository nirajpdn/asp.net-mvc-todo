using Microsoft.AspNetCore.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoModel> todos = new List<TodoModel>();
        public IActionResult Index()
        {
            return View(todos);
        }
        public IActionResult CreateTodo(TodoModel item)
        {
            todos.Add(item);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int id)
        {
            return View(todos.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult Edit(int id)
        {
            return View(todos.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult EditTodo(TodoModel editedTodo)
        {
            todos = todos.Where(item => item.Id == editedTodo.Id).Select(item => { item = editedTodo; return item; }).ToList();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            return View(todos.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult DeleteTodo(int id)
        {
            var todo = todos.SingleOrDefault(x => x.Id == id);
            if (todo != null)
                todos.Remove(todo);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            var todo = new TodoModel();
            return View(todo);
        }

    }
}