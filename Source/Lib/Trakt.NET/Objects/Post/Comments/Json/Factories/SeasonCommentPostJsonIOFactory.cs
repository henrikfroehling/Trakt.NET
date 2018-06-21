namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class SeasonCommentPostJsonIOFactory : IJsonIOFactory<ITraktSeasonCommentPost>
    {
        public IObjectJsonReader<ITraktSeasonCommentPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktSeasonCommentPost)} is not supported.");

        public IArrayJsonReader<ITraktSeasonCommentPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktSeasonCommentPost)} is not supported.");

        public IObjectJsonWriter<ITraktSeasonCommentPost> CreateObjectWriter() => new SeasonCommentPostObjectJsonWriter();
    }
}
