namespace OnionArchitecture.Domain.CustomResult
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
