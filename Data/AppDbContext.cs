// filepath: /workspaces/gerenciador_tarefas/Data/AppDbContext.cs
using GerenciadorTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } // Certifique-se de que esta linha existe
    }
}