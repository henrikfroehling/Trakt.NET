namespace TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktEpisodeCheckinPostResponseJsonReaderFactory : ITraktJsonReaderFactory<ITraktEpisodeCheckinPostResponse>
    {
        public ITraktObjectJsonReader<ITraktEpisodeCheckinPostResponse> CreateObjectReader() => new TraktEpisodeCheckinPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktEpisodeCheckinPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeCheckinPostResponse)} is not supported.");
        }
    }
}
