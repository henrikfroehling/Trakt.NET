namespace TraktApiSharp.Requests.Interfaces.Base
{
    using System.Collections.Generic;

    internal interface IHasUriPathParameters
    {
        IDictionary<string, object> GetUriPathParameters();
    }
}
