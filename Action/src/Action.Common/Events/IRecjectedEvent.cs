using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Events
{
    public interface IRecjectedEvent:IEvent
    {
         string Reason { get; }
         string Code { get; }
    }
}
