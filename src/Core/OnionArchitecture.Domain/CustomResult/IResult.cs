using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Domain.CustomResult
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
