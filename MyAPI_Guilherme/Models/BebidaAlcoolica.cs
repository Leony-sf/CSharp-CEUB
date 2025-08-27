namespace MyApi.Models
{
    // Herança da classe Bebida
    public class BebidaAlcoolica : Bebida
    {
        public double TeorAlcoolico { get; set; }

        public BebidaAlcoolica(int id, string nome, double teorAlcoolico) 
            : base(id, nome)
        {
            TeorAlcoolico = teorAlcoolico;
        }

        // Implementação do método abstrato (polimorfismo)
        public override string Descricao()
        {
            return $"{Nome} com {TeorAlcoolico}% de álcool";
        }
    }
}
