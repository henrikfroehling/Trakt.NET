namespace TraktNet.Requests.People
{
    using Base;
    using Enums;
    using Extensions;
    using Interfaces;
    using Objects.Get.Users.Lists;
    using System;
    using System.Collections.Generic;

    internal sealed class PersonListsRequest : AGetRequest<ITraktList>, IHasId, ISupportsPagination
    {
        public string Id { get; set; }

        internal TraktListType Type { get; set; }

        internal TraktListSortOrder SortOrder { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.People;

        public override string UriTemplate => "people/{id}/lists{/type}{/sort_order}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                { "id", Id }
            };

            var isTypeSetAndValid = Type != null && Type != TraktListType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (isTypeSetAndValid && SortOrder != null && SortOrder != TraktListSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("person id not valid", nameof(Id));
        }
    }
}
