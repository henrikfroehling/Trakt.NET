namespace TraktApiSharp.Requests.Base.Post
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktBodylessPostByIdRequest<TResult, TItem> : TraktBodylessPostRequest<TResult, TItem>
    {
        protected TraktBodylessPostByIdRequest(TraktClient client) : base(client) { }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("id", Id);
            return uriParams;
        }

        protected override void Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(Id))
                throw new ArgumentException("id not valid");
        }
    }
}
