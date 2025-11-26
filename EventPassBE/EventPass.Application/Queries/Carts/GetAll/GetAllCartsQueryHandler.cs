using EventPass.Application.DTOs.CartDTOs;
using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Queries.Carts.GetAll
{
    public class GetAllCartsQueryHandler: IRequestHandler<GetAllCartsQuery, IEnumerable<ResponseCartDto>>
    {
        ICartsRepository _repository;

        public GetAllCartsQueryHandler(ICartsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseCartDto>> Handle(GetAllCartsQuery query, CancellationToken cancellationToken)
        {
            var carts = await _repository.GetAllCartsAsync(cancellationToken);

            return carts.Select(c => new ResponseCartDto
            {
                Id = c.Id,
                userId = c.UserID
            });
        }
    }
}
