namespace TraktApiSharp.Experimental.Responses
{
    using Interfaces;
    using System;

    public class TraktNoContentResponse : ITraktNoContentResponse, IEquatable<TraktNoContentResponse>
    {
        public bool IsSuccess { get; set; }

        public Exception Exception { get; set; }

        public bool Equals(TraktNoContentResponse other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception;

        public static implicit operator bool(TraktNoContentResponse response) => response.IsSuccess;
    }
}
