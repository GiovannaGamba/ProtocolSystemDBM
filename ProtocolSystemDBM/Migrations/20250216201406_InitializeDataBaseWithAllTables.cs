using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProtocolSystemDBM.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDataBaseWithAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "protocol_statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_protocol_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "protocols",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opening_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closing_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    protocol_status_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_protocols", x => x.id);
                    table.ForeignKey(
                        name: "FK_protocols_protocol_statuses_protocol_status_id",
                        column: x => x.protocol_status_id,
                        principalTable: "protocol_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_protocols_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "protocol_follows",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    action_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    action_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    protocol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_protocol_follows", x => x.id);
                    table.ForeignKey(
                        name: "FK_protocol_follows_protocols_protocol_id",
                        column: x => x.protocol_id,
                        principalTable: "protocols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "protocol_statuses",
                columns: new[] { "id", "deleted", "name" },
                values: new object[,]
                {
                    { new Guid("a2b32f72-2c91-47f6-b0a9-63e9b44b33f9"), false, "Criado" },
                    { new Guid("be0f2111-f6da-4208-b6f7-6e63f27b0428"), false, "Atendido" },
                    { new Guid("f34be16e-d2ae-45d7-8f97-060f0cd541b2"), false, "Em processamento" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_protocol_follows_protocol_id",
                table: "protocol_follows",
                column: "protocol_id");

            migrationBuilder.CreateIndex(
                name: "IX_protocols_protocol_status_id",
                table: "protocols",
                column: "protocol_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_protocols_user_id",
                table: "protocols",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "protocol_follows");

            migrationBuilder.DropTable(
                name: "protocols");

            migrationBuilder.DropTable(
                name: "protocol_statuses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
