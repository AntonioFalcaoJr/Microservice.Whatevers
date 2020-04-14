using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public interface INotification
    {
        void AddError(string error);

        void AddError(INotification notification);

        void AddError<TExternalNotification>(TExternalNotification externalNotification)
            where TExternalNotification : INotification;

        void AddError<TExternalNotification>(string error, TExternalNotification externalNotification)
            where TExternalNotification : INotification;

        void AddErrors(IEnumerable<INotification> notifications);

        void AddErrors(IEnumerable<string> errors);

        string GetError();

        IEnumerable<string> GetErrors();
    }
}