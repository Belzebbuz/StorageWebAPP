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
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Nomenclature>? Nomenclatures { get; set; }
        public DbSet<Operation>? Operations { get; set;}

        public StorageContext(DbContextOptions<StorageContext> options)
            : base(options)
        {
            
        }
    }
}
