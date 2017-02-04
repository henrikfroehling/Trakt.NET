namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    using System;

    public interface ITraktNoContentResponse : IEquatable<ITraktNoContentResponse>
    {
        bool IsSuccess { get; set; }

        Exception Exception { get; set; }
    }
}
