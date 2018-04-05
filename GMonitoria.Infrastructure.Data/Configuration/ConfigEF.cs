using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Configuration
{
    public class ProcessoSeletivoMap : EntityTypeConfiguration<ProcessoSeletivo>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProcessoSeletivo> builder)
        { 
            builder.ToTable("PROCESSO_SELETIVO");
            builder.Property(e => e.ProcessoSeletivoId).HasColumnName("PROCESSO_SELETIVO_ID").HasMaxLength(200);
            builder.Property(e => e.Datahora).HasColumnName("DATAHORA").HasColumnType("datetime");
            builder.Property(e => e.Periodo).IsRequired().HasColumnName("PERIODO").HasMaxLength(5);

            /*
            builder.Property(c => c.departament_id).HasMaxLength(200).HasColumnType("varchar");
            builder.Property(c => c.parent_departament_id).HasMaxLength(200).HasColumnType("varchar");

            builder.Property(c => c.xdepartament).HasColumnType("VARCHAR");

            builder.Property(c => c.xdepartament).IsRequired();
            builder.HasMany(t => t.departaments).WithOne(t => t.parent_departament).HasForeignKey(c => c.parent_departament_id);
            builder.HasOne(t => t.parent_departament)
                   .WithOne()
                   .HasForeignKey<Departament>(c=> c.departament_id); */
                  
        }
    }

    public class ItemTypeMap : EntityTypeConfiguration<ItemType>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ItemType> builder)
        {
            builder.Property(c => c.xitem_type).IsRequired(); 
        }
    }
     
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Item> builder)
        {
            builder.Property(c => c.xitem).IsRequired();
            builder.HasOne(c => c.item_type).WithMany(c => c.Items).HasForeignKey(c => c.item_type_id).IsRequired();
            builder.HasOne(c => c.departament).WithMany(c => c.Items).HasForeignKey(c => c.departament_id).IsRequired();
        }
    } 
}
