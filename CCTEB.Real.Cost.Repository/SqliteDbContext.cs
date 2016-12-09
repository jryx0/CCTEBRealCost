using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CCTEB.Real.Cost.Repository
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext()
        {            
            this.EFLog();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlite("Data Source=Real.Cost.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Tree>().ToTable("AccountBOC");            
            modelBuilder.Entity<Models.Projects>().ToTable("Projects");
            modelBuilder.Entity<Models.ProjectAccounts>().ToTable("ProjectAccounts");
            
         
            modelBuilder.Entity<Models.Accounts>(x =>
            {
                x.Property(p => p.RowVersion).IsConcurrencyToken().ValueGeneratedNever();                
            });

            modelBuilder.Entity<Models.ExpenseAccounts>()
                .Property(p => p.RowVersion).IsConcurrencyToken().ValueGeneratedNever();


            modelBuilder.Entity<Models.ProjectAccounts>()
                .Property(p => p.RowVersion).IsConcurrencyToken().ValueGeneratedNever();

            modelBuilder.Entity<Models.Projects>()
                .Property(p => p.RowVersion).IsConcurrencyToken().ValueGeneratedNever();

            modelBuilder.Entity("CCTEB.Real.Cost.Models.Tree", b =>
            {
                b.HasOne("CCTEB.Real.Cost.Models.Tree", "Parent")
                    .WithMany("Child")
                    .HasForeignKey("ParentId")
                    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity("CCTEB.Real.Cost.Models.AccountDepartment", b =>
            //{
            //    b.HasOne("CCTEB.Real.Cost.Models.Accounts")
            //        .WithMany("AssistBy")
            //        .HasForeignKey("AccountsId")
            //        .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade); ;
            //});

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            foreach (var entry in this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                var v = entry.Entity as Models.IRowVersion;
                if (v != null)
                {
                    v.RowVersion++;//
                                   //v.Version = System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
                }
            }

            return base.SaveChanges();
        }
    }
}
