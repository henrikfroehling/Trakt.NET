namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class PersonShowCreditsCrewJsonReaderFactory : IJsonReaderFactory<ITraktPersonShowCreditsCrew>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCrew> CreateObjectReader() => new PersonShowCreditsCrewObjectJsonReader();

        public IArrayJsonReader<ITraktPersonShowCreditsCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCreditsCrew)} is not supported.");
        }
    }
}
