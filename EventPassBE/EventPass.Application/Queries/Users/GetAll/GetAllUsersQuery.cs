using EventPass.Application.DTOs.Users;
using MediatR;

namespace EventPass.Application.Queries.Users.GetAll
{
    public class GetAllUsersQuery: IRequest<List<ResponseUserDto>>
    {
    }
}
