using EventPass.Domain.Entities.Tickets;
using System;
using System.Collections.Generic;

namespace EventPass.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}