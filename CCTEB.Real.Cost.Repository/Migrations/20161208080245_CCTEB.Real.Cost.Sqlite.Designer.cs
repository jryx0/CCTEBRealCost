using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CCTEB.Real.Cost.Repository;

namespace CCTEB.Real.Cost.Repository.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20161208080245_CCTEB.Real.Cost.Sqlite")]
    partial class CCTEBRealCostSqlite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("CCTEB.Real.Cost.Models.AccountDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<int>("DeptID");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.ToTable("AccountDepartment");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.AccountValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("ChargeStandard");

                    b.Property<float>("CostOfUnitForSaleArea");

                    b.Property<float>("CostOfUnitForTotalArea");

                    b.Property<float>("CostRatio");

                    b.Property<float>("RelativeArea");

                    b.Property<string>("Spec");

                    b.Property<float>("TotalCost");

                    b.HasKey("Id");

                    b.ToTable("AccountValue");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.BaseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BaseTypeName");

                    b.Property<string>("Comment")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Creator")
                        .HasMaxLength(30);

                    b.Property<bool>("Enable");

                    b.Property<string>("Modifier")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ModifyDate");

                    b.Property<int>("RowVersion");

                    b.Property<int>("TypeOrder");

                    b.HasKey("Id");

                    b.ToTable("BaseType");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.ProjectAccounts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<int?>("ActualCostId");

                    b.Property<int?>("EstimatedCostId");

                    b.Property<int>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("ID");

                    b.HasIndex("AccountId");

                    b.HasIndex("ActualCostId");

                    b.HasIndex("EstimatedCostId");

                    b.ToTable("ProjectAccounts");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FinishTime");

                    b.Property<int?>("ProjectAccountID");

                    b.Property<string>("ProjectName");

                    b.Property<string>("ProjectShortName");

                    b.Property<int?>("ProjectTypeId");

                    b.Property<int>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("StartTime");

                    b.Property<float>("TotalAreaForSales");

                    b.Property<float>("TotalBuildingArea");

                    b.HasKey("Id");

                    b.HasIndex("ProjectAccountID");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Tree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("ParentId");

                    b.Property<int>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AccountBOC");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tree");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.TypeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Creator");

                    b.Property<bool>("Enable");

                    b.Property<string>("ItemName")
                        .HasMaxLength(30);

                    b.Property<int>("ItemOrder");

                    b.Property<int?>("ItemParentId");

                    b.Property<string>("ItemValue")
                        .HasMaxLength(30);

                    b.Property<string>("ItemValueType")
                        .HasMaxLength(30);

                    b.Property<string>("Modifier")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ModifyDate");

                    b.Property<int>("RowVersion");

                    b.HasKey("Id");

                    b.HasIndex("ItemParentId");

                    b.ToTable("TypeItem");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Accounts", b =>
                {
                    b.HasBaseType("CCTEB.Real.Cost.Models.Tree");

                    b.Property<string>("AccountId");

                    b.Property<int>("AccountLevel");

                    b.Property<string>("AccountName");

                    b.Property<string>("Comment");

                    b.Property<string>("FinanceAccountId");

                    b.Property<int>("FinanceLevel");

                    b.Property<string>("FinanceName");

                    b.Property<string>("Label");

                    b.Property<int>("ResposibleByID");

                    b.Property<string>("Title");

                    b.ToTable("Accounts");

                    b.HasDiscriminator().HasValue("Accounts");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.ExpenseAccounts", b =>
                {
                    b.HasBaseType("CCTEB.Real.Cost.Models.Accounts");

                    b.Property<int>("ChargingByID");

                    b.Property<int>("IsCharged");

                    b.Property<string>("PricingComent");

                    b.ToTable("ExpenseAccounts");

                    b.HasDiscriminator().HasValue("ExpenseAccounts");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.AccountDepartment", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.Accounts", "Account")
                        .WithMany("AssistBy")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.ProjectAccounts", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.Tree", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("CCTEB.Real.Cost.Models.AccountValue", "ActualCost")
                        .WithMany()
                        .HasForeignKey("ActualCostId");

                    b.HasOne("CCTEB.Real.Cost.Models.AccountValue", "EstimatedCost")
                        .WithMany()
                        .HasForeignKey("EstimatedCostId");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Projects", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.ProjectAccounts", "ProjectAccount")
                        .WithMany()
                        .HasForeignKey("ProjectAccountID");

                    b.HasOne("CCTEB.Real.Cost.Models.TypeItem", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Tree", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.Tree", "Parent")
                        .WithMany("Child")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.TypeItem", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.BaseType", "ItemParent")
                        .WithMany("HaveItem")
                        .HasForeignKey("ItemParentId");
                });
        }
    }
}
