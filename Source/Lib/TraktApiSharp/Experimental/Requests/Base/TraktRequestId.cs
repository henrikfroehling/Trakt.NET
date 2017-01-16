namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktRequestId : ITraktId
    {
        public string Id { get; set; }

        public IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public void Validate()
        {
            if (string.IsNullOrEmpty(Id))
                throw new ArgumentException("id not set");
        }
    }
}
