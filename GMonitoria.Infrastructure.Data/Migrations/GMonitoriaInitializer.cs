using GMonitoria.Domain.Entities;
using GMonitoria.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMonitoria.Infrastructure.Data.Migrations
{ 
    public class GMonitoriaInitializer 
    {
        private GMonitoriaContext _context;

        public GMonitoriaInitializer(GMonitoriaContext context)
        {
            _context = context;
        } 

        public void Seed()
        {
            if (!_context.Aluno.Any())
            {
                _context.AddRange(Alunos);
                _context.SaveChanges();
            }

            if (!_context.Curso.Any())
            {
                _context.AddRange(Cursos);
                _context.SaveChanges();
            }

            if (!_context.Coordenador.Any())
            {
                _context.AddRange(Coordenadores);
                _context.SaveChanges();
            }

            if (!_context.Professor.Any())
            {
                _context.AddRange(Professores);
                _context.SaveChanges();
            }

            if (!_context.ComponenteCurricular.Any())
            {
                _context.AddRange(ComponenteCurriculares);
                _context.SaveChanges();
            }

            if (!_context.ProcessoSeletivo.Any())
            {
                _context.AddRange(ProcessoSeletivos);
                _context.SaveChanges();
            }
             
        }
         
         
        List<Aluno> Alunos = new List<Aluno>
        {
            new Aluno() { Matricula = "1", Xaluno = "Aluno1"} ,
            new Aluno() { Matricula = "2", Xaluno = "Aluno2"} ,
            new Aluno() { Matricula = "3", Xaluno = "Aluno3"} ,
            new Aluno() { Matricula = "4", Xaluno = "Aluno4"} ,
            new Aluno() { Matricula = "5", Xaluno = "Aluno5"}
        };

        List<Curso> Cursos = new List<Curso>
        {
            new Curso() { CursoId = "1",  Xcurso = "Sistemas de Informação"} ,
            new Curso() { CursoId = "2",  Xcurso = "Direito"} ,
            new Curso() { CursoId = "3",  Xcurso = "Medicina"}
        }; 

        List<Coordenador> Coordenadores = new List<Coordenador>
        {
            new Coordenador() { CoordenadorId = "1", Xcoordenador = "Coordenador1", CursoId = "1"} ,
            new Coordenador() { CoordenadorId = "2", Xcoordenador = "Coordenador2", CursoId = "2"} ,
            new Coordenador() { CoordenadorId = "3", Xcoordenador = "Coordenador3", CursoId = "3"}  
        };

        List<Professor> Professores = new List<Professor>
        {
            new Professor() { ProfessorId = "1", Xprofessor = "Professor1"} ,
            new Professor() { ProfessorId = "2", Xprofessor = "Professor2"} ,
            new Professor() { ProfessorId = "3", Xprofessor = "Professor3"} ,
            new Professor() { ProfessorId = "4", Xprofessor = "Professor4"} ,
            new Professor() { ProfessorId = "5", Xprofessor = "Professor5"}
        };
         
        List<ComponenteCurricular> ComponenteCurriculares = new List<ComponenteCurricular>
        {
            new ComponenteCurricular() { ComponenteCurricularId = "1", ProfessorId = "1",   CursoId = "1",  XcomponenteCurricular = "Programação"} ,
            new ComponenteCurricular() { ComponenteCurricularId = "2", ProfessorId = "2",   CursoId = "1",  XcomponenteCurricular = "Calculo"} ,
            new ComponenteCurricular() { ComponenteCurricularId = "3", ProfessorId = "3",   CursoId = "2",  XcomponenteCurricular = "Direito Penal"},
            new ComponenteCurricular() { ComponenteCurricularId = "4", ProfessorId = "1",   CursoId = "2",  XcomponenteCurricular = "Direito Empresarial"} ,
            new ComponenteCurricular() { ComponenteCurricularId = "5", ProfessorId = "2",   CursoId = "3",  XcomponenteCurricular = "Anatomia"} ,
            new ComponenteCurricular() { ComponenteCurricularId = "6", ProfessorId = "3",   CursoId = "3",  XcomponenteCurricular = "Enfermidades"}
        };
         
        List<ProcessoSeletivo> ProcessoSeletivos = new List<ProcessoSeletivo>
        {
            new ProcessoSeletivo() { ProcessoSeletivoId = "1",  Periodo = "2018.1", IsIniciado = true, IsConcluido = false } ,
            new ProcessoSeletivo() { ProcessoSeletivoId = "2",  Periodo = "2018.2", IsIniciado = false, IsConcluido = false } ,
            new ProcessoSeletivo() { ProcessoSeletivoId = "3",  Periodo = "2019.1", IsIniciado = false, IsConcluido = false } ,
            new ProcessoSeletivo() { ProcessoSeletivoId = "4",  Periodo = "2019.2", IsIniciado = false, IsConcluido = false } ,
            new ProcessoSeletivo() { ProcessoSeletivoId = "5",  Periodo = "2020.1", IsIniciado = false, IsConcluido = false } ,
            new ProcessoSeletivo() { ProcessoSeletivoId = "6",  Periodo = "2020.2", IsIniciado = false, IsConcluido = false } ,
        };

    }
} 
