using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Application.Utils
{
    public class Result<T>
    {
        public T? Value { get; set; }

        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public ProblemDetails? ProblemDetails { get; set; }

        public bool IsSuccess => ProblemDetails is null;

        public Result(T? value = default, int statusCode = StatusCodes.Status200OK)
        {
            Value = value;
            StatusCode = statusCode;
        }

        public Result(ProblemDetails problemDetails)
        {
            ProblemDetails = problemDetails;
        }

        public static Result<T> Success(T? value)
        {
            return new Result<T>
            {
                Value = value,
            };
        }


        public static Result<T> Success(T? value, int statusCode)
        {
            return new Result<T>
            {
                Value = value,
                StatusCode = statusCode
            };
        }


        public static Result<T> Success(T? value, string message)
        {
            return new Result<T>
            {
                Value = value,
                Message = message
            };
        }

        public static Result<T> Success(T? Value, int statusCode, string message)
        {
            return new Result<T>
            {
                Value = Value,
                StatusCode = statusCode,
                Message = message
            };
        }


        //problem-details

        public static Result<T> Failure(string title, int status)
        {
            var problem = new ProblemDetails
            {
                Title = title,
                Status = status,
                Instance = "",
                Detail = "",
                Type = ""
            };
            return new Result<T>(problem);
        }

        public static Result<T> Failure(ProblemDetails problemDetails)
        {
            var problem = new ProblemDetails
            {
                Title = problemDetails.Title,
                Status = problemDetails.Status,
                Instance = problemDetails.Instance,
                Detail = problemDetails.Detail,
                Type = problemDetails.Type
            };
            return new Result<T>(problem);
        }
    }
}
