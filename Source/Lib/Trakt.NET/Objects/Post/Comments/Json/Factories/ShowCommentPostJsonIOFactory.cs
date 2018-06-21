namespace TraktNet.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class ShowCommentPostJsonIOFactory : IJsonIOFactory<ITraktShowCommentPost>
    {
        public IObjectJsonReader<ITraktShowCommentPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktShowCommentPost)} is not supported.");

        public IArrayJsonReader<ITraktShowCommentPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktShowCommentPost)} is not supported.");

        public IObjectJsonWriter<ITraktShowCommentPost> CreateObjectWriter() => new ShowCommentPostObjectJsonWriter();
    }
}
