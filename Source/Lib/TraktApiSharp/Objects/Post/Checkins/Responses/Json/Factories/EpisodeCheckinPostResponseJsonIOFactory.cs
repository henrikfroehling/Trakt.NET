namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Checkins.Responses.Json.Reader;
    using System;

    internal class EpisodeCheckinPostResponseJsonIOFactory : IJsonIOFactory<ITraktEpisodeCheckinPostResponse>
    {
        public IObjectJsonReader<ITraktEpisodeCheckinPostResponse> CreateObjectReader() => new EpisodeCheckinPostResponseObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeCheckinPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeCheckinPostResponse)} is not supported.");
        }

        public IObjectJsonWriter<ITraktEpisodeCheckinPostResponse> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktEpisodeCheckinPostResponse> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
