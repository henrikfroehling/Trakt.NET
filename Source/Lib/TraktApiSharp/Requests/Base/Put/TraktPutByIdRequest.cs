namespace TraktApiSharp.Requests.Base.Put
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktPutByIdRequest<TResult, TItem, TRequestBody> : TraktPutRequest<TResult, TItem, TRequestBody>
    {
        protected TraktPutByIdRequest(TraktClient client) : base(client) { }

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
