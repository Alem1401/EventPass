namespace EventPass.Application.DTOs.SponsorDTOs
{
    public class CreateSponsorEventDto
    {
        public string tier { get; set; }
        public decimal amountSponsored { get; set; }
        public int eventId { get; set; }
        public int sponsorId { get; set; }
    }
}
