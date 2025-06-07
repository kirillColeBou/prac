using Microsoft.EntityFrameworkCore;
using prac.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac.Classes.Context
{
    public class Context : DbContext
    {
        public DbSet<Partner> partner { get; set; }
        public DbSet<TypePartner> typePartner { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<PartnerProduct> partner_product { get; set; }

        public Context()
        {
            Database.EnsureCreated();
            partner.Load();
            typePartner.Load();
            product.Load();
            partner_product.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.127.126.31;port=3306;database=prac;uid=root;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
