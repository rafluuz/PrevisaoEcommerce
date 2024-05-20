using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisaoEcommerce.Migrations
{
    /// <inheritdoc />
    public partial class Cadastros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Cadastro",
                columns: table => new
                {
                    IdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cadastro", x => x.IdCadastro);
                });

            migrationBuilder.CreateTable(
                name: "TB_DadosMercado",
                columns: table => new
                {
                    IdDadosMerc = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeEmpresa = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AnoPrevisao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DadosMercado", x => x.IdDadosMerc);
                });

            migrationBuilder.CreateTable(
                name: "TB_LogsChat",
                columns: table => new
                {
                    IdLogChat = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LogsChat", x => x.IdLogChat);
                });

            migrationBuilder.CreateTable(
                name: "TB_Login",
                columns: table => new
                {
                    IdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CadastroIdCadastro = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Login", x => x.IdLogin);
                    table.ForeignKey(
                        name: "FK_TB_Login_TB_Cadastro_CadastroIdCadastro",
                        column: x => x.CadastroIdCadastro,
                        principalTable: "TB_Cadastro",
                        principalColumn: "IdCadastro");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Login_CadastroIdCadastro",
                table: "TB_Login",
                column: "CadastroIdCadastro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DadosMercado");

            migrationBuilder.DropTable(
                name: "TB_Login");

            migrationBuilder.DropTable(
                name: "TB_LogsChat");

            migrationBuilder.DropTable(
                name: "TB_Cadastro");
        }
    }
}
