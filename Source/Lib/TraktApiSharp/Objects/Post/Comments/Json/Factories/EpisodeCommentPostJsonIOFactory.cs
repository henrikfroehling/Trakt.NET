namespace TraktApiSharp.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class EpisodeCommentPostJsonIOFactory : IJsonIOFactory<ITraktEpisodeCommentPost>
    {
        public IObjectJsonReader<ITraktEpisodeCommentPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktEpisodeCommentPost)} is not supported.");

        public IArrayJsonReader<ITraktEpisodeCommentPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeCommentPost)} is not supported.");

        public IObjectJsonWriter<ITraktEpisodeCommentPost> CreateObjectWriter() => new EpisodeCommentPostObjectJsonWriter();
    }
}
