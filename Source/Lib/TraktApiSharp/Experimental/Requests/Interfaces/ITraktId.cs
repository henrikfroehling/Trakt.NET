namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using System.Collections.Generic;

    internal interface ITraktId : ITraktValidatable
    {
        string Id { get; set; }

        IDictionary<string, object> GetIdPathParameters();
    }
}
