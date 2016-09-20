namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktRequestId : ITraktId
    {
        public string Id { get; set; }

        public IDictionary<string, object> GetIdPathParameters() => new Dictionary<string, object> { ["id"] = Id };

        public void ValidateId()
        {
            if (string.IsNullOrEmpty(Id))
                throw new ArgumentException("id not set");
        }
    }
}
