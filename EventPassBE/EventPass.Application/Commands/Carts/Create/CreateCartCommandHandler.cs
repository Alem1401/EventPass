using EventPass.Application.DTOs.CartDTOs;
using EventPass.Domain.Entities.Carts;
using EventPass.Domain.Interfaces.Carts;
using MediatR;

namespace EventPass.Application.Commands.Carts.Create
{
    public class CreateCartCommandHandler: IRequestHandler<CreateCartCommand, ResponseCartDto>
    {
        ICartsRepository _repository;

        public CreateCartCommandHandler(ICartsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseCartDto> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var newCart = new Cart
            {
                UserID = command.dto.userId
            };
            var response = await _repository.AddCartAsync(newCart, cancellationToken);  
              
            return new ResponseCartDto
            {
                Id = response.Id,
                userId = response.UserID
            };
        }
    }
}
