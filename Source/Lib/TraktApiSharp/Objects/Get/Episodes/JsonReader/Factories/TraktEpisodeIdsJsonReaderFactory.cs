﻿namespace TraktApiSharp.Objects.Get.Episodes.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktEpisodeIdsJsonReaderFactory : IJsonReaderFactory<ITraktEpisodeIds>
    {
        public IObjectJsonReader<ITraktEpisodeIds> CreateObjectReader() => new TraktEpisodeIdsObjectJsonReader();

        public IArrayJsonReader<ITraktEpisodeIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktEpisodeIds)} is not supported.");
        }
    }
}
