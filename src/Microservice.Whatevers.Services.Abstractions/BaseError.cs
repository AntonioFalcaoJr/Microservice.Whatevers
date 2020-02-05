using System.Collections.Generic;
using System.Linq;

namespace Microservice.Whatevers.Services.Abstractions
{
    public abstract class BaseError
    {
        private List<string> _errors;

        protected BaseError() => _errors = new List<string>();

        public void AddError(string erro)
        {
            _errors ??= new List<string>();
            _errors.Add(erro);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
             errors ??= new List<string>();
             errors.ToList().ForEach(AddError);
        }

        public void AddError(BaseError baseError) => AddErrors(baseError?.GetErrors());

        public void AddError(IEnumerable<BaseError> baseErrors) => baseErrors?.ToList().ForEach(AddError);

        public IEnumerable<string> GetErrors() => _errors;

        public bool IsValid() => !(_errors is {Count: 0});
    }
}