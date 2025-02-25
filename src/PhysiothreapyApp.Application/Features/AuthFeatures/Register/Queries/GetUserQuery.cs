using MediatR;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Services;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.Application.Features.AuthFeatures.Register.Queries;

public class GetUserQuery : IRequest<Result<GetUserQueryResponse>>
{
    public string? UserNameOrEmail { get; set; }
}


public record GetUserQueryResponse(string Id, string UserName, string FirstName, string LastName, string Email);



public sealed class GetUserQueryHandler(IUserService userService) : IRequestHandler<GetUserQuery, Result<GetUserQueryResponse>>
{
    public Task<Result<GetUserQueryResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = userService.GetUser(request.UserNameOrEmail);

        return result;
    }
}
