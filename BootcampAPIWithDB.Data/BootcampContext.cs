using BootcampAPIWithDB.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampAPIWithDB.Data
{
    public class BootcampContext : DbContext
    {
        public BootcampContext(DbContextOptions<BootcampContext> options) : base(options)
        {

        }

        public DbSet<BootcampEntity> Bootcamps { get; set; }
        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<ParticipantEntity> Participants { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=Bootcamp;Username=postgres;Password=nova");
    }
}
