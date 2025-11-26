using EventPass.Domain.Entities.VenueTypes;
using EventPass.Domain.Interfaces.Venues;
using MediatR;


namespace EventPass.Application.VenueTypes.Queries
{
    public class GetVenueTypesQueryHandler : IRequestHandler<GetVenueTypesQuery, IEnumerable<VenueType>>
    {
        private readonly IVenueTypeRepository _repository;

        public GetVenueTypesQueryHandler(IVenueTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VenueType>> Handle(GetVenueTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllVenueTypesAsync(cancellationToken); 
        }
    }
}
