using EventPass.Application.DTOs.Users;
using MediatR;

namespace EventPass.Application.Queries.Users.GetById
{
    public class GetUserByIdQuery: IRequest<ResponseUserDto>
    {
        public int Id { get; set; }
    }
}
