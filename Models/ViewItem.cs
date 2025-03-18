namespace GerenciadorTarefas.Models
{
    public class ViewItem
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Nome da tarefa
        public string? Descricao { get; set; } // Descrição da tarefa
        public bool Concluido { get; set; } // Status de conclusão
        public DateTime DueDate { get; set; } // Data de vencimento
    }
}