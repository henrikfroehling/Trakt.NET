namespace TraktApiSharp.Requests.Lists
{
    using Base;
    using Interfaces;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal abstract class AListsRequest : AGetRequest<ITraktList>, ISupportsPagination
    {
        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate()
        {
        }
    }
}
