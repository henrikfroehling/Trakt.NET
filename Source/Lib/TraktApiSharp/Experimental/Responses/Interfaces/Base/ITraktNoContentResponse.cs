namespace TraktApiSharp.Experimental.Responses.Interfaces.Base
{
    using Exceptions;

    public interface ITraktNoContentResponse
    {
        bool IsSuccess { get; set; }

        TraktException Exception { get; set; }
    }
}
