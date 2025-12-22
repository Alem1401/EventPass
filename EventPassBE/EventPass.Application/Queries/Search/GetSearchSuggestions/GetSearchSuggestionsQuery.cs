using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Application.Queries.Search.GetSearchSuggestions
{
    public class GetSearchSuggestionsQuery : IRequest<IEnumerable<string>>
    {
        public string searchTerm { get; set; }  
    }
}
