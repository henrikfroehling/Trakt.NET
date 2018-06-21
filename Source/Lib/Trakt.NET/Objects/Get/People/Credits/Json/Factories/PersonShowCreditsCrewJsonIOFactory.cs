namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;
    using System;

    internal class PersonShowCreditsCrewJsonIOFactory : IJsonIOFactory<ITraktPersonShowCreditsCrew>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCrew> CreateObjectReader() => new PersonShowCreditsCrewObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCrew> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCreditsCrew)} is not supported.");

        public IObjectJsonWriter<ITraktPersonShowCreditsCrew> CreateObjectWriter() => new PersonShowCreditsCrewObjectJsonWriter();
    }
}
