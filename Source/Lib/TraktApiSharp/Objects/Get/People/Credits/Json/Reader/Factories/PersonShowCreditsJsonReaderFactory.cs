namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories.Reader
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonShowCreditsJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCredits>
    {
        public IObjectJsonReader<ITraktPersonShowCredits> CreateObjectReader() => new PersonShowCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCredits)} is not supported.");
        }
    }
}
