
using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public ActivityCreated(Guid id, Guid GuidUserId)
        {
            Id = id;
            UserId = GuidUserId;
        }
        protected ActivityCreated()
        {

        }
    }
}
