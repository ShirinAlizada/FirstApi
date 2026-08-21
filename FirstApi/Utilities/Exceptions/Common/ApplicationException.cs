namespace FirstApi.Utilities.Exceptions
{
    public abstract class ApplicationException:Exception
    {
        public abstract string ErrorCode { get; } 
        public abstract int StatusCode { get; } 
        protected ApplicationException(string message) : base(message)
        {

        }
        protected ApplicationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
