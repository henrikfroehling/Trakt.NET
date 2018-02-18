namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;
    using System;

    internal class PersonShowCreditsJsonIOFactory : IJsonIOFactory<ITraktPersonShowCredits>
    {
        public IObjectJsonReader<ITraktPersonShowCredits> CreateObjectReader() => new PersonShowCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCredits> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCredits)} is not supported.");

        public IObjectJsonWriter<ITraktPersonShowCredits> CreateObjectWriter() => new PersonShowCreditsObjectJsonWriter();
    }
}
