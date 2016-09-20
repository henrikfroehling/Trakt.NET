namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using System.Collections.Generic;

    internal interface ITraktByIdRequest : ITraktRequest
    {
        string Id { get; set; }

        IDictionary<string, object> GetIdPathParameters();

        void ValidateId();
    }
}
