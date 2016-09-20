namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System;
    using System.Collections.Generic;

    internal abstract class ATraktGetByIdRequest<TItem> : ATraktGetRequest<TItem>
    {
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
