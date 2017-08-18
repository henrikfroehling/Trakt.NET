﻿namespace TraktApiSharp.Objects.Post.Users.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserFollowUserPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktUserFollowUserPostResponse>
    {
        public ITraktObjectJsonReader<ITraktUserFollowUserPostResponse> CreateObjectReader() => new TraktUserFollowUserPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserFollowUserPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFollowUserPostResponse)} is not supported.");
        }
    }
}