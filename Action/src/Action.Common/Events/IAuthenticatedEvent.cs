using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Events
{
    public interface IAuthenticatedEvent:IEvent
    {
        Guid UserId { get; set; }
    }
}
