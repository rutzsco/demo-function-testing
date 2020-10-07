using CSharpFunctionalExtensions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Http;

namespace Api.Products
{
    public static class Extensions
    {
        public static Result<T> ToObject<T>(this Stream req)
        {
            var requestBody = new StreamReader(req).ReadToEnd();
            if (string.IsNullOrEmpty(requestBody))
                return Result.Failure<T>("Invalid request - No request body.");

            return Result.Success(JsonConvert.DeserializeObject<T>(requestBody));
        }

        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return new OkObjectResult(result.Value);

            return new BadRequestObjectResult(result.Error);
        }

        public static IActionResult ToActionResult(this Result result)
        {
            if (result.IsSuccess)
                return new OkResult();

            return new BadRequestObjectResult(result.Error);
        }
    }
}
