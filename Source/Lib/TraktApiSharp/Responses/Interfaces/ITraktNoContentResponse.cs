namespace TraktNet.Responses.Interfaces
{
    using System;

    public interface ITraktNoContentResponse
    {
        bool IsSuccess { get; set; }

        Exception Exception { get; set; }
    }
}
