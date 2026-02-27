
#nullable disable
namespace EvolutionaryArchitecture.Fitnet.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class AddOutboxAndSaga : Migration
{
    private static readonly string[] OutboxMessageColumns = ["Type", "Payload"];

    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "OutboxMessages",
            schema: "Passes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                Payload = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OutboxMessages", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PassRegistrationSagas",
            schema: "Passes",
            columns: table => new
            {
                SagaId = table.Column<Guid>(type: "uuid", nullable: false),
                PassId = table.Column<Guid>(type: "uuid", nullable: false),
                Status = table.Column<string>(type: "text", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PassRegistrationSagas", x => x.SagaId);
            });

        migrationBuilder.CreateIndex(
            name: "IX_OutboxMessages_Type_Payload",
            schema: "Passes",
            table: "OutboxMessages",
            columns: OutboxMessageColumns,
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_PassRegistrationSagas_PassId",
            schema: "Passes",
            table: "PassRegistrationSagas",
            column: "PassId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OutboxMessages",
            schema: "Passes");

        migrationBuilder.DropTable(
            name: "PassRegistrationSagas",
            schema: "Passes");
    }
}
