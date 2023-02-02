using DrugovichAutoPecas.API.Context;
using DrugovichAutoPecas.API.Contracts;

namespace DrugovichAutoPecas.API.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AutoPecasContext _context;
        private IGerenteRepository _gerente;
        private IGrupoRepository _grupo;
        private IClienteRepository _cliente;

        public IGerenteRepository Gerente
        {
            get
            {
                if (_gerente == null)
                    _gerente = new GerenteRepository(_context);
                return _gerente;
            }
        }
        public IGrupoRepository Grupo
        {
            get
            {
                if (_grupo == null)
                    _grupo = new GrupoRepository(_context);
                return _grupo;
            }
        }
        public IClienteRepository Cliente
        {
            get
            {
                if (_cliente == null)
                    _cliente = new ClienteRepository(_context);
                return _cliente;
            }
        }

        public RepositoryWrapper(AutoPecasContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}