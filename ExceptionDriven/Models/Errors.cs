namespace ExceptionDriven.Models
{
    public static class Errors
    {
        public static readonly Error FoodAlreadyExistError = new Error(
            errorCode: "FoodAlready", errorMessage: "Food already Exist"
        );
    }

    public class Error
    {
        public Error(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
