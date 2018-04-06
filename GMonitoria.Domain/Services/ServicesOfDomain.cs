using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Interfaces.Domain;
using GMonitoria.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Domain.Services
{
    public class ServicesOfDomain : IServicesOfDomain
    {
        private readonly IBaseRepository<ProcessoSeletivo> _repositorioProcessoSeletivo;

        public ServicesOfDomain(IBaseRepository<ProcessoSeletivo> _repositorio)
        {
            this._repositorioProcessoSeletivo = _repositorio;
        }

        public bool Login(out string retorno)
        {
            throw new NotImplementedException();
        }
    }
}
