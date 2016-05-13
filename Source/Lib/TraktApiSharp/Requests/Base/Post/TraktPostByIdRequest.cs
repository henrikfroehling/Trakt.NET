namespace TraktApiSharp.Requests.Base.Post
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktPostByIdRequest<TResult, TItem, TRequestBody> : TraktPostRequest<TResult, TItem, TRequestBody>
    {
        protected TraktPostByIdRequest(TraktClient client) : base(client) { }

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
