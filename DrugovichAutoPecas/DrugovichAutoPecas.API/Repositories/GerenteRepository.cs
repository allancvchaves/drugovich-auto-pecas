using DrugovichAutoPecas.API.Context;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugovichAutoPecas.API.Repositories
{
    public class GerenteRepository : RepositoryBase<Gerente>, IGerenteRepository
    {
        public GerenteRepository(AutoPecasContext context)
            : base(context) { }

        public async Task<IEnumerable<Gerente>> GetAllGerentesAsync() => await FindAll()
            .OrderBy(c => c.Nome)
            .ToListAsync();

        public async Task<Gerente> GetGerenteByIdAsync(int id) =>
            await FindByCondition(Gerente => Gerente.Id.Equals(id))
            .FirstOrDefaultAsync();

        public void AddGerente(Gerente gerente)
        {
            Create(gerente);
        }

        public void UpdateGerente(Gerente gerente)
        {
            Update(gerente);
        }

        public void DeleteGerente(Gerente gerente)
        {
            Delete(gerente);
        }
    }
}
