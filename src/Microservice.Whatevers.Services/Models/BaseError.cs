using System.Collections.Generic;
using System.Linq;

namespace Microservice.Whatevers.Services
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

        public void AddError(BaseError baseError) => AddErrors(baseError?.GetErrors());

        public void AddErrors(IEnumerable<BaseError> baseErrors) => 
            AddErrors(baseErrors?.SelectMany(x => x.GetErrors()));

        public void AddErrors(IEnumerable<string> errors)
        {
            errors ??= new List<string>();
            _errors.AddRange(errors);
        }

        public IEnumerable<string> GetErrors() => _errors ?? new List<string>();

        public bool IsValid() => !(_errors is {Count: 0});
    }
}