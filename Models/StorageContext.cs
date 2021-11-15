using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageWebAPP.Models
{
    public class StorageContext: DbContext
    {
        public DbSet<AccountModel>? Accounts { get; set; }

        public DbSet<NomenclatureModel>? Nomenclature { get; set; }
        public DbSet<MovementTypeModel>? MovementType { get; set;}
        public DbSet<BalanceModel>? Balance { get; set; }
        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>(entity =>
                {
                    entity.HasKey(x => x.Id);
                    entity.Property(x => x.Name);

                    entity.HasData(new AccountModel { Id = 1, Name = "General manager" });
                });
            modelBuilder.Entity<NomenclatureModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.Property(x => x.Measure);
            });
            modelBuilder.Entity<MovementTypeModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);

                entity.HasData(new MovementTypeModel { Id = 1, Name = "Obtaining" });
                entity.HasData(new MovementTypeModel { Id = 2, Name = "Consumption" });
            });

            modelBuilder.Entity<BalanceModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Date);
                entity.Property(x => x.NomenclatureId);
                entity.Property(x => x.ResponsibleId);
                entity.Property(x => x.Count);
                entity.Property(x => x.MovementTypeId);
            });
        }
    }
}
