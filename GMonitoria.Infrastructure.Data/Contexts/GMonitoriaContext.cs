using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks; 
using GMonitoria.Domain.Entities.patterns;
using GMonitoria.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GMonitoria.Infrastructure.Data.Contexts
{
    public partial class GMonitoriaContext : DbContext, IDesignTimeDbContextFactory<GMonitoriaContext>
    {
        public virtual DbSet<GMonitoria.Domain.Entities.Aluno> Alunos{ get; set; }
        public virtual DbSet<Domain.Entities.ComponenteCurricular> ComponenteCurricular { get; set; }
        public virtual DbSet<Domain.Entities.Coordenador> Coordenador { get; set; }
        public virtual DbSet<Domain.Entities.Curso> Curso { get; set; }
        public virtual DbSet<Domain.Entities.HorarioAtendimento> HorarioAtendimento { get; set; }
        public virtual DbSet<Domain.Entities.Inscricao> Inscricao { get; set; }
        public virtual DbSet<Domain.Entities.InscricaoAceitacaoMonitoria> InscricaoAceitacaoMonitoria { get; set; }
        public virtual DbSet<Domain.Entities.InscricaoProva> InscricaoProva { get; set; }
        public virtual DbSet<Domain.Entities.InscricaoResultado> InscricaoResultado { get; set; } 
        public virtual DbSet<Domain.Entities.ProcessoSeletivo> ProcessoSeletivo { get; set; }
        public virtual DbSet<Domain.Entities.ProcessoSeletivoCurso> ProcessoSeletivoCurso { get; set; }
        public virtual DbSet<Domain.Entities.Professor> Professor { get; set; }
        public virtual DbSet<Domain.Entities.Prova> Prova { get; set; }
        public virtual DbSet<Domain.Entities.Vaga> Vaga { get; set; }
        public virtual DbSet<Domain.Entities.VagaRequisicao> VagaRequisicao { get; set; }

        public string CurrentUserId { get; set; }

        public GMonitoriaContext() : base() { }

        public GMonitoriaContext(DbContextOptions options) : base(options) { }

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

        public GMonitoriaContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            return new GMonitoriaContext(builder.Options);
        }
         
        public static void Main(string[] args)
        { 
        }
    }
}

//dotnet ef DbContext scaffold "Server=localhost;User Id=root;Password=root;Database=GMonitoria_V1" "Pomelo.EntityFrameworkCore.MySql" -c GMonitoriaContext
//dotnet ef migrations add InitialCreate --context GMonitoriaContextGenerate
//dotnet ef migrations add InitialMigration --context GMonitoriaContextGenerate
//dotnet ef migrations update --context GMonitoriaContextGenerate 