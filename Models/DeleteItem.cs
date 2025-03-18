namespace GerenciadorTarefas.Models
{
    public class DeleteItem
    {
        public int Id { get; set; }
        public string? Reason { get; set; }

        public DeleteItem(int id, string? reason = null)
        {
            Id = id;
            Reason = reason;
        }
    }
}