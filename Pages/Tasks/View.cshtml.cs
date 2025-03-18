using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciadorTarefas.Pages.Tasks
{
    public class ViewModel : PageModel
    {
        private readonly AppDbContext _context;

        public TaskItem TaskItem { get; set; } = new TaskItem();

        public ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            TaskItem = _context.Tasks.Find(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
