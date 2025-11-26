using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.DTOs.ReviewDTOs
{
    public class CreateReviewDto
    {
        public int Rating { get; set; }
        public int PerformerID { get; set; }
        public int UserID { get; set; }
    }
}