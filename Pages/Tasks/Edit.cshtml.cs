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
            TaskItem = _context.Tasks.Find(id);

            if (TaskItem == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var taskInDb = _context.Tasks.Find(TaskItem.Id);

            if (taskInDb == null)
            {
                return NotFound();
            }

            taskInDb.Title = TaskItem.Title;
            taskInDb.Description = TaskItem.Description;
            taskInDb.DueDate = TaskItem.DueDate;
            taskInDb.IsCompleted = TaskItem.IsCompleted;

            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}
