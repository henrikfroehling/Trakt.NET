namespace TraktNet.Requests.Search
{
    using Enums;
    using Exceptions;
    using Extensions;
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
                throw new TraktRequestValidationException(nameof(IdType), "id type must not be null");

            if (IdType == TraktSearchIdType.Unspecified)
                throw new TraktRequestValidationException(nameof(IdType), "id type must not be unspecified");

            if (LookupId == null)
                throw new TraktRequestValidationException(nameof(LookupId), "lookup id must not be null");

            if (LookupId == string.Empty || LookupId.ContainsSpace())
                throw new TraktRequestValidationException(nameof(LookupId), "lookup id is not valid");
        }
    }
}
