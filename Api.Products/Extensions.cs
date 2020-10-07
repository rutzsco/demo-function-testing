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
        public static Result<T> ToObject<T>(this HttpRequest req)
        {
            var requestBody = new StreamReader(req.Body).ReadToEnd();
            if (string.IsNullOrEmpty(requestBody))
                return Result.Failure<T>("Invalid request - No request body.");

            return Result.Success(JsonConvert.DeserializeObject<T>(requestBody));
        }
    }
}
