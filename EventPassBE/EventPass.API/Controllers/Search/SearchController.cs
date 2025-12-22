using EventPass.Application.Queries.Search.GetSearchSuggestions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPass.API.Controllers.Search
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        IMediator _mediatr;

        public SearchController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("suggestions")]

        public async Task<IActionResult> GetSuggestions([FromQuery] string term, CancellationToken ct)
        {

            var results = await _mediatr.Send(new GetSearchSuggestionsQuery { searchTerm = term }, ct);
            return Ok(results);
        }
    }
}
