using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WorkersApp.Model
{
    public partial class MainModel : DbContext
    {
        public MainModel()
            : base("name=MainModel")
        {
        }

        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<WorkersTasksView> WorkersTasksView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .Property(e => e.TaskCategory)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.TaskDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Workers)
                .HasForeignKey(e => e.WorkerID);

            modelBuilder.Entity<WorkersTasksView>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<WorkersTasksView>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
