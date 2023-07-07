namespace TraktNet.Requests.Lists
{
    using Objects.Get.Lists;
    using Parameters;
    using System.Collections.Generic;

    internal class SingleListRequest : AListRequest<ITraktList>
    {
        internal TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "lists/{id}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
