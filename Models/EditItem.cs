namespace GerenciadorTarefas.Models
{
    public class EditItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime LastUpdated { get; set; }

        public EditItem()
        {
            LastUpdated = DateTime.Now;
        }
    }
}