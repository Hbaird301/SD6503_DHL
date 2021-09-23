using Microsoft.EntityFrameworkCore.Migrations;

namespace SD6503_DHl.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginAccount",
                columns: table => new
                {
                    Identifier = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoginAcc__821FB0188D7497D4", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "AccountDetails",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AccountD__BE2ACD6E470FED9A", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK__AccountDe__Ident__25869641",
                        column: x => x.Identifier,
                        principalTable: "LoginAccount",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ToAccount = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FromAccount = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
                    PaymentPeriod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__95E36B86462D1D3C", x => x.TransactionNumber);
                    table.ForeignKey(
                        name: "FK__Transacti__FromA__286302EC",
                        column: x => x.FromAccount,
                        principalTable: "AccountDetails",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_Identifier",
                table: "AccountDetails",
                column: "Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_FromAccount",
                table: "Transaction",
                column: "FromAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "AccountDetails");

            migrationBuilder.DropTable(
                name: "LoginAccount");
        }
    }
}
