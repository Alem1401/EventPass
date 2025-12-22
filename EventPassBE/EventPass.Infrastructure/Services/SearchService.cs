using EventPass.Domain.Interfaces.Services;
using EventPass.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPass.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        EventPassDbContext _context;

        public SearchService(EventPassDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<string>> getPredictionsAsync(string input, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return Enumerable.Empty<string>();

            var searchTerm = input.ToLower();

           
            var venues = await _context.Venues
                .Where(v => v.Name.ToLower().Contains(searchTerm))
                .Select(v => v.Name)
                .ToListAsync(ct);

            var events = await _context.Events
                .Where(e => e.Name.ToLower().Contains(searchTerm))
                .Select(e => e.Name)
                .ToListAsync(ct);

            var performers = await _context.Performers
                .Where(p => p.Name.ToLower().Contains(searchTerm))
                .Select(p => p.Name)
                .ToListAsync(ct);

  
            var allNames = venues.Concat(events).Concat(performers);

            return allNames
                .Distinct() 
                .Take(5)
                .ToList();
        }
    }
    
}
