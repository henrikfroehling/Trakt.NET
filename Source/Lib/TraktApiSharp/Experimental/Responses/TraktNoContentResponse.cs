namespace TraktApiSharp.Experimental.Responses
{
    using Interfaces;
    using System;

    public class TraktNoContentResponse : ITraktNoContentResponse
    {
        public bool IsSuccess { get; set; }

        public Exception Exception { get; set; }

        public bool Equals(ITraktNoContentResponse other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception;
    }
}
