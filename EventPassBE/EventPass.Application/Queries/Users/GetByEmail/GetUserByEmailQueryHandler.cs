using EventPass.Application.DTOs.Users;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Queries.Users.GetByEmail
{
    public class GetUserByEmailQueryHandler: IRequestHandler<GetUserByEmailQuery, ResponseUserDto>
    {
        IUserRepository _repository;

        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseUserDto> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            var response = await _repository.GetUserByEmailAsync(query.email, cancellationToken);
            if (response == null) return null;
            return new ResponseUserDto
            {
                Id = response.Id,
                Name = response.Name,
                Surname = response.Surname,
                Email = response.Email
            };
        }
    }
}
