using EventPass.Domain.Entities.CartItems;
using EventPass.Domain.Entities.Carts;
using EventPass.Domain.Entities.EventCategories;
using EventPass.Domain.Entities.Events;
using EventPass.Domain.Entities.OrderItems;
using EventPass.Domain.Entities.Orders;
using EventPass.Domain.Entities.Organizers;
using EventPass.Domain.Entities.Payments;
using EventPass.Domain.Entities.Performers;
using EventPass.Domain.Entities.SponsorEvents;
using EventPass.Domain.Entities.Sponsors;
using EventPass.Domain.Entities.Tickets;
using EventPass.Domain.Entities.TicketTypes;
using EventPass.Domain.Entities.Users;
using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Entities.VenueTypes;


namespace EventPass.Infrastructure.Persistence.Seeder
{
    public static class DataSeed
    {
        public static async Task SeedAsync(EventPassDbContext context)
        {
            // ========== ROLES ==========
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Name = "User", Description = "Regular user" },
                    new Role { Name = "Organizer", Description = "Event organizer" },
                    new Role { Name = "Admin", Description = "System administrator" }
                );
                await context.SaveChangesAsync();
            }

            // ========== USERS ==========
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Name = "John", Surname = "Doe", Email = "john@example.com", PasswordHash = new byte[0], PasswordSalt = new byte[0], RoleID = 1, RegistrationDate = DateTime.UtcNow, IsActive = true },
                    new User { Name = "Ana", Surname = "Smith", Email = "ana@example.com", PasswordHash = new byte[0], PasswordSalt = new byte[0], RoleID = 2, RegistrationDate = DateTime.UtcNow, IsActive = true },
                    new User { Name = "Marko", Surname = "B", Email = "marko@example.com", PasswordHash = new byte[0], PasswordSalt = new byte[0], RoleID = 3, RegistrationDate = DateTime.UtcNow, IsActive = true }
                );
                await context.SaveChangesAsync();
            }

            // ========== VENUE TYPES ==========
            if (!context.VenueTypes.Any())
            {
                context.VenueTypes.AddRange(
                    new VenueType { Name = "Stadium" },
                    new VenueType { Name = "Arena" },
                    new VenueType { Name = "Club" }
                );
                await context.SaveChangesAsync();
            }

            // ========== VENUES ==========
            if (!context.Venues.Any())
            {
                context.Venues.AddRange(
                    new Venue { Name = "Main Arena", City = "Sarajevo", Country = "BiH", Adress = "Street 1", Capacity = 5000, PostalCode = 71000, VenueTypeID = 2 },
                    new Venue { Name = "Big Stadium", City = "Tuzla", Country = "BiH", Adress = "Street 2", Capacity = 20000, PostalCode = 75000, VenueTypeID = 1 },
                    new Venue { Name = "Night Club", City = "Mostar", Country = "BiH", Adress = "Street 3", Capacity = 800, PostalCode = 88000, VenueTypeID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== PERFORMERS ==========
            if (!context.Performers.Any())
            {
                context.Performers.AddRange(
                    new Performer { Name = "DJ Alpha", ImageURL = "", Website = "" },
                    new Performer { Name = "Rock Band X", ImageURL = "", Website = "" },
                    new Performer { Name = "Stand-up Guy", ImageURL = "", Website = "" }
                );
                await context.SaveChangesAsync();
            }

            // ========== EVENT CATEGORIES ==========
            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(
                    new EventCategory { Name = "Music", Description = "Music events", IconUrl = "" },
                    new EventCategory { Name = "Sport", Description = "Sport events", IconUrl = "" },
                    new EventCategory { Name = "Comedy", Description = "Comedy shows", IconUrl = "" }
                );
                await context.SaveChangesAsync();
            }

            // ========== ORGANIZERS ==========
            if (!context.Organizers.Any())
            {
                context.Organizers.AddRange(
                    new Organizer
                    {
                        Name = "EventCo",
                        LogoUrl = "https://example.com/logo1.png",
                        Email = "contact@eventco.com",
                        Telephone = "+38712345678",
                        Website = "https://eventco.com",
                        City = "Sarajevo",
                        Country = "BiH"
                    },
                    new Organizer
                    {
                        Name = "FunGroup",
                        LogoUrl = "https://example.com/logo2.png",
                        Email = "info@fungroup.com",
                        Telephone = "+38723456789",
                        Website = "https://fungroup.com",
                        City = "Tuzla",
                        Country = "BiH"
                    },
                    new Organizer
                    {
                        Name = "LaughInc",
                        LogoUrl = "https://example.com/logo3.png",
                        Email = "hello@laughinc.com",
                        Telephone = "+38734567890",
                        Website = "https://laughinc.com",
                        City = "Mostar",
                        Country = "BiH"
                    }
                );
                await context.SaveChangesAsync();
            }

            // ========== EVENTS ==========
            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        Name = "Alpha Party",
                        Description = "Big DJ event",
                        BannerURL = "test.url",
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddHours(4),
                        Duration = new TimeOnly(4, 0),
                        MinimumAge = 18,
                        PerformerID = 1,
                        CategoryId = 1,
                        OrganizerID = 1,
                        VenueId = 1
                    },
                    new Event
                    {
                        Name = "Rock Night",
                        Description = "Rock concert",
                        BannerURL = "test.url",
                        StartDate = DateTime.UtcNow.AddDays(1),
                        EndDate = DateTime.UtcNow.AddDays(1).AddHours(3),
                        Duration = new TimeOnly(3, 0),
                        MinimumAge = 16,
                        PerformerID = 2,
                        CategoryId = 1,
                        OrganizerID = 2,
                        VenueId = 2
                    },
                    new Event
                    {
                        Name = "Comedy Show",
                        Description = "Funny night",
                        BannerURL = "test.url",
                        StartDate = DateTime.UtcNow.AddDays(2),
                        EndDate = DateTime.UtcNow.AddDays(2).AddHours(2),
                        Duration = new TimeOnly(2, 0),
                        MinimumAge = 12,
                        PerformerID = 3,
                        CategoryId = 3,
                        OrganizerID = 3,
                        VenueId = 3
                    }
                );
                await context.SaveChangesAsync();
            }

            // ========== SECTIONS ==========
            if (!context.Sections.Any())
            {
                context.Sections.AddRange(
                    new Section { Name = "VIP", Capacity = 100, VenueID = 1 },
                    new Section { Name = "Regular", Capacity = 300, VenueID = 1 },
                    new Section { Name = "Premium", Capacity = 150, VenueID = 2 }
                );
                await context.SaveChangesAsync();
            }

            // ========== TICKET TYPES ==========
            if (!context.TicketTypes.Any())
            {
                context.TicketTypes.AddRange(
                    new TicketType { Price = 20m, TicketsRemaining = 50, TicketsSold = 0, SectionID = 1, EventID = 1 },
                    new TicketType { Price = 15m, TicketsRemaining = 40, TicketsSold = 0, SectionID = 2, EventID = 2 },
                    new TicketType { Price = 30m, TicketsRemaining = 30, TicketsSold = 0, SectionID = 3, EventID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== TICKETS ==========
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(
                    new Ticket { TicketNumber = 1001, UserID = 1, TicketTypeID = 1 },
                    new Ticket { TicketNumber = 1002, UserID = 2, TicketTypeID = 2 },
                    new Ticket { TicketNumber = 1003, UserID = 3, TicketTypeID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== CARTS ==========
            if (!context.Carts.Any())
            {
                context.Carts.AddRange(
                    new Cart { UserID = 1 },
                    new Cart { UserID = 2 },
                    new Cart { UserID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== CART ITEMS ==========
            if (!context.CartItems.Any())
            {
                context.CartItems.AddRange(
                    new CartItem { CartId = 1, TicketID = 1 },
                    new CartItem { CartId = 2, TicketID = 2 },
                    new CartItem { CartId = 3, TicketID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== ORDERS ==========
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        TotalAmount = 20m,
                        PaymentStatus = true,
                        PaymentMethod = "Card",
                        BillingAdress = "Billing 1",
                        ShippingAdress = "Shipping 1",
                        TransactionNumber = 100001,
                        UserID = 1
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        TotalAmount = 15m,
                        PaymentStatus = true,
                        PaymentMethod = "Card",
                        BillingAdress = "Billing 2",
                        ShippingAdress = "Shipping 2",
                        TransactionNumber = 100002,
                        UserID = 2
                    },
                    new Order
                    {
                        OrderDate = DateTime.UtcNow,
                        TotalAmount = 30m,
                        PaymentStatus = true,
                        PaymentMethod = "Card",
                        BillingAdress = "Billing 3",
                        ShippingAdress = "Shipping 3",
                        TransactionNumber = 100003,
                        UserID = 3
                    }
                );
                await context.SaveChangesAsync();
            }

            // ========== ORDER ITEMS ==========
            if (!context.OrderItems.Any())
            {
                context.OrderItems.AddRange(
                    new OrderItem { PriceAtPurchase = 20m, OrderID = 1, TicketID = 1 },
                    new OrderItem { PriceAtPurchase = 15m, OrderID = 2, TicketID = 2 },
                    new OrderItem { PriceAtPurchase = 30m, OrderID = 3, TicketID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== PAYMENTS ==========
            if (!context.Payments.Any())
            {
                context.Payments.AddRange(
                    new Payment { Amount = 20m, Method = "Card", Status = true, TransactionDate = DateTime.UtcNow, OrderID = 1 },
                    new Payment { Amount = 15m, Method = "Card", Status = true, TransactionDate = DateTime.UtcNow, OrderID = 2 },
                    new Payment { Amount = 30m, Method = "Card", Status = true, TransactionDate = DateTime.UtcNow, OrderID = 3 }
                );
                await context.SaveChangesAsync();
            }

            // ========== SPONSORS ==========
            if (!context.Sponsors.Any())
            {
                context.Sponsors.AddRange(
                    new Sponsor { Name = "Sponsor A", LogoUrl = "", websiteUrl = "sponsor-a.com", Email = "sponA@test.com", Phone = "111" },
                    new Sponsor { Name = "Sponsor B", LogoUrl = "", websiteUrl = "sponsor-b.com", Email = "sponB@test.com", Phone = "222" },
                    new Sponsor { Name = "Sponsor C", LogoUrl = "", websiteUrl = "sponsor-c.com", Email = "sponC@test.com", Phone = "333" }
                );
                await context.SaveChangesAsync();
            }

            // ========== SPONSOR EVENTS ==========
            if (!context.SponsorEvents.Any())
            {
                context.SponsorEvents.AddRange(
                    new SponsorEvent { Tier = "Gold", AmountSponsored = 1000m, EventID = 1, SponsorID = 1 },
                    new SponsorEvent { Tier = "Silver", AmountSponsored = 500m, EventID = 2, SponsorID = 2 },
                    new SponsorEvent { Tier = "Bronze", AmountSponsored = 250m, EventID = 3, SponsorID = 3 }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
