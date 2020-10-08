using CSharpFunctionalExtensions;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Products.Logic
{
    public class WorkflowRunner
    {
        public static Task<IActionResult> Execute<T>(Func<Result<T>> requestMappingStep, Func<T,Result> logicStep)
        {
            var mappingResult = requestMappingStep();
            if (!mappingResult.IsSuccess)
                return Task.FromResult<IActionResult>(new BadRequestObjectResult(mappingResult.Error));

            var logicResult = logicStep(mappingResult.Value);
            return Task.FromResult(logicResult.ToActionResult());
        }
    }
}
