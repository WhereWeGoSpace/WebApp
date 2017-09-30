using System;

namespace WhereWeGoAPI.Exceptions
{
    public class TimeoutException : Exception
    {
        private const string _message = "time out";

        public TimeoutException()
            : base(_message)
        { }

        public TimeoutException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public string ErrorMessage => _message;

    }
}