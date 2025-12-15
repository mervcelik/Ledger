using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.EnsureSchema(
                name: "Corp");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Corp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountingPeriods",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingPeriods_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Corp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAccounts",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentAccounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Corp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Corp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                schema: "Corp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Corp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalSchema: "Identity",
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentMovements",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAccountId = table.Column<int>(type: "int", nullable: false),
                    AccountingPeriodId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MovementTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentMovements_AccountingPeriods_AccountingPeriodId",
                        column: x => x.AccountingPeriodId,
                        principalSchema: "Finance",
                        principalTable: "AccountingPeriods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrentMovements_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Corp",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentMovements_CurrentAccounts_CurrentAccountId",
                        column: x => x.CurrentAccountId,
                        principalSchema: "Finance",
                        principalTable: "CurrentAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrentMovements_MovementTypes_MovementTypeId",
                        column: x => x.MovementTypeId,
                        principalSchema: "Finance",
                        principalTable: "MovementTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CurrentMovementDetails",
                schema: "Finance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentMovementId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxPercient = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMovementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentMovementDetails_CurrentMovements_CurrentMovementId",
                        column: x => x.CurrentMovementId,
                        principalSchema: "Finance",
                        principalTable: "CurrentMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingPeriods_CompanyId",
                schema: "Finance",
                table: "AccountingPeriods",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                schema: "Corp",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_UserId",
                schema: "Corp",
                table: "CompanyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_CompanyId",
                schema: "Finance",
                table: "CurrentAccounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMovementDetails_CurrentMovementId",
                schema: "Finance",
                table: "CurrentMovementDetails",
                column: "CurrentMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMovements_AccountingPeriodId",
                schema: "Finance",
                table: "CurrentMovements",
                column: "AccountingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMovements_CompanyId",
                schema: "Finance",
                table: "CurrentMovements",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMovements_CurrentAccountId",
                schema: "Finance",
                table: "CurrentMovements",
                column: "CurrentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMovements_MovementTypeId",
                schema: "Finance",
                table: "CurrentMovements",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementTypes_CompanyId",
                schema: "Finance",
                table: "MovementTypes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                schema: "Identity",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                schema: "Identity",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                schema: "Identity",
                table: "UserSessions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyUsers",
                schema: "Corp");

            migrationBuilder.DropTable(
                name: "CurrentMovementDetails",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "UserOperationClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSessions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CurrentMovements",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "OperationClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AccountingPeriods",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "CurrentAccounts",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "MovementTypes",
                schema: "Finance");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Corp");
        }
    }
}
