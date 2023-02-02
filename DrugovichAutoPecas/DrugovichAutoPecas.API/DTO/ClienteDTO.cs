using System.ComponentModel.DataAnnotations;

namespace DrugovichAutoPecas.API.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
        public int IdGrupo { get; set; }
    }
}
