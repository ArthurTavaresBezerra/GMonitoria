using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GMonitoria.Domain.Entities;
using GMonitoria.Domain.Entities.patterns;
using GMonitoria.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GMonitoria.Infrastructure.Data.Contexts
{
    public partial class GMonitoriaContext : DbContext
    {
        public virtual DbSet<ComponenteCurricular> ComponenteCurricular { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<ProcessoSeletivo> ProcessoSeletivo { get; set; }
        public virtual DbSet<ProcessoSeletivoCurso> ProcessoSeletivoCurso { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Prova> Prova { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }
        public virtual DbSet<VagaRequisicao> VagaRequisicao { get; set; }
        public string CurrentUserId { get; set; }

        public GMonitoriaContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=root;Database=GMonitoria_V1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ComponenteCurricularMap());
            modelBuilder.ApplyConfiguration(new CoordenadorMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new HorarioAtendimentoMap());
            modelBuilder.ApplyConfiguration(new InscricaoMap());
            modelBuilder.ApplyConfiguration(new InscricaoAceitacaoMonitoriaMap());
            modelBuilder.ApplyConfiguration(new InscricaoProvaMap());
            modelBuilder.ApplyConfiguration(new InscricaoResultadoMap());
            modelBuilder.ApplyConfiguration(new ProcessoSeletivoMap());
            modelBuilder.ApplyConfiguration(new ProcessoSeletivoCursoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new ProvaMap());
            modelBuilder.ApplyConfiguration(new VagaMap());
            modelBuilder.ApplyConfiguration(new VagaRequisicaoMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (AuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }

    }
}
