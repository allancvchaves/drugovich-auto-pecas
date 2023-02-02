using DrugovichAutoPecas.API.Entities;

namespace DrugovichAutoPecas.API.Contracts
{
    public interface IGerenteRepository
    {
        Task<IEnumerable<Gerente>> GetAllGerentesAsync();
        Task<Gerente> GetGerenteByIdAsync(int id);
        void AddGerente(Gerente gerente);
        void UpdateGerente(Gerente gerente);
        void DeleteGerente(Gerente gerente);
    }
}
