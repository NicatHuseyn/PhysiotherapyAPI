using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Commands;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.DTOs;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Queries;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.Application.Features.AuthFeatures.Register.Services;

public interface IUserService
{
    Task<Result<AppUserDto>> RegisterUserAsync(RegisterUserCommand command);

    Task<Result<GetUserQueryResponse>> GetUser(string? userNameOrEmail);
}
