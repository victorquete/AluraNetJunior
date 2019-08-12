using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaDoCodigo.Migrations
{
    public partial class CategoriaCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cadastro_CadastroId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_CadastroId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CadastroId",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cadastro",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cadastro",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySQL:AutoIncrement", true);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cadastro_Pedido_Id",
                table: "Cadastro",
                column: "Id",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cadastro_Pedido_Id",
                table: "Cadastro");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "CadastroId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cadastro",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cadastro",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySQL:AutoIncrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CadastroId",
                table: "Pedido",
                column: "CadastroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cadastro_CadastroId",
                table: "Pedido",
                column: "CadastroId",
                principalTable: "Cadastro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
