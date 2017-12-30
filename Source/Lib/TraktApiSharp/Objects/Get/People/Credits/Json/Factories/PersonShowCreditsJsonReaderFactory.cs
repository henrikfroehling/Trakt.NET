namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonShowCreditsJsonReaderFactory : IJsonIOFactory<ITraktPersonShowCredits>
    {
        public IObjectJsonReader<ITraktPersonShowCredits> CreateObjectReader() => new PersonShowCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCredits)} is not supported.");
        }

        public IObjectJsonReader<ITraktPersonShowCredits> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktPersonShowCredits> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
