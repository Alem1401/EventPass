using System;
using System.Collections.Generic;

namespace EventPass.Domain.Entities.Performers
{
	public class PerformerSocialMedia
	{
		public int Id { get; set; }
		public string Link { get; set; }
		public int? PerformerID { get; set; }
		public Performer? Performer { get; set; }
	}
}
