namespace EventPass.Domain.Entities.Token
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
