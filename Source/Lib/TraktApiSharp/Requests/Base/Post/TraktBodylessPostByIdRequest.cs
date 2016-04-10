﻿namespace TraktApiSharp.Requests.Base.Post
{
    using System;
    using System.Collections.Generic;

    internal abstract class TraktBodylessPostByIdRequest<ResultType, ItemType> : TraktBodylessPostRequest<ResultType, ItemType>
    {
        protected TraktBodylessPostByIdRequest(TraktClient client) : base(client) { }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id } };
        }

        protected override void Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(Id))
                throw new ArgumentException("id not valid");
        }
    }
}
