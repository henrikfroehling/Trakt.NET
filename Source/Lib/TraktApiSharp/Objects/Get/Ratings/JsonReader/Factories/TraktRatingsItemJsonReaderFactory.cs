namespace TraktApiSharp.Objects.Get.Ratings.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktRatingsItemJsonReaderFactory : ITraktJsonReaderFactory<ITraktRatingsItem>
    {
        public ITraktObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new TraktRatingsItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRatingsItem> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRatingsItem)} is not supported.");
        }
    }
}
