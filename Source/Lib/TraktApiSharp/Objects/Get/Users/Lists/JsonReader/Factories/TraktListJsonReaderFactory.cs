﻿namespace TraktApiSharp.Objects.Get.Users.Lists.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktListJsonReaderFactory : IJsonReaderFactory<ITraktList>
    {
        public ITraktObjectJsonReader<ITraktList> CreateObjectReader() => new TraktListObjectJsonReader();

        public ITraktArrayJsonReader<ITraktList> CreateArrayReader() => new TraktListArrayJsonReader();
    }
}