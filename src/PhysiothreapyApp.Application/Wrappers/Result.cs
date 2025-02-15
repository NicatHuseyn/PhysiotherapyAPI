using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhysiothreapyApp.Application.Wrappers;

public sealed class Result<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("errorMessages")]
    public List<string> ErrorMessages { get; set; } = new();

    [JsonPropertyName("isSuccessful")]
    public bool IsSuccessful { get; set; }

    [JsonPropertyName("statusCode")]
    public HttpStatusCode StatusCode { get; set; }

    [JsonConstructor]
    public Result()
    {
    }

    private Result(T data)
    {
        Data = data;
        IsSuccessful = true;
        StatusCode = HttpStatusCode.OK;
    }

    private Result(List<string> errorMessages, HttpStatusCode statusCode)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
    }

    private Result(string errorMessage, HttpStatusCode statusCode)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = [errorMessage];
    }

    public static implicit operator Result<T>(T data) => new(data);

    public static implicit operator Result<T>((List<string> errorMessages, HttpStatusCode statusCode) parameters)
        => new(parameters.errorMessages, parameters.statusCode);

    public static implicit operator Result<T>((string errorMessage, HttpStatusCode statusCode) parameters)
        => new(parameters.errorMessage, parameters.statusCode);

    public static Result<T> Succeed(T data) => new(data);

    public static Result<T> Failure(List<string> errorMessages, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(errorMessages, statusCode);

    public static Result<T> Failure(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(errorMessage, statusCode);

    public override string ToString() => JsonSerializer.Serialize(this);
}

