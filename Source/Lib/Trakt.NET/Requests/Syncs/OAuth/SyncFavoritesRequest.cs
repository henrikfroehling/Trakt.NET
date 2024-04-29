﻿namespace TraktNet.Requests.Syncs.OAuth
{
    using Enums;
    using Interfaces;
    using Objects.Get.Users;
    using Parameters;
    using System.Collections.Generic;

    internal class SyncFavoritesRequest : ASyncGetRequest<ITraktFavorite>, ISupportsExtendedInfo, ISupportsPagination
    {
        public override string UriTemplate => "sync/favorites{/type}{/sort}{?extended,page,limit}";

        public TraktFavoriteObjectType Type { get; set; }

        public TraktWatchlistSortOrder Sort { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktFavoriteObjectType.Unspecified)
            {
                uriParams.Add("type", Type.UriName);

                if (Sort != null && Sort != TraktWatchlistSortOrder.Unspecified)
                    uriParams.Add("sort", Sort.UriName);
            }

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
