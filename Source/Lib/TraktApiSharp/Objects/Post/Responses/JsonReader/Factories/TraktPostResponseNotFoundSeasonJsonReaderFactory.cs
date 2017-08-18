﻿namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPostResponseNotFoundSeasonJsonReaderFactory : IJsonReaderFactory<ITraktPostResponseNotFoundSeason>
    {
        public IObjectJsonReader<ITraktPostResponseNotFoundSeason> CreateObjectReader() => new TraktPostResponseNotFoundSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktPostResponseNotFoundSeason> CreateArrayReader() => new TraktPostResponseNotFoundSeasonArrayJsonReader();
    }
}
