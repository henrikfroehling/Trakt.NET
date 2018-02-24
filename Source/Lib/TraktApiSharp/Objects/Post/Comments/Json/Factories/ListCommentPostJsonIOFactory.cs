namespace TraktApiSharp.Objects.Post.Comments.Json.Factories
{
    using Objects.Json;
    using System;
    using Writer;

    internal class ListCommentPostJsonIOFactory : IJsonIOFactory<ITraktListCommentPost>
    {
        public IObjectJsonReader<ITraktListCommentPost> CreateObjectReader()
            => throw new NotSupportedException($"A object json reader for {nameof(ITraktListCommentPost)} is not supported.");

        public IArrayJsonReader<ITraktListCommentPost> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktListCommentPost)} is not supported.");

        public IObjectJsonWriter<ITraktListCommentPost> CreateObjectWriter() => new ListCommentPostObjectJsonWriter();
    }
}
