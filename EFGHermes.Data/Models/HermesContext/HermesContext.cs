

using Microsoft.EntityFrameworkCore;

namespace EFGHermes.Data.Models
{
    public class HermesContext : DbContext
    {
        public HermesContext()
        {
        }

        public HermesContext(DbContextOptions<HermesContext> options) : base(options)
        {
        }

        public DbSet<Investor> Investors { get; set; }
        public DbSet<InvestorSector> InvestorSectors { get; set; }
        public DbSet<Presenter> Presenters { get; set; }
        public DbSet<PresenterSector> PresenterSectors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomSlot> RoomSlots { get; set; }
        public DbSet<Sector> Sectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investor>().ToTable("Investors");
            modelBuilder.Entity<InvestorSector>().ToTable("InvestorSectors");
            modelBuilder.Entity<Presenter>().ToTable("Presenters");
            modelBuilder.Entity<PresenterSector>().ToTable("PresenterSectors");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Hotel>().ToTable("Hotels");
            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<RoomSlot>().ToTable("RoomSlots");
            modelBuilder.Entity<Sector>().ToTable("Sectors");

            modelBuilder.Entity<Reservation>().HasOne(x => x.Room).WithMany(x=> x.Reservations).HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(x => x.RoomSlot).WithMany(x => x.Reservations).HasForeignKey(x => x.RoomSlotId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(x => x.Investor).WithMany(x => x.Reservations).HasForeignKey(x => x.InvestorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(x => x.Presenter).WithMany(x => x.Reservations).HasForeignKey(x => x.PresenterId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(x => x.Hotel).WithMany(x => x.Reservations).HasForeignKey(x => x.HotelId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reservation>().HasOne(x => x.Sector).WithMany().HasForeignKey(x => x.SectorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EFGHermesDB;Trusted_Connection=True;");
            }

        }
    }
}
