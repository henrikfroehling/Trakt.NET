namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    using Exceptions;

    public interface ITraktNoContentResponse
    {
        bool IsSuccess { get; set; }

        TraktException Exception { get; set; }
    }
}
