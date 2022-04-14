using TokaDataAccess.Repository.Interfaces;

namespace TokaDataAccess.Repository.Implementaciones
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TokaDBContext _context;
        private IPersonaFisicaRepositorio _personaFisicaRepositorio;
        private IAutenticacionUsuarioRepositorio _autenticacionUsuarioRepositorio;

        public UnitOfWork(TokaDBContext context)
        {
            this._context = context;

        }
        public IPersonaFisicaRepositorio PersonaFisicaRepositorio
        {
            get { return _personaFisicaRepositorio ?? (_personaFisicaRepositorio = new PersonaFisicaRepositorio(_context)); }
        }

        public IAutenticacionUsuarioRepositorio AutenticacionUsuarioRepositorio
        {
            get { return _autenticacionUsuarioRepositorio ?? (_autenticacionUsuarioRepositorio = new AutenticacionUsuarioRepositorio(_context)); }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
