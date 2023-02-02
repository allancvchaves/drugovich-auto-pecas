using DrugovichAutoPecas.API.Entities;

namespace DrugovichAutoPecas.API.Contracts
{
    public interface IGrupoRepository
    {
        Task<IEnumerable<Grupo>> GetAllGruposAsync();
        Task<Grupo> GetGrupoByIdAsync(int id);
        void AddGrupo(Grupo grupo);
        void UpdateGrupo(Grupo grupo);
        void DeleteGrupo(Grupo grupo);
    }
}
