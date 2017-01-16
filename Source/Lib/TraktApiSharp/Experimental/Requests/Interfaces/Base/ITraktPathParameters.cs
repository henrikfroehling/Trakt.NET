namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using System.Collections.Generic;

    internal interface ITraktPathParameters
    {
        IDictionary<string, object> GetUriPathParameters();
    }
}
