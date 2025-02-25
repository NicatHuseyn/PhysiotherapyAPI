using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Commands;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.DTOs;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Queries;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Services;
using PhysiothreapyApp.Application.Wrappers;
using PhysiothreapyApp.Domain.Models.IdentityModels;

namespace PhysiothreapyApp.Infrastructure.Services.AuthServices;

public class UserService(UserManager<AppUser> userManager) : IUserService
{
    public async Task<Result<AppUserDto>> RegisterUserAsync(RegisterUserCommand command)
    {

        var existUser = await userManager.FindByNameAsync(command.UserName);

        if (existUser != null)
            return Result<AppUserDto>.Failure("User Not Found", System.Net.HttpStatusCode.NotFound);


        var user = new AppUser()
        {
            UserName = command.UserName,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
        };

        IdentityResult result = await userManager.CreateAsync(user);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e=>e.Description).ToList();
            return Result<AppUserDto>.Failure(errors);
        }

        var userDto = user.Adapt<AppUserDto>();

        return Result<AppUserDto>.Succeed(userDto);

    }

    public async Task<Result<GetUserQueryResponse>> GetUser(string? userNameOrEmail)
    {
        var users = await userManager.Users.ToListAsync();

        var user = await userManager.FindByNameAsync(userNameOrEmail!)?? await userManager.FindByEmailAsync(userNameOrEmail!);

        if (!users.Contains(user!))
        {
            return Result<GetUserQueryResponse>.Failure("User Not Foud", System.Net.HttpStatusCode.NotFound);
        }

        var appUserAsModel = user.Adapt<GetUserQueryResponse>();

        return Result<GetUserQueryResponse>.Succeed(appUserAsModel);
    }

}
