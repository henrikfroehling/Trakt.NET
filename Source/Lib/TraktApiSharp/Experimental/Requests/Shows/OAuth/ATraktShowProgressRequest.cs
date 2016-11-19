namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Base.Get;
    using Interfaces;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal abstract class ATraktShowProgressRequest<TItem> : ATraktSingleItemGetByIdRequest<TItem>, ITraktObjectRequest
    {
        public ATraktShowProgressRequest(TraktClient client) : base(client) { }

        internal bool? Hidden { get; set; }

        internal bool? Specials { get; set; }

        internal bool? CountSpecials { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
