using DrugovichAutoPecas.API.Context;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugovichAutoPecas.API.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AutoPecasContext context)
            : base(context) { }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync() => await FindAll()
            .OrderBy(c => c.Nome)
            .ToListAsync();

        public async Task<Cliente> GetClienteByIdAsync(int id) =>
            await FindByCondition(cliente => cliente.Id.Equals(id))
            .FirstOrDefaultAsync();

        public void AddCliente(Cliente cliente)
        {
            Create(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            Update(cliente);
        }

        public void DeleteCliente(Cliente cliente)
        {
            Delete(cliente);
        }
    }
}
