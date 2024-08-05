using Microsoft.EntityFrameworkCore;
using PasteBin.Models;

namespace PasteBin.Data
{
    public class PasteBinContext : DbContext
    {
        public PasteBinContext (DbContextOptions<PasteBinContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Paste> Pastes { get; set; } = default!;

        public PasteBinContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=PasteBinDevDB;trusted_connection=true;trustServerCertificate=true;");
            }
        }
    }
}
