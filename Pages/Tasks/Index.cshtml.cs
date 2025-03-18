using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Tasks = _context.Tasks.ToList();
        }
    }
}
