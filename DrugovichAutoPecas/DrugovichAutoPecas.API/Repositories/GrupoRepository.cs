using DrugovichAutoPecas.API.Context;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugovichAutoPecas.API.Repositories
{
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
    {
        public GrupoRepository(AutoPecasContext context)
            : base(context) { } 
        public async Task<IEnumerable<Grupo>> GetAllGruposAsync() => await FindAll()
            .OrderBy(c => c.Nome)
            .ToListAsync();

        public async Task<Grupo> GetGrupoByIdAsync(int id) =>
            await FindByCondition(grupo => grupo.Id.Equals(id))
            .FirstOrDefaultAsync();

        public void AddGrupo(Grupo grupo)
        {
            Create(grupo);
        }

        public void UpdateGrupo(Grupo grupo)
        {
            Update(grupo);
        }

        public void DeleteGrupo(Grupo grupo)
        {
            Delete(grupo);
        }
    }
}
