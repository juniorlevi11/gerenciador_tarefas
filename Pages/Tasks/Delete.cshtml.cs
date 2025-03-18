using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciadorTarefas.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public TaskItem TaskItem { get; set; } = new TaskItem();

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            TaskItem = _context.Tasks.Find(id);

            if (TaskItem == null)
            {
                return NotFound(); // Retorna 404 se o item não for encontrado
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var taskInDb = _context.Tasks.Find(id);

            if (taskInDb == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskInDb);
            _context.SaveChanges();

            return RedirectToPage("/Tasks/Index");
        }
    }
}
