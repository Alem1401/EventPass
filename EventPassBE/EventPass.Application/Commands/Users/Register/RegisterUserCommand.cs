using MediatR;

public record RegisterUserCommand(string Name, string Surname, string Email, string Password) : IRequest<int>;