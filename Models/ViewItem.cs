namespace GerenciadorTarefas.Models
{
    public class ViewItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }

        public ViewItem()
        {
        }

        public ViewItem(int id, string nome, string descricao, bool concluido)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Concluido = concluido;
        }
    }
}