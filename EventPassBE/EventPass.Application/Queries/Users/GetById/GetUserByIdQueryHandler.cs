using EventPass.Application.DTOs.Users;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Queries.Users.GetById
{
    public class GetUserByIdQueryHandler: IRequestHandler<GetUserByIdQuery, ResponseUserDto>
    {
        IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                return null;
            }
            else
            {
                var response = new ResponseUserDto()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                };
                return response;
            }
        }
    }
}
