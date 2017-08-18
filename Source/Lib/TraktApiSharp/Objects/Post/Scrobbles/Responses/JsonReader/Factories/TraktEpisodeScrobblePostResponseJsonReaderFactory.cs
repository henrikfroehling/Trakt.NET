namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktEpisodeScrobblePostResponseJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeScrobblePostResponse>
    {
        public ITraktObjectJsonReader<ITraktEpisodeScrobblePostResponse> CreateObjectReader() => new TraktEpisodeScrobblePostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeScrobblePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeScrobblePostResponse)} is not supported.");
        }
    }
}
