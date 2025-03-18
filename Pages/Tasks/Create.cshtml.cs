// filepath: /workspaces/gerenciador_tarefas/Pages/Tasks/Create.cshtml.cs
using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciadorTarefas.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public TaskItem TaskItem { get; set; } = new TaskItem();

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Retorna a página se o modelo for inválido
            }

            Console.WriteLine($"IsCompleted recebido no Create: {TaskItem.IsCompleted}"); // Log para verificar o valor recebido

            _context.Tasks.Add(TaskItem); // Adiciona a nova tarefa ao banco de dados
            _context.SaveChanges();

            return RedirectToPage("/Tasks/ViewAll"); // Redireciona para a página de listagem
        }
    }
}