namespace GerenciadorTarefas.Models
{
    public class EditItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Inicializado para evitar nulos
        public string? Description { get; set; } // Marcado como anulável
        public bool IsCompleted { get; set; }
        public DateTime LastUpdated { get; set; }

        public EditItem()
        {
            LastUpdated = DateTime.Now;
        }
    }
}