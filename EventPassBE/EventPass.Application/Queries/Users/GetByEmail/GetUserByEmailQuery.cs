using EventPass.Application.DTOs.Users;
using MediatR;

namespace EventPass.Application.Queries.Users.GetByEmail
{
    public class GetUserByEmailQuery: IRequest<ResponseUserDto>
    {
        public string email { get; set; }
    }
}
