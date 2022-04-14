using System;

namespace TokaDataAccess.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IPersonaFisicaRepositorio PersonaFisicaRepositorio { get; }
        public IAutenticacionUsuarioRepositorio AutenticacionUsuarioRepositorio { get; }
    }
}
