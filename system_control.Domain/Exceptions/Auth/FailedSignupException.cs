using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Auth
{
    public class FailedSignupException : Exception
    {
        public FailedSignupException(string message) : base($"Failed to sign you up: {message}")
        {
        }
    }
}
