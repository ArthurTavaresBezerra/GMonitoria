using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GMonitoria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMonitoria.Infrastructure.Data.Configuration
{
    
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Aluno> entity)
        {
            entity.HasKey(e => e.Matricula);

            entity.ToTable("ALUNO");

            entity.Property(e => e.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(200);

            entity.Property(e => e.Xaluno)
                .IsRequired()
                .HasColumnName("XALUNO")
                .HasMaxLength(200);
        }
    }
    public class ComponenteCurricularMap : EntityTypeConfiguration<ComponenteCurricular>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ComponenteCurricular> entity)
        {
            entity.ToTable("COMPONENTE_CURRICULAR");

            entity.HasIndex(e => e.CursoId)
                .HasName("FK_COMPONENTE_CURRICULAR_CURSO");

            entity.HasIndex(e => e.ProfessorId)
                .HasName("FK_COMPONENTE_CURRICULAR_PROFESSOR");

            entity.Property(e => e.ComponenteCurricularId)
                .HasColumnName("COMPONENTE_CURRICULAR_ID")
                .HasMaxLength(200);

            entity.Property(e => e.CursoId)
                .IsRequired()
                .HasColumnName("CURSO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.ProfessorId)
                .IsRequired()
                .HasColumnName("PROFESSOR_ID")
                .HasMaxLength(200);

            entity.Property(e => e.XcomponenteCurricular)
                .IsRequired()
                .HasColumnName("XCOMPONENTE_CURRICULAR")
                .HasMaxLength(200);

            entity.HasOne(d => d.Curso)
                .WithMany(p => p.ComponenteCurricular)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTE_CURRICULAR_CURSO");

            entity.HasOne(d => d.Professor)
                .WithMany(p => p.ComponenteCurricular)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPONENTE_CURRICULAR_PROFESSOR");
        }
    }

    public class CoordenadorMap : EntityTypeConfiguration<Coordenador>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Coordenador> entity)
        {
            entity.ToTable("COORDENADOR");

            entity.HasIndex(e => e.CursoId)
                .HasName("FK_COORDENADOR_CURRICULAR_CURSO");

            entity.Property(e => e.CoordenadorId)
                .HasColumnName("COORDENADOR_ID")
                .HasMaxLength(200);

            entity.Property(e => e.CursoId)
                .IsRequired()
                .HasColumnName("CURSO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Xcoordenador)
                .IsRequired()
                .HasColumnName("XCOORDENADOR")
                .HasMaxLength(200);

            entity.HasOne(d => d.Curso)
                .WithMany(p => p.Coordenador)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COORDENADOR_CURRICULAR_CURSO");
        }
    }

    public class CursoMap : EntityTypeConfiguration<Curso>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Curso> entity)
        {
            entity.ToTable("CURSO");

            entity.Property(e => e.CursoId)
                .HasColumnName("CURSO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Xcurso)
                .IsRequired()
                .HasColumnName("XCURSO")
                .HasMaxLength(200);
        }
    }


    public class HorarioAtendimentoMap : EntityTypeConfiguration<HorarioAtendimento>
    {
        public override void ConfigureEntity(EntityTypeBuilder<HorarioAtendimento> entity)
        {
            entity.ToTable("HORARIO_ATENDIMENTO");

            entity.HasIndex(e => e.InscricaoId)
                .HasName("FK_HORARIO_ATENDIMENTO_INSCRICAO");

            entity.Property(e => e.HorarioAtendimentoId)
                .HasColumnName("HORARIO_ATENDIMENTO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.DiaDaSemana)
                .IsRequired()
                .HasColumnName("DIA_DA_SEMANA")
                .HasMaxLength(200);

            entity.Property(e => e.HoraFim)
                .HasColumnName("HORA_FIM")
                .HasColumnType("datetime");

            entity.Property(e => e.HoraInicio)
                .HasColumnName("HORA_INICIO")
                .HasColumnType("datetime");

            entity.Property(e => e.InscricaoId)
                .IsRequired()
                .HasColumnName("INSCRICAO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Mes)
                .HasColumnName("MES")
                .HasColumnType("int(11)");

            entity.Property(e => e.Sala)
                .IsRequired()
                .HasColumnName("SALA")
                .HasMaxLength(200);

            entity.HasOne(d => d.Inscricao)
                .WithMany(p => p.HorarioAtendimento)
                .HasForeignKey(d => d.InscricaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HORARIO_ATENDIMENTO_INSCRICAO");
        }
    }
    
    public class InscricaoMap : EntityTypeConfiguration<Inscricao>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Inscricao> entity)
        {
            entity.ToTable("INSCRICAO");

            entity.HasIndex(e => e.Matricula)
                .HasName("FK_INSCRICAO_ALUNO");

            entity.HasIndex(e => e.VagaRequisicaoId)
                .HasName("FK_INSCRICAO_VAGA_REQUISICAO");

            entity.Property(e => e.InscricaoId)
                .HasColumnName("INSCRICAO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Cpf)
                .IsRequired()
                .HasColumnName("CPF")
                .HasMaxLength(200);

            entity.Property(e => e.Matricula)
                .IsRequired()
                .HasColumnName("MATRICULA")
                .HasMaxLength(200);

            entity.Property(e => e.Protocolo)
                .IsRequired()
                .HasColumnName("PROTOCOLO")
                .HasMaxLength(200);

            entity.Property(e => e.VagaRequisicaoId)
                .IsRequired()
                .HasColumnName("VAGA_REQUISICAO_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.MatriculaNavigation)
                .WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.Matricula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_ALUNO");

            entity.HasOne(d => d.VagaRequisicao)
                .WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.VagaRequisicaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_VAGA_REQUISICAO");
        }
    }

     
    public class InscricaoAceitacaoMonitoriaMap : EntityTypeConfiguration<InscricaoAceitacaoMonitoria>
    {
        public override void ConfigureEntity(EntityTypeBuilder<InscricaoAceitacaoMonitoria> entity)
        {
            entity.ToTable("INSCRICAO_ACEITACAO_MONITORIA");

            entity.HasIndex(e => e.InscricaoId)
                .HasName("FK_INSCRICAO_ACEITACAO_MONITORIA_INSCRICAO");

            entity.HasIndex(e => e.VagaId)
                .HasName("FK_INSCRICAO_ACEITACAO_MONITORIA_VAGA");

            entity.Property(e => e.InscricaoAceitacaoMonitoriaId)
                .HasColumnName("INSCRICAO_ACEITACAO_MONITORIA_ID")
                .HasMaxLength(200);

            entity.Property(e => e.InscricaoId)
                .IsRequired()
                .HasColumnName("INSCRICAO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.VagaId)
                .IsRequired()
                .HasColumnName("VAGA_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.Inscricao)
                .WithMany(p => p.InscricaoAceitacaoMonitoria)
                .HasForeignKey(d => d.InscricaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_ACEITACAO_MONITORIA_INSCRICAO");

            entity.HasOne(d => d.Vaga)
                .WithMany(p => p.InscricaoAceitacaoMonitoria)
                .HasForeignKey(d => d.VagaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_ACEITACAO_MONITORIA_VAGA");
        }
    }

    public class InscricaoProvaMap : EntityTypeConfiguration<InscricaoProva>
    {
        public override void ConfigureEntity(EntityTypeBuilder<InscricaoProva> entity)
        {
            entity.ToTable("INSCRICAO_PROVA");

            entity.HasIndex(e => e.InscricaoId)
                .HasName("FK_INSCRICAO_PROVA_INSCRICAO");

            entity.HasIndex(e => e.ProvaId)
                .HasName("FK_INSCRICAO_PROVA_PROVA");

            entity.Property(e => e.InscricaoProvaId)
                .HasColumnName("INSCRICAO_PROVA_ID")
                .HasMaxLength(200);

            entity.Property(e => e.InscricaoId)
                .IsRequired()
                .HasColumnName("INSCRICAO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Nota).HasColumnName("NOTA");

            entity.Property(e => e.ProvaId)
                .IsRequired()
                .HasColumnName("PROVA_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.Inscricao)
                .WithMany(p => p.InscricaoProva)
                .HasForeignKey(d => d.InscricaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_PROVA_INSCRICAO");

            entity.HasOne(d => d.Prova)
                .WithMany(p => p.InscricaoProva)
                .HasForeignKey(d => d.ProvaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_PROVA_PROVA");
        }
    }

    public class InscricaoResultadoMap : EntityTypeConfiguration<InscricaoResultado>
    {
        public override void ConfigureEntity(EntityTypeBuilder<InscricaoResultado> entity)
        {
            entity.ToTable("INSCRICAO_RESULTADO");

            entity.HasIndex(e => e.InscricaoId)
                .HasName("FK_INSCRICAO_RESULTADO_INSCRICAO");

            entity.Property(e => e.InscricaoResultadoId)
                .HasColumnName("INSCRICAO_RESULTADO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Classificacao)
                .HasColumnName("CLASSIFICACAO")
                .HasColumnType("int(11)");

            entity.Property(e => e.InscricaoId)
                .IsRequired()
                .HasColumnName("INSCRICAO_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.Inscricao)
                .WithMany(p => p.InscricaoResultado)
                .HasForeignKey(d => d.InscricaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRICAO_RESULTADO_INSCRICAO");
        }
    }

    public class ProcessoSeletivoMap : EntityTypeConfiguration<ProcessoSeletivo>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProcessoSeletivo> entity)
        {
            entity.ToTable("PROCESSO_SELETIVO");

            entity.Property(e => e.ProcessoSeletivoId)
                .HasColumnName("PROCESSO_SELETIVO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Datahora)
                .HasColumnName("DATAHORA")
                .HasColumnType("datetime");

            entity.Property(e => e.IsConcluido)
                .HasColumnName("IS_CONCLUIDO")
                .HasColumnType("bit(1)");

            entity.Property(e => e.IsIniciado)
                .HasColumnName("IS_INICIADO")
                .HasColumnType("bit(1)");

            entity.Property(e => e.Periodo)
                .IsRequired()
                .HasColumnName("PERIODO")
                .HasMaxLength(6);
        }
    }

    public class ProcessoSeletivoCursoMap : EntityTypeConfiguration<ProcessoSeletivoCurso>
    {
        public override void ConfigureEntity(EntityTypeBuilder<ProcessoSeletivoCurso> entity)
        {
            entity.ToTable("PROCESSO_SELETIVO_CURSO");

            entity.HasIndex(e => e.CursoId)
                .HasName("FK_PROCESSO_SELETIVO_CURSO_CURSO");

            entity.HasIndex(e => e.ProcessoSeletivoId)
                .HasName("FK_PROCESSO_SELETIVO_CURSO_PROCESSO_SELETIVO");

            entity.Property(e => e.ProcessoSeletivoCursoId)
                .HasColumnName("PROCESSO_SELETIVO_CURSO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.CursoId)
                .IsRequired()
                .HasColumnName("CURSO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.ProcessoSeletivoId)
                .IsRequired()
                .HasColumnName("PROCESSO_SELETIVO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.VagarRequisicaoId)
                .IsRequired()
                .HasColumnName("VAGAR_REQUISICAO_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.Curso)
                .WithMany(p => p.ProcessoSeletivoCurso)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROCESSO_SELETIVO_CURSO_CURSO");

            entity.HasOne(d => d.ProcessoSeletivo)
                .WithMany(p => p.ProcessoSeletivoCurso)
                .HasForeignKey(d => d.ProcessoSeletivoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROCESSO_SELETIVO_CURSO_PROCESSO_SELETIVO");
        }
    }

    public class ProfessorMap : EntityTypeConfiguration<Professor>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Professor> entity)
        {
            entity.ToTable("PROFESSOR");

            entity.Property(e => e.ProfessorId)
                .HasColumnName("PROFESSOR_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Xprofessor)
                .IsRequired()
                .HasColumnName("XPROFESSOR")
                .HasMaxLength(200);
        }
    }

    public class ProvaMap : EntityTypeConfiguration<Prova>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Prova> entity)
        {
            entity.ToTable("PROVA");

            entity.HasIndex(e => e.VagaRequisicaoId)
                .HasName("FK_PROVA_VAGA_REQUISICAO");

            entity.Property(e => e.ProvaId)
                .HasColumnName("PROVA_ID")
                .HasMaxLength(200);

            entity.Property(e => e.DatahoraAplicacao)
                .HasColumnName("DATAHORA_APLICACAO")
                .HasColumnType("datetime");

            entity.Property(e => e.IsBolsa)
                .HasColumnName("IS_BOLSA")
                .HasColumnType("bit(1)");

            entity.Property(e => e.IsPratica)
                .HasColumnName("IS_PRATICA")
                .HasColumnType("bit(1)");

            entity.Property(e => e.IsTeoria)
                .HasColumnName("IS_TEORIA")
                .HasColumnType("bit(1)");

            entity.Property(e => e.Sala)
                .IsRequired()
                .HasColumnName("SALA")
                .HasMaxLength(200);

            entity.Property(e => e.VagaRequisicaoId)
                .IsRequired()
                .HasColumnName("VAGA_REQUISICAO_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.VagaRequisicao)
                .WithMany(p => p.Prova)
                .HasForeignKey(d => d.VagaRequisicaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROVA_VAGA_REQUISICAO");
        }
    }

    public class VagaMap : EntityTypeConfiguration<Vaga>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Vaga> entity)
        {
            entity.ToTable("VAGA");

            entity.HasIndex(e => e.VagaRequisicaoId)
                .HasName("FK_VAGA_VAGA_REQUISICAO");

            entity.Property(e => e.VagaId)
                .HasColumnName("VAGA_ID")
                .HasMaxLength(200);

            entity.Property(e => e.IsBolsa)
                .HasColumnName("IS_BOLSA")
                .HasColumnType("bit(1)");

            entity.Property(e => e.NumeroVaga)
                .HasColumnName("NUMERO_VAGA")
                .HasColumnType("int(11)");

            entity.Property(e => e.VagaRequisicaoId)
                .IsRequired()
                .HasColumnName("VAGA_REQUISICAO_ID")
                .HasMaxLength(200);

            entity.HasOne(d => d.VagaRequisicao)
                .WithMany(p => p.Vaga)
                .HasForeignKey(d => d.VagaRequisicaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VAGA_VAGA_REQUISICAO");
        }
    }

    public class VagaRequisicaoMap : EntityTypeConfiguration<VagaRequisicao>
    {
        public override void ConfigureEntity(EntityTypeBuilder<VagaRequisicao> entity)
        {
            entity.ToTable("VAGA_REQUISICAO");

            entity.HasIndex(e => e.ComponenteCurricularId)
                .HasName("FK_VAGA_REQUISICAO_COMPONENTE_CURRICULAR");

            entity.HasIndex(e => e.ProcessoSeletivoCursoId)
                .HasName("FK_VAGA_REQUISICAO_PROCESSO_SELETIVO_CURSO");

            entity.HasIndex(e => e.ProfessorId)
                .HasName("FK_VAGA_REQUISICAO_PROFESSOR");

            entity.Property(e => e.VagaRequisicaoId)
                .HasColumnName("VAGA_REQUISICAO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Aceitacao)
                .HasColumnName("ACEITACAO")
                .HasColumnType("bit(1)");

            entity.Property(e => e.ComponenteCurricularId)
                .IsRequired()
                .HasColumnName("COMPONENTE_CURRICULAR_ID")
                .HasMaxLength(200);

            entity.Property(e => e.ProcessoSeletivoCursoId)
                .IsRequired()
                .HasColumnName("PROCESSO_SELETIVO_CURSO_ID")
                .HasMaxLength(200);

            entity.Property(e => e.ProcessoSeletivoSeletivoCursoId)
                .HasColumnName("PROCESSO_SELETIVO_SELETIVO_CURSO_ID")
                .HasColumnType("int(11)");

            entity.Property(e => e.ProfessorId)
                .IsRequired()
                .HasColumnName("PROFESSOR_ID")
                .HasMaxLength(200);

            entity.Property(e => e.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasColumnType("int(11)");

            entity.Property(e => e.QuantidadeAceita)
                .HasColumnName("QUANTIDADE_ACEITA")
                .HasColumnType("int(11)");

            entity.Property(e => e.QuantidadeBolsa)
                .HasColumnName("QUANTIDADE_BOLSA")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.ComponenteCurricular)
                .WithMany(p => p.VagaRequisicao)
                .HasForeignKey(d => d.ComponenteCurricularId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VAGA_REQUISICAO_COMPONENTE_CURRICULAR");

            entity.HasOne(d => d.ProcessoSeletivoCurso)
                .WithMany(p => p.VagaRequisicao)
                .HasForeignKey(d => d.ProcessoSeletivoCursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VAGA_REQUISICAO_PROCESSO_SELETIVO_CURSO");

            entity.HasOne(d => d.Professor)
                .WithMany(p => p.VagaRequisicao)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VAGA_REQUISICAO_PROFESSOR");
        }
    }
} 

/*
builder.Property(c => c.departament_id).HasMaxLength(200).HasColumnType("varchar");
builder.Property(c => c.parent_departament_id).HasMaxLength(200).HasColumnType("varchar");

builder.Property(c => c.xdepartament).HasColumnType("VARCHAR");

builder.Property(c => c.xdepartament).IsRequired();
builder.HasMany(t => t.departaments).WithOne(t => t.parent_departament).HasForeignKey(c => c.parent_departament_id);
builder.HasOne(t => t.parent_departament)
       .WithOne()
       .HasForeignKey<Departament>(c=> c.departament_id); */
      
