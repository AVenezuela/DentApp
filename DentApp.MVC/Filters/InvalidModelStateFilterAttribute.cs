using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class InvalidModelStateFilterAttribute : ActionFilterAttribute {

    public override void OnActionExecuting(ActionExecutingContext actionContext) {
        if (!actionContext.ModelState.IsValid) {            
            actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
        }
    }
}