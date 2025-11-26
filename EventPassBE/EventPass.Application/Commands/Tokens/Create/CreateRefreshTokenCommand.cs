using MediatR;

namespace EventPass.Application.Commands.Tokens.Create
{
    public class CreateRefreshTokenCommand: IRequest
    {
        public string token {  get; set; }
        public int userId { get; set; }
    }
}
