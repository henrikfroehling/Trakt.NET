﻿namespace TraktNet.Requests.Lists
{
    internal sealed class ListsTrendingRequest : AListsRequest
    {
        public override string UriTemplate => "lists/trending{?extended,page,limit}";
    }
}
