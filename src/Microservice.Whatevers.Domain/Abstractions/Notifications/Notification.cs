using System.Collections.Generic;
using System.Linq;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public class Notification : INotification
    {
        private readonly List<string> _errors = new List<string>();

        public void AddError(string error) => _errors.Add(error);

        public void AddError(INotification notification) => AddErrors(notification?.GetErrors());

        public void AddError<TExternalNotification>(TExternalNotification externalNotification)
            where TExternalNotification : INotification =>
            AddErrors(externalNotification?.GetErrors());

        public void AddError<TExternalNotification>(string error, TExternalNotification externalNotification)
            where TExternalNotification : INotification
        {
            AddError(error);
            AddErrors(externalNotification?.GetErrors());
        }

        public void AddErrors(IEnumerable<INotification> notifications) =>
            AddErrors(notifications?.SelectMany(notification => notification?.GetErrors()));

        public void AddErrors(IEnumerable<string> errors)
        {
            if (errors is null) return;
            _errors.AddRange(errors);
        }

        public IEnumerable<string> GetErrors() => _errors;

        public string GetError() => string.Join(", ", _errors);
    }
}