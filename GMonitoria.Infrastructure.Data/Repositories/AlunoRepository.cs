using GMonitoria.Domain.Interfaces.Repositories;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Domain.Entities.Aluno>, IAlunoRepository
    {
        public AlunoRepository(GMonitoriaContext context) : base(context) { }
    }
}
