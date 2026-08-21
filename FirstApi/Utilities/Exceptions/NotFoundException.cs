namespace FirstApi.Utilities.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        private string Source { get; set; }
        public override string ErrorCode => $"{Source.ToUpperInvariant()}_NOT_FOUND";

        public override int StatusCode => 404;
        public NotFoundException(string source, object key)
            :base($"{source} with key {key} not found")
        {
            Source = source;
        }


    }
}
