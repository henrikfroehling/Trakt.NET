namespace TraktApiSharp.Requests.Search
{
    using Enums;
    using Extensions;
    using System;
    using System.Collections.Generic;

    internal sealed class SearchIdLookupRequest : ASearchRequest
    {
        internal TraktSearchIdType IdType { get; set; }

        internal string LookupId { get; set; }

        public override string UriTemplate => "search/{id_type}/{id}{?type,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("id_type", IdType.UriName);
            uriParams.Add("id", LookupId);

            if (ResultTypes != null && ResultTypes != TraktSearchResultType.Unspecified)
                uriParams.Add("type", ResultTypes.UriName);

            return uriParams;
        }

        public override void Validate()
        {
            if (IdType == null)
                throw new ArgumentNullException(nameof(IdType));

            if (IdType == TraktSearchIdType.Unspecified)
                throw new ArgumentException("id type must not be unspecified", nameof(IdType));

            if (LookupId == null)
                throw new ArgumentNullException(nameof(LookupId));

            if (LookupId == string.Empty || LookupId.ContainsSpace())
                throw new ArgumentException("lookup id is not valid", nameof(LookupId));
        }
    }
}
