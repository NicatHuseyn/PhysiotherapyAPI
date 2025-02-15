using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhysiothreapyApp.Application.Wrappers;
using PhysiothreapyApp.Domain.Abstractions;
using PhysiothreapyApp.Domain.Interfaces;

namespace PhysiothreapyApp.Application.Filters;

public class NotFoundFilter<T>(IGenericRepository<T> repository) :Attribute,IAsyncActionFilter
    where T : Entity
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Start Aciton Method
        var idValue = context.ActionArguments.TryGetValue("id",out var id)? id:null;

        if (idValue is null)
        {
            await next();
            return;
        }

        var guidIdValue = Guid.TryParse(idValue.ToString(), out var guidId);
        if (!guidIdValue)
        {
            await next();
            return;
        }

        var isExistEntity = await repository.AnyAsync(x=>x.Id == guidId);
        if (!isExistEntity)
        {
            var entityName = typeof(T).Name;
            var result = Result<string>.Failure($"{entityName} Not Found", System.Net.HttpStatusCode.NotFound);
            context.Result = new NotFoundObjectResult(result);
            return;
        }

        // End Action
        await next();
    }
}
