using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Entity
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Advice> Advices { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<CODE> CODEs { get; set; }
        public virtual DbSet<CodeDetail> CodeDetails { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomCategory> RoomCategories { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Utility> Utilities { get; set; }
        public virtual DbSet<UtilityDetail> UtilityDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advice>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Bill>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Bill>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<CODE>()
                .Property(e => e.CODE1)
                .IsFixedLength();

            modelBuilder.Entity<CODE>()
                .HasMany(e => e.CodeDetails)
                .WithRequired(e => e.CODE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.Logo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.Hotline)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Config>()
                .Property(e => e.Facebook)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Create_by);

            modelBuilder.Entity<Image>()
                .Property(e => e.Url)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.CodeDetails)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.UtilityDetails)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomCategory>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.RoomCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Advices)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Support_by);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bills)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Confirm_by);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Create_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utility>()
                .HasMany(e => e.UtilityDetails)
                .WithRequired(e => e.Utility)
                .WillCascadeOnDelete(false);
        }
    }
}
