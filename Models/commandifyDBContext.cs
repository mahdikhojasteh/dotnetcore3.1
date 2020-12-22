using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Commander.Models
{
    public partial class commandifyDBContext : DbContext
    {
        public commandifyDBContext()
        {
        }

        public commandifyDBContext(DbContextOptions<commandifyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Command> Command { get; set; }

        //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //         {
        //             if (!optionsBuilder.IsConfigured)
        //             {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                 optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=commandifyDB;User ID=sa;Password=94Mahdic;");
        //             }
        //         }

        //         protected override void OnModelCreating(ModelBuilder modelBuilder)
        //         {
        //             modelBuilder.Entity<Command>(entity =>
        //             {
        //                 entity.Property(e => e.Command1).IsUnicode(false);

        //                 entity.Property(e => e.Description).IsUnicode(false);

        //                 entity.Property(e => e.Platform).IsUnicode(false);
        //             });

        //             OnModelCreatingPartial(modelBuilder);
        //         }

        //         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
