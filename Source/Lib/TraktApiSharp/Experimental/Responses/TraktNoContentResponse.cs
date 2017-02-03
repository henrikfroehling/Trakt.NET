namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;
    using Interfaces.Base;
    using System;

    public class TraktNoContentResponse : ITraktNoContentResponse, IEquatable<TraktNoContentResponse>
    {
        public bool IsSuccess { get; set; }

        public TraktException Exception { get; set; }

        public bool Equals(TraktNoContentResponse other)
            => other != null && IsSuccess == other.IsSuccess && Exception == other.Exception;
    }
}
