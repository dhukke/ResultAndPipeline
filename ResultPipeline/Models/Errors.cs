namespace ExceptionDriven.Models
{
    public static class Errors
    {
        public static readonly ErrorResponse FoodAlreadyExistErrorResponse = new ErrorResponse(
            errorCode: "FoodAlready", errorMessage: "Food already Exist"
        );
    }

    public class ErrorResponse
    {
        public ErrorResponse(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
