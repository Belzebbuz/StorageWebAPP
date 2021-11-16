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
            Database.EnsureCreated();
        }
    }
}
