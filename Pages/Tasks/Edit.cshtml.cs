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
            if (id <= 0) // Verifica se o ID é válido
            {
                return NotFound(); // Retorna 404 se o ID for inválido
            }

            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound(); // Retorna 404 se a tarefa não for encontrada
            }

            TaskItem = task;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna a página se o modelo for inválido
            }

            var taskInDb = await _context.Tasks.FindAsync(TaskItem.Id);
            if (taskInDb == null)
            {
                return NotFound(); // Retorna 404 se a tarefa não for encontrada
            }

            Console.WriteLine($"IsCompleted recebido no Edit: {TaskItem.IsCompleted}"); // Log para verificar o valor recebido

            // Atualiza os campos da tarefa
            taskInDb.Title = TaskItem.Title;
            taskInDb.Description = TaskItem.Description;
            taskInDb.DueDate = TaskItem.DueDate;
            taskInDb.IsCompleted = TaskItem.IsCompleted;

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Erro de concorrência ao salvar as alterações.");
                return Page(); // Retorna a página com o erro
            }

            return RedirectToPage("/Tasks/ViewAll"); // Redireciona para a página de listagem
        }
    }
}
