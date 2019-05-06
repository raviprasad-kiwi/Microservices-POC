using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Events
{
    public class CreateUserRejected : IRecjectedEvent
    {
        public string Reason { get; }

        public string Code { get; }
        public string Email { get; }
        protected CreateUserRejected()
        {

        }
        public CreateUserRejected(string email, string code, string reason)
        {
            Reason = reason;
            Email = email;
            Reason = reason;
        }
    }
}
