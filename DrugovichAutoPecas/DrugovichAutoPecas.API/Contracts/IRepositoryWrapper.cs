namespace DrugovichAutoPecas.API.Contracts
{
    public interface IRepositoryWrapper
    {
        IGerenteRepository Gerente { get; }
        IGrupoRepository Grupo { get; }
        IClienteRepository Cliente { get; }
        Task SaveAsync();
    }
}
