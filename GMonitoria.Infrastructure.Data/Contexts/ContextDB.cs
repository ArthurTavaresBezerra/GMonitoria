using Microsoft.EntityFrameworkCore;
using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using GMonitoria.Infrastructure.Data.Configuration;
using GMonitoria.Domain.Entities.patterns;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace GMonitoria.Infrastructure.Data.Contexts
{
    public class ContextDB : DbContext 
    {
        public string CurrentUserId { get; set; }
        public virtual DbSet<Departament> Usuarios { get; set; }
        public virtual DbSet<ItemType> PerfilUsuario { get; set; }
        public virtual DbSet<Item> ModulosAcesso { get; set; }
         
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {}



        protected override void OnModelCreating(ModelBuilder builder)
        { 

            builder.Entity<Departament>(entity =>
            {
                entity.HasKey(e => e.departament_id);
                entity.ToTable("Departament");
            });

            builder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.item_guid);
                entity.ToTable("Item");
            });

            builder.Entity<ItemType>(entity =>
            {
                entity.HasKey(e => e.item_type_id);
                entity.ToTable("ItemType");
            });
             
            /*
            builder.ApplyConfiguration(new DepartamentMap());
            builder.ApplyConfiguration(new ItemTypeMap());
            builder.ApplyConfiguration(new ItemMap());

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                ///////entityType.Relational().TableName = entityType.Name;

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }


            base.OnModelCreating(builder);*/
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=root;Database=sys");
            }
        } 


 
    }
}

// dotnet ef DbContext scaffold "Server=localhost;User Id=root;Password=root;Database=GMonitoria_V1" "Pomelo.EntityFrameworkCore.MySql" -c GMonitoriaContext

//dotnet ef migrations add InitialCreate

// dotnet ef migrations add InitialMigration --context ContextDB
// dotnet ef migrations update