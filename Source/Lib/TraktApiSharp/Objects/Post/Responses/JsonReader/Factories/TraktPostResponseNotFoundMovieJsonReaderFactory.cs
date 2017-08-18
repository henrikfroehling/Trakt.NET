﻿namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPostResponseNotFoundMovieJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundMovie>
    {
        public ITraktObjectJsonReader<ITraktPostResponseNotFoundMovie> CreateObjectReader() => new TraktPostResponseNotFoundMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPostResponseNotFoundMovie> CreateArrayReader() => new TraktPostResponseNotFoundMovieArrayJsonReader();
    }
}