using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GMonitoria.Infrastructure.Data.Exceptions;
using System; 
using System.Linq;
using System.Reflection;

namespace GMonitoria.Infrastructure.Data.Configuration
{
    public class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
        {
            PreConfigure(builder);
            ConfigureEntity(builder);
        }

        public virtual void ConfigureEntity(EntityTypeBuilder<TEntity> builder)
        {
           // string nameClass = builder.GetType().ReflectedType.Name;
           // throw new NotImplementedEntityBuilderException("Não implementada para a classe " + nameClass);
        }

        private void PreConfigure(EntityTypeBuilder<TEntity> builder)
        {
            string nameClass = builder.Metadata.ClrType.Name;
            /*
            builder.Property("CreatedBy").HasMaxLength(200).HasColumnType("varchar");
            builder.Property("UpdatedBy").HasMaxLength(200).HasColumnType("varchar");

            builder.Property("CreatedDate").HasColumnType("datetime");
            builder.Property("UpdatedDate").HasColumnType("datetime");


            var props = builder.Metadata.GetProperties();

             * 
             * 
            props.ToList().ForEach(delegate (IMutableProperty p)
            { 

                if (p.ClrType == typeof(string))
                    builder.Property(p.Name).HasMaxLength(200).HasColumnType("varchar");
                else if (p.ClrType == typeof(DateTime))
                    builder.Property(p.Name).HasColumnType("datetime");
                else if (p.ClrType == typeof(Int32) || p.ClrType == typeof(int))
                    builder.Property(p.Name).HasColumnType("int");
                else if (p.ClrType == typeof(float))
                    builder.Property(p.Name).HasColumnType("money");
                else if (p.ClrType == typeof(decimal))
                    builder.Property(p.Name).HasColumnType("money");           
            });


            builder.Property(c => c is string).HasMaxLength(200).HasColumnType("varchar");
            builder.Property(c => c.GetType() == typeof(DateTime)).HasColumnType("datetime");
            builder.Property(c => c.GetType() == typeof(int)).HasColumnType("varchar");
            builder.Property(c => c.GetType() == typeof(float)).HasColumnType("money");
            builder.Property(c => c.GetType() == typeof(decimal)).HasColumnType("money");
           
           

            builder.Metadata
                .GetProperties()
                   .Where(c => c.Name.ToLower() == nameClass.ToLower() + "_id" || c.Name.ToLower() == nameClass.ToLower() + "_guid")
                .ToList()
                .ForEach(delegate (IMutableProperty p)
                {
                    p.IsPrimaryKey();
                    p.ValueGenerated = ValueGenerated.Never;
                }); */
            
            //builder.ToTable(nameClass); 
        }

    }
}
