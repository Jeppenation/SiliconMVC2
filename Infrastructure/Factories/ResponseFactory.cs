using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories;

public class ResponseFactory
{
    public static ResponseResult Ok()
    {
        return new ResponseResult
        {
            Message = "Succeeded",
            StatusCode = StatusCodes.Ok
        };
    }

    public static ResponseResult Ok(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Succeeded",
            StatusCode = StatusCodes.Ok
        };
    }


    public static ResponseResult Ok(object? obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "Succeeded",
            StatusCode = StatusCodes.Ok
        };
    }

    public static ResponseResult Error(string? message)
    {
        return new ResponseResult
        {
            Message = "message",
            StatusCode = StatusCodes.InternalServerError
        };
    }

    public static ResponseResult NotFound()
    {
        return new ResponseResult
        {
            Message = "Not found",
            StatusCode = StatusCodes.NotFound
        };
    }

    public static ResponseResult Exists()
    {
        return new ResponseResult
        {
            Message = "Entity already exists",
            StatusCode = StatusCodes.BadRequest
        };
    }

}
