using System.Net;
using MediatR;
using PhysiothreapyApp.Application.Wrappers;
using PhysiothreapyApp.Domain.Abstractions;
using PhysiothreapyApp.Domain.Interfaces;

namespace PhysiothreapyApp.Application.Behaviors;

//public class NotFoundPipelineBehavior<TRequest, TResponse>(IGenericRepository<Entity> repository)
//    : IPipelineBehavior<TRequest, TResponse>
//    where TRequest : IRequest<TResponse>
//{
//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        var idValue = request.GetType().GetProperty("Id")?.GetValue(request);
//        if (idValue is null)
//            return await next();

//        var guidIdValue = Guid.TryParse(idValue.ToString(), out var guidId);
//        if (!guidIdValue)
//            return await next();

//        var isExistEntity = await repository.AnyAsync(x => x.Id == guidId);
//        if (!isExistEntity)
//        {
//            var entityName = typeof(Entity).Name;
//            var result = Result<string>.Failure($"{entityName} Not Found", HttpStatusCode.NotFound);
//            throw new Exception($"{entityName} Not Found");
//        }

//        return await next();
//    }
//}


