namespace MyApi.Models
{
    // Classe abstrata
    public abstract class Bebida
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Bebida(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        // Método abstrato (polimorfismo)
        public abstract string Descricao();
    }
}