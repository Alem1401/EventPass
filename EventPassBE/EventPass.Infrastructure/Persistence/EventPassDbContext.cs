using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using EventPass.Domain.Entities.EventCategories;
using EventPass.Domain.Entities.Carts;
using EventPass.Domain.Entities.CartItems;
using EventPass.Domain.Entities.Orders;
using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Entities.Payments;
using EventPass.Domain.Entities.Organizers;
using EventPass.Domain.Entities.Sponsors;
using EventPass.Domain.Entities.SponsorEvents;
using EventPass.Domain.Entities.Tickets;
using EventPass.Domain.Entities.TicketTypes;
using EventPass.Domain.Entities.Users;
using EventPass.Domain.Entities.VenueTypes;
using EventPass.Domain.Entities.Token;

namespace EventPass.Infrastructure.Persistence
{
    public class EventPassDbContext : DbContext
    {
        public EventPassDbContext(DbContextOptions<EventPassDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            modelBuilder.Entity<Venue>()
                .Ignore(v => v.Events);

            ConfigureCriticalRelationships(modelBuilder);
        }

        private void ConfigureCriticalRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.HasOne(tt => tt.Section)
                      .WithMany(s => s.TicketTypes)
                      .HasForeignKey(tt => tt.SectionID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tt => tt.Event)
                      .WithMany(e => e.TicketTypes)
                      .HasForeignKey(tt => tt.EventID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(t => t.TicketType)
                      .WithMany(tt => tt.Tickets)
                      .HasForeignKey(t => t.TicketTypeID)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(e => e.Venue)
                      .WithMany(v => v.Events)
                      .HasForeignKey(e => e.VenueId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasOne(s => s.Venue)
                      .WithMany(v => v.Sections)
                      .HasForeignKey(s => s.VenueID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        //User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        //Cart
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        //Event
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }

        //Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        //Organizer
        public DbSet<Organizer> Organizers { get; set; }

        //Performer
        public DbSet<Performer> Performers { get; set; }
        public DbSet<PerformerSocialMedia> PerformerSocialMedias { get; set; }
        public DbSet<Review> Reviews{ get; set; }

        //Sponsor
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SponsorEvent> SponsorEvents { get; set; }

        //Ticket
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }

        //Venue
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueType> VenueTypes{ get; set; }
        public DbSet<Section> Sections{ get; set; }

        //Token

        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}