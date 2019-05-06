using System;
using System.Collections.Generic;
using System.Text;

namespace Action.Common.Commands
{
    public class AuthencateUser:ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
