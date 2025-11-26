namespace EventPass.Application.DTOs.SponsorDTOs
{
    public class ResponseSponsorEventDto
    {
        public int Id { get; set; }
        public string tier { get; set; }
        public decimal amountSponsored { get; set; }
        public int eventId { get; set; }
        public int sponsorId { get; set; }
    }
}
