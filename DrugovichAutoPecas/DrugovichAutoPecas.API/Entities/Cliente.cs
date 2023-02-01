namespace DrugovichAutoPecas.API.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
    }
}
