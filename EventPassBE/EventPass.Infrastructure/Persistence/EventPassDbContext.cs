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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TicketType)
                .WithMany(tt => tt.Tickets)
                .HasForeignKey(t => t.TicketTypeID)
                .OnDelete(DeleteBehavior.NoAction);

            // Ticket → User
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            // OrderItem → Ticket
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Ticket)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(oi => oi.TicketID)
                .OnDelete(DeleteBehavior.NoAction);

            // CartItem → Ticket
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Ticket)
                .WithMany(t => t.CartItems)
                .HasForeignKey(ci => ci.TicketID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}