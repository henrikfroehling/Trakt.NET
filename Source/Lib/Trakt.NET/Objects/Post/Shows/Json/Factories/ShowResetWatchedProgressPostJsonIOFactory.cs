namespace TraktNet.Objects.Post.Shows.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class ShowResetWatchedProgressPostJsonIOFactory : IJsonIOFactory<ITraktShowResetWatchedProgressPost>
    {
        public IObjectJsonReader<ITraktShowResetWatchedProgressPost> CreateObjectReader() => new ShowResetWatchedProgressPostObjectJsonReader();

        public IObjectJsonWriter<ITraktShowResetWatchedProgressPost> CreateObjectWriter() => new ShowResetWatchedProgressPostObjectJsonWriter();
    }
}
