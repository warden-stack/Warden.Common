using System;

namespace Warden.Common.Events
{
public interface IEvent
{
    Guid RequestId { get; }
}
}