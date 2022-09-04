namespace TraktNet.Requests.Lists
{
    using Base;
    using Interfaces;
    using Objects.Get.Lists;
    using System.Collections.Generic;

    internal abstract class AListsRequest : AGetRequest<ITraktList>, ISupportsPagination
    {
        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
        }
    }
}
