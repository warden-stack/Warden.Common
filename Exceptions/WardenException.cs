using System;

namespace Warden.Common.Exceptions
{
    public abstract class WardenException : Exception
    {
        public string Code { get; }

        protected WardenException()
        {
        }

        protected WardenException(string code)
        {
            Code = code;
        }

        protected WardenException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected WardenException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected WardenException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected WardenException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}