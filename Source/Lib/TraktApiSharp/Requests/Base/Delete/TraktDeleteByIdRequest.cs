namespace TraktApiSharp.Requests.Base.Delete
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktDeleteByIdRequest : TraktDeleteRequest
    {
        protected TraktDeleteByIdRequest(TraktClient client) : base(client) { }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id } };
        }

        protected override void Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(Id))
                throw new ArgumentException("id not valid");
        }
    }
}
