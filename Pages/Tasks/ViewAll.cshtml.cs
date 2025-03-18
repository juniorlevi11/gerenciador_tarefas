using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas.Pages.Tasks
{
    public class ViewAllModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<ViewItem> Items { get; set; } = new List<ViewItem>();

        public ViewAllModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Items = _context.Tasks
                .Select(t => new ViewItem
                {
                    Id = t.Id,
                    Nome = t.Title,
                    Descricao = t.Description,
                    Concluido = t.IsCompleted,
                    DueDate = t.DueDate // Certifique-se de que esta propriedade existe no banco de dados
                })
                .ToList();
        }
    }
}
