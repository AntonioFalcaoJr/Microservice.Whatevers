using System.Collections.Generic;
using System.Linq;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public abstract class Notification<TNotification> : INotification<TNotification>
        where TNotification : INotification<TNotification>
    {
        private readonly List<string> _errors = new List<string>();

        public void AddError(string error) => _errors.Add(error);

        public void AddError(TNotification notification) => AddErrors(notification?.GetErrors());

        public void AddError<TExternalNotification>(TExternalNotification externalNotification)
            where TExternalNotification : INotification<TExternalNotification> =>
            AddErrors(externalNotification?.GetErrors());

        public void AddError<TExternalNotification>(string error, TExternalNotification externalNotification)
            where TExternalNotification : INotification<TExternalNotification>
        {
            AddError(error);
            AddErrors(externalNotification?.GetErrors());
        }

        public void AddErrors(IEnumerable<TNotification> notifications) =>
            AddErrors(notifications?.SelectMany(notification => notification?.GetErrors()));

        public void AddErrors(IEnumerable<string> errors)
        {
            if (errors is null) return;
            _errors.AddRange(errors);
        }

        public IEnumerable<string> GetErrors() => _errors;

        public string GetError() => string.Join(", ", _errors);

        public bool IsValid() => _errors?.Any() == false;
    }
}