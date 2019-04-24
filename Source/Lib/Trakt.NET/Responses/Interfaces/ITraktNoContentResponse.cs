namespace TraktNet.Responses.Interfaces
{
    using Core;
    using System;

    /// <summary>A Trakt response with no content.</summary>
    public interface ITraktNoContentResponse
    {
        /// <summary>Gets, whether the request for this response was successful.</summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// If <see cref="IsSuccess" /> is false and if <see cref="TraktConfiguration.ThrowResponseExceptions" /> is set to false,
        /// this contains the thrown exception.
        /// </summary>
        Exception Exception { get; set; }
    }
}
