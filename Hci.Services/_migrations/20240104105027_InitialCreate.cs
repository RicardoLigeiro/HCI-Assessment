using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hci.Services._migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_Hospitals_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    DocumentType = table.Column<byte>(type: "tinyint", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedById", "FirstName", "LastName", "RecordDate" },
                values: new object[] { 1, 1, "John", "Doe", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "HospitalId", "CreatedById", "Name", "RecordDate" },
                values: new object[,]
                {
                    { 1, 1, "Beacon Hospital", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, "Cavan General Hospital", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "CreatedById", "DocumentId", "DocumentType", "FirstName", "LastName", "RecordDate" },
                values: new object[,]
                {
                    { 1, 1, "IR894256", (byte)2, "John", "Smith", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, "US97455881", (byte)2, "Raegan", "Gardner", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 1, null, (byte)1, "Kaylah", "Wilkinson", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "VisitId", "CreatedById", "EntryDate", "ExitDate", "HospitalId", "PersonId", "RecordDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 31, 20, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 12, 31, 21, 0, 0, 0, DateTimeKind.Local), 1, 1, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 1, new DateTime(2024, 1, 1, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 1, 21, 32, 0, 0, DateTimeKind.Local), 1, 2, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 1, new DateTime(2024, 1, 1, 22, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 1, 22, 23, 0, 0, DateTimeKind.Local), 1, 1, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 1, new DateTime(2024, 1, 1, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 1, 23, 0, 0, 0, DateTimeKind.Local), 2, 3, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, 1, new DateTime(2024, 1, 3, 20, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 3, 20, 35, 0, 0, DateTimeKind.Local), 1, 2, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, 1, new DateTime(2024, 1, 3, 21, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 1, 3, 21, 20, 0, 0, DateTimeKind.Local), 2, 3, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_CreatedById",
                table: "Hospitals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreatedById",
                table: "Persons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CreatedById",
                table: "Visits",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_HospitalId",
                table: "Visits",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PersonId",
                table: "Visits",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
