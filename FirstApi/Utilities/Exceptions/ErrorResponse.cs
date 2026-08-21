namespace FirstApi.Utilities.Exceptions
{
    public record ErrorResponse(string ErrorCode, int StatusCode, string Message)
    {
    }
}
