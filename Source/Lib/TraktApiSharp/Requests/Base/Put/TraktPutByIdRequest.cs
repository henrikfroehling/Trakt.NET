namespace TraktApiSharp.Requests.Base.Put
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktPutByIdRequest<TResult, TItem> : TraktPutRequest<TResult, TItem>
    {
        protected TraktPutByIdRequest(TraktClient client) : base(client) { }

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
