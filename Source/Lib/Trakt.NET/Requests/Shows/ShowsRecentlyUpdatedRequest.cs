namespace TraktNet.Requests.Shows
{
    using Base;
    using Extensions;
    using Interfaces;
    using Objects.Get.Shows;
    using Parameters;
    using System;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class ShowsRecentlyUpdatedRequest : AGetRequest<ITraktRecentlyUpdatedShow>, ISupportsExtendedInfo, ISupportsPagination
    {
        internal DateTime? StartDate { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "shows/updates{/start_date}{?extended,page,limit}";

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.NotRequired;

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate() { }
    }
}
