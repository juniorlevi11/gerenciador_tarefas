using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            TaskItem = _context.Tasks.Find(id) ?? new TaskItem();

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

            var taskToUpdate = await _context.Tasks.FindAsync(TaskItem.Id);

            if (taskToUpdate == null)
            {
                return NotFound();
            }

            // Atualize os campos da tarefa
            taskToUpdate.Title = TaskItem.Title;
            taskToUpdate.Description = TaskItem.Description;
            taskToUpdate.DueDate = TaskItem.DueDate;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
