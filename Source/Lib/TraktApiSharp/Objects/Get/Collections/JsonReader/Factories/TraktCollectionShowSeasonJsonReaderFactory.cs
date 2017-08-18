﻿namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCollectionShowSeasonJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShowSeason>
    {
        public ITraktObjectJsonReader<ITraktCollectionShowSeason> CreateObjectReader() => new TraktCollectionShowSeasonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCollectionShowSeason> CreateArrayReader() => new TraktCollectionShowSeasonArrayJsonReader();
    }
}