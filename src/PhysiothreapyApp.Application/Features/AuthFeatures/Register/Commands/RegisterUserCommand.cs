using MediatR;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.DTOs;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Services;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.Application.Features.AuthFeatures.Register.Commands;

public record RegisterUserCommand
    (
    string FirstName,
    string LastName, 
    string UserName,
    string Email,
    string Password
    ):IRequest<Result<AppUserDto>>;


public class RegisterUserCommandHandler(IUserService userService) : IRequestHandler<RegisterUserCommand, Result<AppUserDto>>
{
    public async Task<Result<AppUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var result = await userService.RegisterUserAsync(request);
        return result;
    }
}




