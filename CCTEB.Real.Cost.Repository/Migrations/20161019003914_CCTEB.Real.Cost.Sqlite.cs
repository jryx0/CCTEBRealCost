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
                name: "ProjectAccountsBOC",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Discriminator = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    RowVersion = table.Column<int>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    AccountLevel = table.Column<int>(nullable: true),
                    AccountName = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CostOfActualId = table.Column<int>(nullable: true),
                    CostOfPredictId = table.Column<int>(nullable: true),
                    FinanceAccountId = table.Column<string>(nullable: true),
                    FinanceLevel = table.Column<int>(nullable: true),
                    FinanceName = table.Column<int>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsCharged = table.Column<int>(nullable: true),
                    PricingComent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAccountsBOC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAccountsBOC_AccountValue_CostOfActualId",
                        column: x => x.CostOfActualId,
                        principalTable: "AccountValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAccountsBOC_AccountValue_CostOfPredictId",
                        column: x => x.CostOfPredictId,
                        principalTable: "AccountValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAccountsBOC_ProjectAccountsBOC_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProjectAccountsBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AccountDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AccountId = table.Column<long>(nullable: true),
                    AccountsId = table.Column<long>(nullable: true),
                    AccountsId1 = table.Column<long>(nullable: true),
                    DepType = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    ExpenseAccountsId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_ProjectAccountsBOC_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ProjectAccountsBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_ProjectAccountsBOC_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "ProjectAccountsBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_ProjectAccountsBOC_AccountsId1",
                        column: x => x.AccountsId1,
                        principalTable: "ProjectAccountsBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_TypeItem_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TypeItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountDepartment_ProjectAccountsBOC_ExpenseAccountsId",
                        column: x => x.ExpenseAccountsId,
                        principalTable: "ProjectAccountsBOC",
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
                    ProjectAccountId = table.Column<long>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectShortName = table.Column<string>(nullable: true),
                    ProjectTypeId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    TotalAreaForSales = table.Column<float>(nullable: false),
                    TotalBuildingArea = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectAccountsBOC_ProjectAccountId",
                        column: x => x.ProjectAccountId,
                        principalTable: "ProjectAccountsBOC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_TypeItem_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "TypeItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_AccountId",
                table: "AccountDepartment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_AccountsId",
                table: "AccountDepartment",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_AccountsId1",
                table: "AccountDepartment",
                column: "AccountsId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_DepartmentId",
                table: "AccountDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDepartment_ExpenseAccountsId",
                table: "AccountDepartment",
                column: "ExpenseAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectAccountId",
                table: "Projects",
                column: "ProjectAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAccountsBOC_ParentId",
                table: "ProjectAccountsBOC",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAccountsBOC_CostOfActualId",
                table: "ProjectAccountsBOC",
                column: "CostOfActualId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAccountsBOC_CostOfPredictId",
                table: "ProjectAccountsBOC",
                column: "CostOfPredictId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeItem_ItemParentId",
                table: "TypeItem",
                column: "ItemParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDepartment");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectAccountsBOC");

            migrationBuilder.DropTable(
                name: "TypeItem");

            migrationBuilder.DropTable(
                name: "AccountValue");

            migrationBuilder.DropTable(
                name: "BaseType");
        }
    }
}
