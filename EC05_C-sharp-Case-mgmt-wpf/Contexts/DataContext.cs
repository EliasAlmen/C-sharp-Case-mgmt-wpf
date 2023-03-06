using EC05_C_sharp_Case_mgmt_wpf.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_Case_mgmt_wpf.Contexts
{
    class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elias\Downloads\EC-utbildning-webbutvecklare-NET\05-Datalagring\EC05-Databases\EC05_C-sharp-Case-mgmt\EC05_C-sharp-Case-mgmt-wpf\Contexts\sql_case_db.mdf;Integrated Security=True;Connect Timeout=30";
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
