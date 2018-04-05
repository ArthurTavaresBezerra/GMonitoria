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
        private readonly IBaseRepository<Item> _repositorioBaseItem;

        public ServicesOfDomain(IBaseRepository<Item> _repositorio)
        {
            this._repositorioBaseItem = _repositorio;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _repositorioBaseItem.GetAll();
        }
    }
}
