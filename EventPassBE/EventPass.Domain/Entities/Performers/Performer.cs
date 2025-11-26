

namespace EventPass.Domain.Entities.Performers;

    public class Performer
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string ImageURL { get; set; }
	public string Website { get; set; }
	public ICollection<PerformerSocialMedia> SocialMedia { get; set; } = new HashSet<PerformerSocialMedia>();
	public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
