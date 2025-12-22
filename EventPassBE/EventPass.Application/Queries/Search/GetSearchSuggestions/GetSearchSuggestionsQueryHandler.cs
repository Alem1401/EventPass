using EventPass.Domain.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Search.GetSearchSuggestions
{
    public class GetSearchSuggestionsQueryHandler : IRequestHandler<GetSearchSuggestionsQuery, IEnumerable<string>>
    {
        ISearchService _searchService;
        public GetSearchSuggestionsQueryHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public Task<IEnumerable<string>> Handle(GetSearchSuggestionsQuery request, CancellationToken cancellationToken)
        {
           var results = _searchService.getPredictionsAsync(request.searchTerm, cancellationToken);
            return results;
        }
    }
}
