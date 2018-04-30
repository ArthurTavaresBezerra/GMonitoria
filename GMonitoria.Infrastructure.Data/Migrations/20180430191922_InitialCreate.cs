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
                name: "papel",
                columns: table => new
                {
                    PAPEL_ID = table.Column<string>(maxLength: 200, nullable: false),
                    XPAPEL = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_papel", x => x.PAPEL_ID);
                });

            migrationBuilder.CreateTable(
                name: "processo_seletivo",
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
                    table.PrimaryKey("PK_processo_seletivo", x => x.PROCESSO_SELETIVO_ID);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    USUARIO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    MATRICULA = table.Column<string>(maxLength: 200, nullable: false),
                    SENHA = table.Column<string>(maxLength: 200, nullable: false),
                    XUSUARIO = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.USUARIO_ID);
                });

            migrationBuilder.CreateTable(
                name: "processo_seletivo_curso",
                columns: table => new
                {
                    PROCESSO_SELETIVO_CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROCESSO_SELETIVO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processo_seletivo_curso", x => x.PROCESSO_SELETIVO_CURSO_ID);
                    table.ForeignKey(
                        name: "FK_PROCESSO_SELETIVO_CURSO_CURSO",
                        column: x => x.CURSO_ID,
                        principalTable: "CURSO",
                        principalColumn: "CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROCESSO_SELETIVO_CURSO_PROCESSO_SELETIVO",
                        column: x => x.PROCESSO_SELETIVO_ID,
                        principalTable: "processo_seletivo",
                        principalColumn: "PROCESSO_SELETIVO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "componente_curricular",
                columns: table => new
                {
                    COMPONENTE_CURRICULAR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROFESSOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    XCOMPONENTE_CURRICULAR = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componente_curricular", x => x.COMPONENTE_CURRICULAR_ID);
                    table.ForeignKey(
                        name: "FK_COMPONENTE_CURRICULAR_CURSO",
                        column: x => x.CURSO_ID,
                        principalTable: "CURSO",
                        principalColumn: "CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMPONENTE_CURRICULAR_PROFESSOR",
                        column: x => x.PROFESSOR_ID,
                        principalTable: "usuario",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario_papel",
                columns: table => new
                {
                    USUARIO_PAPEL_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PAPEL_ID = table.Column<string>(maxLength: 200, nullable: false),
                    USUARIO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_papel", x => x.USUARIO_PAPEL_ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_PAPEL_CURSO",
                        column: x => x.CURSO_ID,
                        principalTable: "CURSO",
                        principalColumn: "CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_PAPEL_PAPEL",
                        column: x => x.PAPEL_ID,
                        principalTable: "papel",
                        principalColumn: "PAPEL_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIO_PAPEL_USUARIO",
                        column: x => x.USUARIO_ID,
                        principalTable: "usuario",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaga_requisicao",
                columns: table => new
                {
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    COMPONENTE_CURRICULAR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROCESSO_SELETIVO_CURSO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    PROFESSOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaga_requisicao", x => x.VAGA_REQUISICAO_ID);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_COMPONENTE_CURRICULAR",
                        column: x => x.COMPONENTE_CURRICULAR_ID,
                        principalTable: "componente_curricular",
                        principalColumn: "COMPONENTE_CURRICULAR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_PROCESSO_SELETIVO_CURSO",
                        column: x => x.PROCESSO_SELETIVO_CURSO_ID,
                        principalTable: "processo_seletivo_curso",
                        principalColumn: "PROCESSO_SELETIVO_CURSO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_PROFESSOR",
                        column: x => x.PROFESSOR_ID,
                        principalTable: "usuario",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscricao",
                columns: table => new
                {
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    ALUNO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CPF = table.Column<string>(maxLength: 200, nullable: false),
                    PROTOCOLO = table.Column<string>(maxLength: 200, nullable: false),
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao", x => x.INSCRICAO_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_ALUNO",
                        column: x => x.ALUNO_ID,
                        principalTable: "usuario",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "vaga_requisicao",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prova",
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
                    table.PrimaryKey("PK_prova", x => x.PROVA_ID);
                    table.ForeignKey(
                        name: "FK_PROVA_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "vaga_requisicao",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaga",
                columns: table => new
                {
                    VAGA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    IS_BOLSA = table.Column<bool>(type: "bit(1)", nullable: false),
                    NUMERO_VAGA = table.Column<int>(type: "int(11)", nullable: false),
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaga", x => x.VAGA_ID);
                    table.ForeignKey(
                        name: "FK_VAGA_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "vaga_requisicao",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaga_requisicao_aprovacao",
                columns: table => new
                {
                    VAGA_REQUISICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    COORDENADOR_ID = table.Column<string>(maxLength: 200, nullable: false),
                    IS_APROVADO = table.Column<bool>(type: "bit(1)", nullable: false),
                    QUANTIDADE_APROVADA = table.Column<int>(type: "int(11)", nullable: false),
                    QUANTIDADE_COM_BOLSA = table.Column<int>(type: "int(11)", nullable: false),
                    QUANTIDADE_SEM_BOLSA = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaga_requisicao_aprovacao", x => x.VAGA_REQUISICAO_ID);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_APROVACAO_COORDENADOR",
                        column: x => x.COORDENADOR_ID,
                        principalTable: "usuario",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VAGA_REQUISICAO_APROVACAO_VAGA_REQUISICAO",
                        column: x => x.VAGA_REQUISICAO_ID,
                        principalTable: "vaga_requisicao",
                        principalColumn: "VAGA_REQUISICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HORARIO_ATENDIMENTO",
                columns: table => new
                {
                    HORARIO_ATENDIMENTO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    DataAlteracao = table.Column<int>(nullable: false),
                    DIA_DA_SEMANA = table.Column<string>(maxLength: 200, nullable: false),
                    HORA_FIM = table.Column<DateTime>(type: "datetime", nullable: false),
                    HORA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    SALA = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIO_ATENDIMENTO", x => x.HORARIO_ATENDIMENTO_ID);
                    table.ForeignKey(
                        name: "FK_HORARIO_ATENDIMENTO_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "inscricao",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscricao_resultado",
                columns: table => new
                {
                    INSCRICAO_RESULTADO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    CLASSIFICACAO = table.Column<int>(type: "int(11)", nullable: true),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao_resultado", x => x.INSCRICAO_RESULTADO_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_RESULTADO_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "inscricao",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscricao_prova",
                columns: table => new
                {
                    INSCRICAO_PROVA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    NOTA = table.Column<float>(nullable: false),
                    PROVA_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao_prova", x => x.INSCRICAO_PROVA_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_PROVA_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "inscricao",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_PROVA_PROVA",
                        column: x => x.PROVA_ID,
                        principalTable: "prova",
                        principalColumn: "PROVA_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscricao_aceitacao_monitoria",
                columns: table => new
                {
                    INSCRICAO_ACEITACAO_MONITORIA_ID = table.Column<string>(maxLength: 200, nullable: false),
                    INSCRICAO_ID = table.Column<string>(maxLength: 200, nullable: false),
                    VAGA_ID = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao_aceitacao_monitoria", x => x.INSCRICAO_ACEITACAO_MONITORIA_ID);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_ACEITACAO_MONITORIA_INSCRICAO",
                        column: x => x.INSCRICAO_ID,
                        principalTable: "inscricao",
                        principalColumn: "INSCRICAO_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_ACEITACAO_MONITORIA_VAGA",
                        column: x => x.VAGA_ID,
                        principalTable: "vaga",
                        principalColumn: "VAGA_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_COMPONENTE_CURRICULAR_CURSO",
                table: "componente_curricular",
                column: "CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_COMPONENTE_CURRICULAR_PROFESSOR",
                table: "componente_curricular",
                column: "PROFESSOR_ID");

            migrationBuilder.CreateIndex(
                name: "FK_HORARIO_ATENDIMENTO_INSCRICAO",
                table: "HORARIO_ATENDIMENTO",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_ALUNO",
                table: "inscricao",
                column: "ALUNO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_VAGA_REQUISICAO",
                table: "inscricao",
                column: "VAGA_REQUISICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_ACEITACAO_MONITORIA_INSCRICAO",
                table: "inscricao_aceitacao_monitoria",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_ACEITACAO_MONITORIA_VAGA",
                table: "inscricao_aceitacao_monitoria",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_PROVA_INSCRICAO",
                table: "inscricao_prova",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_PROVA_PROVA",
                table: "inscricao_prova",
                column: "PROVA_ID");

            migrationBuilder.CreateIndex(
                name: "FK_INSCRICAO_RESULTADO_INSCRICAO",
                table: "inscricao_resultado",
                column: "INSCRICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_PROCESSO_SELETIVO_CURSO_CURSO",
                table: "processo_seletivo_curso",
                column: "CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_PROCESSO_SELETIVO_CURSO_PROCESSO_SELETIVO",
                table: "processo_seletivo_curso",
                column: "PROCESSO_SELETIVO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_PROVA_VAGA_REQUISICAO",
                table: "prova",
                column: "VAGA_REQUISICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_USUARIO_PAPEL_CURSO",
                table: "usuario_papel",
                column: "CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_USUARIO_PAPEL_PAPEL",
                table: "usuario_papel",
                column: "PAPEL_ID");

            migrationBuilder.CreateIndex(
                name: "FK_USUARIO_PAPEL_USUARIO",
                table: "usuario_papel",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_VAGA_REQUISICAO",
                table: "vaga",
                column: "VAGA_REQUISICAO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_COMPONENTE_CURRICULAR",
                table: "vaga_requisicao",
                column: "COMPONENTE_CURRICULAR_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_PROCESSO_SELETIVO_CURSO",
                table: "vaga_requisicao",
                column: "PROCESSO_SELETIVO_CURSO_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_PROFESSOR",
                table: "vaga_requisicao",
                column: "PROFESSOR_ID");

            migrationBuilder.CreateIndex(
                name: "FK_VAGA_REQUISICAO_APROVACAO_COORDENADOR",
                table: "vaga_requisicao_aprovacao",
                column: "COORDENADOR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HORARIO_ATENDIMENTO");

            migrationBuilder.DropTable(
                name: "inscricao_aceitacao_monitoria");

            migrationBuilder.DropTable(
                name: "inscricao_prova");

            migrationBuilder.DropTable(
                name: "inscricao_resultado");

            migrationBuilder.DropTable(
                name: "usuario_papel");

            migrationBuilder.DropTable(
                name: "vaga_requisicao_aprovacao");

            migrationBuilder.DropTable(
                name: "vaga");

            migrationBuilder.DropTable(
                name: "prova");

            migrationBuilder.DropTable(
                name: "inscricao");

            migrationBuilder.DropTable(
                name: "papel");

            migrationBuilder.DropTable(
                name: "vaga_requisicao");

            migrationBuilder.DropTable(
                name: "componente_curricular");

            migrationBuilder.DropTable(
                name: "processo_seletivo_curso");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "CURSO");

            migrationBuilder.DropTable(
                name: "processo_seletivo");
        }
    }
}
