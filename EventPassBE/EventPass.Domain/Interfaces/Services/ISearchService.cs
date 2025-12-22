using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Domain.Interfaces.Services
{
    public interface ISearchService
    {
        public Task<IEnumerable<string>> getPredictionsAsync(string input,CancellationToken ct);
    }
}
