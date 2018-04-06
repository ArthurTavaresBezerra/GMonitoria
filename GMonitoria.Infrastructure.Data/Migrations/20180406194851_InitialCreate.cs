using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GMonitoria.Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    MATRICULA = table.Column<string>(maxLength: 200, nullable: false),
                    XALUNO = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO", x => x.MATRICULA);
                });

            migrationBuilder.CreateTable(
                name: "CURSO",
                columns: table => new
                {
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    XCURSO = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURSO", x => x.CURSO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROCESSO_SELETIVO",
                columns: table => new
                {
                    PROCESSO_SELETIVO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    DATAHORA = table.Column<DateTime>(type: "datetime", nullable: false),
                    IS_CONCLUIDO = table.Column<bool>(type: "bit(1)", nullable: true),
                    IS_INICIADO = table.Column<bool>(type: "bit(1)", nullable: false),
                    PERIODO = table.Column<string>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESSO_SELETIVO", x => x.PROCESSO_SELETIVO_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROFESSOR",
                columns: table => new
                {
                    PROFESSOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    XPROFESSOR = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFESSOR", x => x.PROFESSOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "COORDENADOR",
                columns: table => new
                {
                    COORDENADOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    XCOORDENADOR = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COORDENADOR", x => x.COORDENADOR_ID);
                    table.ForeignKey(
                        name: "FK_COORDENADOR_CURRICULAR_CURSO",
                        column: x => x.CURSO_ID,
                        principalTable: "CURSO",
                        principalColumn: "CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROCESSO_SELETIVO_CURSO",
                columns: table => new
                {
                    PROCESSO_SELETIVO_CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROCESSO_SELETIVO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    VAGAR_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCESSO_SELETIVO_CURSO", x => x.PROCESSO_SELETIVO_CURSO_ID);
                    table.ForeignKey(
                        name: "FK_PROCESSO_SELETIVO_CURSO_CURSO",
                        column: x => x.CURSO_ID,
                        principalTable: "CURSO",
                        principalColumn: "CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROCESSO_SELETIVO_CURSO_PROCESSO_SELETIVO",
                        column: x => x.PROCESSO_SELETIVO_ID,
                        principalTable: "PROCESSO_SELETIVO",
                        principalColumn: "PROCESSO_SELETIVO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTE_CURRICULAR",
                columns: table => new
                {
                    COMPONENTE_CURRICULAR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROFESSOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    XCOMPONENTE_CURRICULAR = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPONENTE_CURRICULAR", x => x.COMPONENTE_CURRICULAR_ID);
                    table.ForeignKey(
                        name: "FK_COMPONENTE_CURRICULAR_CURSO",
                        column: x => x.CURSO_ID,
                        principalTable: "CURSO",
                        principalColumn: "CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMPONENTE_CURRICULAR_PROFESSOR",
                        column: x => x.PROFESSOR_ID,
                        principalTable: "PROFESSOR",
                        principalColumn: "PROFESSOR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VAGA_REQUISICAO",
                columns: table => new
                {
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    ACEITACAO = table.Column<bool>(type: "bit(1)", nullable: false),
                    COMPONENTE_CURRICULAR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROCESSO_SELETIVO_CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROCESSO_SELETIVO_SELETIVO_CURSO_ID = table.Column<int>(type: "int(11)", nullable: false),
                    PROFESSOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int(11)", nullable: false),
                    QUANTIDADE_ACEITA = table.Column<int>(type: "int(11)", nullable: true),
                    QUANTIDADE_BOLSA = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGA_REQUISICAO", x => x.VAGA_REQUISICAO_ID);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_COMPONENTE_CURRICULAR",
                        column: x => x.COMPONENTE_CURRICULAR_ID,
                        principalTable: "COMPONENTE_CURRICULAR",
                        principalColumn: "COMPONENTE_CURRICULAR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_PROCESSO_SELETIVO_CURSO",
                        column: x => x.PROCESSO_SELETIVO_CURSO_ID,
                        principalTable: "PROCESSO_SELETIVO_CURSO",
                        principalColumn: "PROCESSO_SELETIVO_CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_PROFESSOR",
                        column: x => x.PROFESSOR_ID,
                        principalTable: "PROFESSOR",
                        principalColumn: "PROFESSOR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO",
                columns: table => new
                {
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CPF = table.Column<string>(maxLength: 200, nullable: false),
                    MATRICULA = table.Column<string>(maxLength: 200, nullable: false),
                    PROTOCOLO = table.Column<string>(maxLength: 200, nullable: false),
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSCRICAO", x => x.INSCRICAO_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_ALUNO",
                        column: x => x.MATRICULA,
                        principalTable: "ALUNO",
                        principalColumn: "MATRICULA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "VAGA_REQUISICAO",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROVA",
                columns: table => new
                {
                    PROVA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    DATAHORA_APLICACAO = table.Column<DateTime>(type: "datetime", nullable: false),
                    IS_BOLSA = table.Column<bool>(type: "bit(1)", nullable: false),
                    IS_PRATICA = table.Column<bool>(type: "bit(1)", nullable: false),
                    IS_TEORIA = table.Column<bool>(type: "bit(1)", nullable: false),
                    SALA = table.Column<string>(maxLength: 200, nullable: false),
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVA", x => x.PROVA_ID);
                    table.ForeignKey(
                        name: "FK_PROVA_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "VAGA_REQUISICAO",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VAGA",
                columns: table => new
                {
                    VAGA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    IS_BOLSA = table.Column<bool>(type: "bit(1)", nullable: false),
                    NUMERO_VAGA = table.Column<int>(type: "int(11)", nullable: false),
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAGA", x => x.VAGA_ID);
                    table.ForeignKey(
                        name: "FK_VAGA_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "VAGA_REQUISICAO",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HORARIO_ATENDIMENTO",
                columns: table => new
                {
                    HORARIO_ATENDIMENTO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    DIA_DA_SEMANA = table.Column<string>(maxLength: 200, nullable: false),
                    HORA_FIM = table.Column<DateTime>(type: "datetime", nullable: false),
                    HORA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    MES = table.Column<int>(type: "int(11)", nullable: false),
                    SALA = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIO_ATENDIMENTO", x => x.HORARIO_ATENDIMENTO_ID);
                    table.ForeignKey(
                        name: "FK_HORARIO_ATENDIMENTO_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "INSCRICAO",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO_RESULTADO",
                columns: table => new
                {
                    INSCRICAO_RESULTADO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CLASSIFICACAO = table.Column<int>(type: "int(11)", nullable: true),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSCRICAO_RESULTADO", x => x.INSCRICAO_RESULTADO_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_RESULTADO_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "INSCRICAO",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO_PROVA",
                columns: table => new
                {
                    INSCRICAO_PROVA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    NOTA = table.Column<float>(nullable: false),
                    PROVA_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSCRICAO_PROVA", x => x.INSCRICAO_PROVA_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_PROVA_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "INSCRICAO",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_PROVA_PROVA",
                        column: x => x.PROVA_ID,
                        principalTable: "PROVA",
                        principalColumn: "PROVA_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO_ACEITACAO_MONITORIA",
                columns: table => new
                {
                    INSCRICAO_ACEITACAO_MONITORIA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    VAGA_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSCRICAO_ACEITACAO_MONITORIA", x => x.INSCRICAO_ACEITACAO_MONITORIA_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_ACEITACAO_MONITORIA_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "INSCRICAO",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_ACEITACAO_MONITORIA_VAGA",
                        column: x => x.VAGA_ID,
                        principalTable: "VAGA",
                        principalColumn: "VAGA_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_COMPONENTE_CURRICULAR_CURSO",
                table: "COMPONENTE_CURRICULAR",
                column: "CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_COMPONENTE_CURRICULAR_PROFESSOR",
                table: "COMPONENTE_CURRICULAR",
                column: "PROFESSOR_ID");

            migrationBuilder.CreateIndex(
                name: "FK_COORDENADOR_CURRICULAR_CURSO",
                table: "COORDENADOR",
                column: "CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_HORARIO_ATENDIMENTO_INSCRICAO",
                table: "HORARIO_ATENDIMENTO",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_ALUNO",
                table: "INSCRICAO",
                column: "MATRICULA");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_VAGA_REQUISICAO",
                table: "INSCRICAO",
                column: "VAGA_REQUISICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_ACEITACAO_MONITORIA_INSCRICAO",
                table: "INSCRICAO_ACEITACAO_MONITORIA",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_ACEITACAO_MONITORIA_VAGA",
                table: "INSCRICAO_ACEITACAO_MONITORIA",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_PROVA_INSCRICAO",
                table: "INSCRICAO_PROVA",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_PROVA_PROVA",
                table: "INSCRICAO_PROVA",
                column: "PROVA_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_RESULTADO_INSCRICAO",
                table: "INSCRICAO_RESULTADO",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_PROCESSO_SELETIVO_CURSO_CURSO",
                table: "PROCESSO_SELETIVO_CURSO",
                column: "CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_PROCESSO_SELETIVO_CURSO_PROCESSO_SELETIVO",
                table: "PROCESSO_SELETIVO_CURSO",
                column: "PROCESSO_SELETIVO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_PROVA_VAGA_REQUISICAO",
                table: "PROVA",
                column: "VAGA_REQUISICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_VAGA_REQUISICAO",
                table: "VAGA",
                column: "VAGA_REQUISICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_COMPONENTE_CURRICULAR",
                table: "VAGA_REQUISICAO",
                column: "COMPONENTE_CURRICULAR_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_PROCESSO_SELETIVO_CURSO",
                table: "VAGA_REQUISICAO",
                column: "PROCESSO_SELETIVO_CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_PROFESSOR",
                table: "VAGA_REQUISICAO",
                column: "PROFESSOR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COORDENADOR");

            migrationBuilder.DropTable(
                name: "HORARIO_ATENDIMENTO");

            migrationBuilder.DropTable(
                name: "INSCRICAO_ACEITACAO_MONITORIA");

            migrationBuilder.DropTable(
                name: "INSCRICAO_PROVA");

            migrationBuilder.DropTable(
                name: "INSCRICAO_RESULTADO");

            migrationBuilder.DropTable(
                name: "VAGA");

            migrationBuilder.DropTable(
                name: "PROVA");

            migrationBuilder.DropTable(
                name: "INSCRICAO");

            migrationBuilder.DropTable(
                name: "ALUNO");

            migrationBuilder.DropTable(
                name: "VAGA_REQUISICAO");

            migrationBuilder.DropTable(
                name: "COMPONENTE_CURRICULAR");

            migrationBuilder.DropTable(
                name: "PROCESSO_SELETIVO_CURSO");

            migrationBuilder.DropTable(
                name: "PROFESSOR");

            migrationBuilder.DropTable(
                name: "CURSO");

            migrationBuilder.DropTable(
                name: "PROCESSO_SELETIVO");
        }
    }
}
