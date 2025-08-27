using MyApi.Models;

namespace MyApi.Services
{
    public class BebidaService
    {
        private readonly List<Bebida> _bebidas = new();
        private int _nextId = 1;

        // Criar bebida não alcoólica
        public Bebida CreateBebida(string nome)
        {
            var bebida = new BebidaNaoAlcoolica(_nextId++, nome);
            _bebidas.Add(bebida);
            return bebida;
        }

        // Criar bebida alcoólica
        public Bebida CreateBebidaAlcoolica(string nome, double teorAlcoolico)
        {
            var bebida = new BebidaAlcoolica(_nextId++, nome, teorAlcoolico);
            _bebidas.Add(bebida);
            return bebida;
        }

        public List<Bebida> GetAll() => _bebidas;

        public Bebida? GetById(int id) => _bebidas.FirstOrDefault(b => b.Id == id);
    }

    // Classe concreta para bebidas não alcoólicas
    public class BebidaNaoAlcoolica : Bebida
    {
        public BebidaNaoAlcoolica(int id, string nome) : base(id, nome) { }

        public override string Descricao() => $"{Nome} sem álcool";
    }
}
