namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CommentUserStatsJsonIOFactory : IJsonIOFactory<ITraktCommentUserStats>
    {
        public IObjectJsonReader<ITraktCommentUserStats> CreateObjectReader() => new CommentUserStatsObjectJsonReader();

        public IObjectJsonWriter<ITraktCommentUserStats> CreateObjectWriter() => new CommentUserStatsObjectJsonWriter();
    }
}
