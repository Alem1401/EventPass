using EventPass.Application.DTOs.CartDTOs;
using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Queries.Carts.GetByUserId
{
    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdQuery, ResponseCartDto>
    {
        ICartsRepository _repository;

        public GetCartByUserIdQueryHandler(ICartsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseCartDto> Handle(GetCartByUserIdQuery query, CancellationToken cancellationToken)
        {
            var cart = await _repository.GetCartByUserIdAsync(query.userId, cancellationToken);
            if (cart == null) return null;
            return new ResponseCartDto
            {
                Id = cart.Id,
                userId = (int)cart.UserID
            };
        }
    }
}
