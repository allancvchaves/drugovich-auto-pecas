using DrugovichAutoPecas.API.Entities;

namespace DrugovichAutoPecas.API.Contracts
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        void AddCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(Cliente cliente);
    }
}
