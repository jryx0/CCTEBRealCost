using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CCTEB.Real.Cost.Repository.Migrations
{
    public partial class CCTEBRealCostSqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ChargeStandard = table.Column<float>(nullable: false),
                    CostOfUnitForSaleArea = table.Column<float>(nullable: false),
                    CostOfUnitForTotalArea = table.Column<float>(nullable: false),
                    CostRatio = table.Column<float>(nullable: false),
                    RelativeArea = table.Column<float>(nullable: false),
                    Spec = table.Column<string>(nullable: true),
                    TotalCost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    BaseTypeName = table.Column<string>(maxLength: 30, nullable: true),
                    Comment = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(maxLength: 30, nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    Modifier = table.Column<string>(maxLength: 30, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<int>(nullable: false),
                    TypeOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Comment = table.Column<string>(maxLength: 30, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Creator = table.Column<string>(nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    ItemName = table.Column<string>(maxLength: 30, nullable: true),
                    ItemOrder = table.Column<int>(nullable: false),
                    ItemParentId = table.Column<int>(nullable: true),
                    ItemValue = table.Column<string>(maxLength: 30, nullable: true),
                    ItemValueType = table.Column<string>(maxLength: 30, nullable: true),
                    Modifier = table.Column<string>(maxLength: 30, nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeItem_BaseType_ItemParentId",
                        column: x => x.ItemParentId,
                        principalTable: "BaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountBOC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Discriminator = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    AccountLevel = table.Column<int>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    FinanceAccountId = table.Column<string>(nullable: true),
                    FinanceLevel = table.Column<int>(nullable: true),
                    FinanceName = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    ResponsibleById = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ChargingById = table.Column<int>(nullable: true),
                    IsCharged = table.Column<int>(nullable: true),
                    PricingComent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBOC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBOC_AccountBOC_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AccountBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AccountsId = table.Column<int>(nullable: true),
                    DepType = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_AccountBOC_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "AccountBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_TypeItem_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TypeItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AccountId = table.Column<int>(nullable: true),
                    ActualCostId = table.Column<int>(nullable: true),
                    EstimatedCostId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectAccounts_AccountBOC_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAccounts_AccountValue_ActualCostId",
                        column: x => x.ActualCostId,
                        principalTable: "AccountValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAccounts_AccountValue_EstimatedCostId",
                        column: x => x.EstimatedCostId,
                        principalTable: "AccountValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    ProjectAccountID = table.Column<int>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectShortName = table.Column<string>(nullable: true),
                    ProjectTypeId = table.Column<int>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    TotalAreaForSales = table.Column<float>(nullable: false),
                    TotalBuildingArea = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectAccounts_ProjectAccountID",
                        column: x => x.ProjectAccountID,
                        principalTable: "ProjectAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_TypeItem_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "TypeItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_AccountsId",
                table: "AccountDepartment",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_DepartmentId",
                table: "AccountDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAccounts_AccountId",
                table: "ProjectAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAccounts_ActualCostId",
                table: "ProjectAccounts",
                column: "ActualCostId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAccounts_EstimatedCostId",
                table: "ProjectAccounts",
                column: "EstimatedCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectAccountID",
                table: "Projects",
                column: "ProjectAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBOC_ParentId",
                table: "AccountBOC",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBOC_ResponsibleById",
                table: "AccountBOC",
                column: "ResponsibleById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBOC_ChargingById",
                table: "AccountBOC",
                column: "ChargingById");

            migrationBuilder.CreateIndex(
                name: "IX_TypeItem_ItemParentId",
                table: "TypeItem",
                column: "ItemParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBOC_AccountDepartment_ResponsibleById",
                table: "AccountBOC",
                column: "ResponsibleById",
                principalTable: "AccountDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountBOC_AccountDepartment_ChargingById",
                table: "AccountBOC",
                column: "ChargingById",
                principalTable: "AccountDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDepartment_AccountBOC_AccountsId",
                table: "AccountDepartment");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectAccounts");

            migrationBuilder.DropTable(
                name: "AccountValue");

            migrationBuilder.DropTable(
                name: "AccountBOC");

            migrationBuilder.DropTable(
                name: "AccountDepartment");

            migrationBuilder.DropTable(
                name: "TypeItem");

            migrationBuilder.DropTable(
                name: "BaseType");
        }
    }
}
