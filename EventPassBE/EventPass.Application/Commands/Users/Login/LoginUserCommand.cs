using EventPass.Application.DTOs.Users;
using MediatR;
public record LoginUserCommand(string Email, string Password) : IRequest<LoginResponseDto>;