using EventPass.Application.DTOs.Users;
using MediatR;

namespace EventPass.Application.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<ResponseUserDto>
    {
        public int Id { get; set; }
        public UpdateUserDto dto { get; set; }  
    }
}
