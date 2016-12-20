namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using System.Collections.Generic;

    internal interface ITraktPathParameters
    {
        IDictionary<string, object> GetUriPathParameters();
    }
}
