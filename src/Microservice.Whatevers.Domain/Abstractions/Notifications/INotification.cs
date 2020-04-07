using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.Abstractions.Notifications
{
    public interface INotification<in TNotification>
    {
        void AddError(string error);

        void AddError(TNotification notification);

        void AddError<TExternalNotification>(TExternalNotification externalNotification)
            where TExternalNotification : INotification<TExternalNotification>;

        void AddError<TExternalNotification>(string error, TExternalNotification externalNotification)
            where TExternalNotification : INotification<TExternalNotification>;

        void AddErrors(IEnumerable<TNotification> notifications);

        void AddErrors(IEnumerable<string> errors);

        string GetError();

        IEnumerable<string> GetErrors();

        bool IsValid();
    }
}