using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CCTEB.Real.Cost.Repository;

namespace CCTEB.Real.Cost.Repository.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("CCTEB.Real.Cost.Models.AccountDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AccountId");

                    b.Property<long?>("AccountsId");

                    b.Property<long?>("AccountsId1");

                    b.Property<int>("DepType");

                    b.Property<int?>("DepartmentId");

                    b.Property<long?>("ExpenseAccountsId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountsId");

                    b.HasIndex("AccountsId1");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ExpenseAccountsId");

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

                    b.Property<string>("BaseTypeName")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Comment")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Creator")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<bool>("Enable");

                    b.Property<string>("Modifier")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<DateTime>("ModifyDate");

                    b.Property<int>("RowVersion");

                    b.Property<int>("TypeOrder");

                    b.HasKey("Id");

                    b.ToTable("BaseType");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FinishTime");

                    b.Property<long?>("ProjectAccountId");

                    b.Property<string>("ProjectName");

                    b.Property<string>("ProjectShortName");

                    b.Property<int?>("ProjectTypeId");

                    b.Property<DateTime>("StartTime");

                    b.Property<float>("TotalAreaForSales");

                    b.Property<float>("TotalBuildingArea");

                    b.HasKey("Id");

                    b.HasIndex("ProjectAccountId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Tree", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<long?>("ParentId");

                    b.Property<int>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ProjectAccountsBOC");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tree");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.TypeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Creator");

                    b.Property<bool>("Enable");

                    b.Property<string>("ItemName")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<int>("ItemOrder");

                    b.Property<int?>("ItemParentId");

                    b.Property<string>("ItemValue")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("ItemValueType")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Modifier")
                        .HasAnnotation("MaxLength", 30);

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

                    b.Property<int>("AccountName");

                    b.Property<string>("Comment");

                    b.Property<int?>("CostOfActualId");

                    b.Property<int?>("CostOfPredictId");

                    b.Property<string>("FinanceAccountId");

                    b.Property<int>("FinanceLevel");

                    b.Property<int>("FinanceName");

                    b.Property<string>("Label");

                    b.Property<string>("Title");

                    b.HasIndex("CostOfActualId");

                    b.HasIndex("CostOfPredictId");

                    b.ToTable("Root");

                    b.HasDiscriminator().HasValue("Accounts");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.ExpenseAccounts", b =>
                {
                    b.HasBaseType("CCTEB.Real.Cost.Models.Accounts");

                    b.Property<int>("IsCharged");

                    b.Property<string>("PricingComent");

                    b.ToTable("Root");

                    b.HasDiscriminator().HasValue("ExpenseAccounts");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.AccountDepartment", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.Accounts", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("CCTEB.Real.Cost.Models.Accounts")
                        .WithMany("AssistBy")
                        .HasForeignKey("AccountsId");

                    b.HasOne("CCTEB.Real.Cost.Models.Accounts")
                        .WithMany("ResponsibleBy")
                        .HasForeignKey("AccountsId1");

                    b.HasOne("CCTEB.Real.Cost.Models.TypeItem", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("CCTEB.Real.Cost.Models.ExpenseAccounts")
                        .WithMany("ChargingBy")
                        .HasForeignKey("ExpenseAccountsId");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Projects", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.Tree", "ProjectAccount")
                        .WithMany()
                        .HasForeignKey("ProjectAccountId");

                    b.HasOne("CCTEB.Real.Cost.Models.TypeItem", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Tree", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.Tree", "Parent")
                        .WithMany("Child")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.TypeItem", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.BaseType", "ItemParent")
                        .WithMany("HaveItem")
                        .HasForeignKey("ItemParentId");
                });

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Accounts", b =>
                {
                    b.HasOne("CCTEB.Real.Cost.Models.AccountValue", "CostOfActual")
                        .WithMany()
                        .HasForeignKey("CostOfActualId");

                    b.HasOne("CCTEB.Real.Cost.Models.AccountValue", "CostOfPredict")
                        .WithMany()
                        .HasForeignKey("CostOfPredictId");
                });
        }
    }
}
