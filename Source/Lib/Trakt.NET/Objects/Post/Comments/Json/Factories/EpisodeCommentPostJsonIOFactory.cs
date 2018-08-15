namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class EpisodeCommentPostJsonIOFactory : IJsonIOFactory<ITraktEpisodeCommentPost>
    {
        public IObjectJsonReader<ITraktEpisodeCommentPost> CreateObjectReader() => new EpisodeCommentPostObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeCommentPost> CreateArrayReader() => new EpisodeCommentPostArrayJsonReader();

        public IObjectJsonWriter<ITraktEpisodeCommentPost> CreateObjectWriter() => new EpisodeCommentPostObjectJsonWriter();
    }
}
