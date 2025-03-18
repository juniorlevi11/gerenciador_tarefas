using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Models
{
    public class TaskItem
    {
        public int Id { get; set; } // Identificador único da tarefa

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty; // Título da tarefa

        [StringLength(500)]
        public string? Description { get; set; } // Descrição da tarefa

        [Required]
        public DateTime DueDate { get; set; } // Data de vencimento da tarefa

        public bool IsCompleted { get; set; } = false; // Status da tarefa (completa ou não)
    }
}