

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Krispy.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

       
        public ApiResponse() { }

      
        public ApiResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
            Errors.Add(errorMessage);
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> ErrorResponse(string errorMessage)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = errorMessage,
                Data = default,
                Errors = new List<string> { errorMessage }
            };
        }

        public static ApiResponse<T> ErrorResponse(string errorMessage, List<string> errors)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = errorMessage,
                Data = default,
                Errors = errors ?? new List<string>()
            };
        }

    
        public static ApiResponse<T> ErrorResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return new ApiResponse<T>
            {
                Success = false,
                Message = "Error de validación",
                Data = default,
                Errors = errors
            };
        }

      
        public ApiResponse<T> AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public ApiResponse<T> AddMetadata(string key, object value)
        {
            Metadata.Add(key, value);
            return this;
        }

        
    }
}
