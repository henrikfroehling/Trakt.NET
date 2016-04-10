namespace TraktApiSharp.Requests.Base.Get
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktGetByIdRequest<TResult, TItem> : TraktGetRequest<TResult, TItem>
    {
        protected TraktGetByIdRequest(TraktClient client) : base(client) { }

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
