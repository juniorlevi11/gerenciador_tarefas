using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public TaskItem TaskItem { get; set; } = new TaskItem();

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            TaskItem = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (TaskItem == null)
            {
                return NotFound(); // Retorna 404 se o item não for encontrado
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == TaskItem.Id);

            if (taskToUpdate == null)
            {
                return NotFound();
            }

            // Atualize os campos da tarefa, incluindo o status de conclusão
            taskToUpdate.Title = TaskItem.Title;
            taskToUpdate.Description = TaskItem.Description;
            taskToUpdate.DueDate = TaskItem.DueDate;
            taskToUpdate.IsCompleted = TaskItem.IsCompleted;

            // Salve as alterações no banco de dados
            await _context.SaveChangesAsync();

            // Redirecione para a página de lista de tarefas
            return RedirectToPage("/Tasks/Index");
        }
    }
}
