namespace FirstApi.Utilities.Exceptions
{
    public class CategoryAlreadyExistException: ApplicationException
    {
        public override string ErrorCode { get => "CATEGORY_ALREADY_EXIST";}
        public override int StatusCode { get => 409;}
        public CategoryAlreadyExistException(string name) : base($"Category with name {name} already exists")
        {

        }


    }
}
