using EventPass.Domain.Entities.Users;


namespace EventPass.Domain.Entities.Carts
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}