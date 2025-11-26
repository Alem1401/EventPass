using EventPass.Application.DTOs.Users;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Queries.Users.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<ResponseUserDto>>
    {
        IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ResponseUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllUsersAsync(cancellationToken);
            var response = new List<ResponseUserDto>();
            foreach (var item in users)
            {
                response.Add(new ResponseUserDto
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Email = item.Email 
                });
            }

            return response;
        }
    }
}
