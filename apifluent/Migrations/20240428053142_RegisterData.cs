using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apifluent.Migrations
{
    /// <inheritdoc />
    public partial class RegisterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Description", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"), null, "Actividades personales", 50 },
                    { new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Description", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9310"), new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"), null, new DateTime(2024, 4, 28, 0, 31, 42, 339, DateTimeKind.Local).AddTicks(97), 1, "Pago de servicios" },
                    { new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9410"), new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"), null, new DateTime(2024, 4, 28, 0, 31, 42, 339, DateTimeKind.Local).AddTicks(112), 1, "Pago de servicios" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9310"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9410"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
