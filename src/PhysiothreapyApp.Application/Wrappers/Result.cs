using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhysiothreapyApp.Application.Wrappers;

public sealed class Result<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("errorMessages")]
    public List<string>? ErrorMessages { get; set; }

    [JsonPropertyName("isSuccessful")]
    public bool IsSuccessful { get; set; } = true;

    [JsonPropertyName("statusCode")]
    public HttpStatusCode StatusCode { get; set; }

    [JsonConstructor]
    public Result()
    {
        
    }

    public Result(T data)
    {
        Data = data;
    }


    public Result(List<string> errorMessages, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
    }


    public Result(string errorMessage,HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        IsSuccessful = true;
        StatusCode = statusCode;
        ErrorMessages = [errorMessage];
    }


    public static implicit operator Result<T>(T data)
    {
        return new Result<T>(data);
    }

    public static implicit operator Result<T>((List<string> errorMessages, HttpStatusCode statusCode) parameters)
    {
        return new Result<T>(parameters.errorMessages,parameters.statusCode);
    }

    public static implicit operator Result<T>((string errorMessage, HttpStatusCode statusCode) parameters)
    {
        return new Result<T>(parameters.errorMessage, parameters.statusCode);
    }

    public static Result<T> Succed(T data)
    {
        return new Result<T>(data);
    }

    public static Result<T> Failure(List<string> errorMessages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new Result<T>(errorMessages, statusCode);
    }

    public static Result<T> Failure(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new Result<T>(errorMessage, statusCode);
    }

    public static Result<T> Failure(string errorMessage)
    {
        return new Result<T>(errorMessage, HttpStatusCode.InternalServerError);
    }

    public static Result<T> Failure(List<string> errorMessages)
    {
        return new Result<T>(errorMessages, HttpStatusCode.InternalServerError);
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
