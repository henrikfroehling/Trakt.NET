namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using System.Collections.Generic;

    internal interface ITraktId
    {
        string Id { get; set; }

        IDictionary<string, object> GetIdPathParameters();

        void ValidateId();
    }
}
