namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users.Statistics;
    using System;

    internal sealed class TraktUserStatisticsRequest : ATraktUsersSingleItemGetRequest<TraktUserStatistics>
    {
        internal TraktUserStatisticsRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
