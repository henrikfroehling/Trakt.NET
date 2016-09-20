namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using System;
    using System.Collections.Generic;

    internal abstract class ATraktDeleteByIdRequest : ATraktDeleteRequest
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
