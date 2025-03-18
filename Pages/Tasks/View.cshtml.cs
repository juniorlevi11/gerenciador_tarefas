using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciadorTarefas.Pages.Tasks
{
    [Authorize] // Remove ou ajuste esta linha se não for necessário
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
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound(); // Retorna 404 se o item não for encontrado
            }

            TaskItem = task; // Atribuição segura após a verificação

            return Page();
        }
    }
}
