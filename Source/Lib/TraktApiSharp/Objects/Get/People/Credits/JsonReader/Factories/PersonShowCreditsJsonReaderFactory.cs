namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class PersonShowCreditsJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCredits>
    {
        public IObjectJsonReader<ITraktPersonShowCredits> CreateObjectReader() => new TraktPersonShowCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCredits)} is not supported.");
        }
    }
}
