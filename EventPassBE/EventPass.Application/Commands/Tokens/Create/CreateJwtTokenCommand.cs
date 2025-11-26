using MediatR;

namespace EventPass.Application.Commands.Tokens.Create
{
    public class CreateJwtTokenCommand: IRequest<string>
    {
        public int userId {  get; set; }
    }
}
