namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktPersonShowCreditsJsonReaderFactory : ITraktJsonReaderFactory<ITraktPersonShowCredits>
    {
        public ITraktObjectJsonReader<ITraktPersonShowCredits> CreateObjectReader() => new TraktPersonShowCreditsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonShowCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCredits)} is not supported.");
        }
    }
}
