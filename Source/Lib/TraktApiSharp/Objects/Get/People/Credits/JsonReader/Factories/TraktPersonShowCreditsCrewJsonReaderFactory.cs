namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktPersonShowCreditsCrewJsonReaderFactory : ITraktJsonReaderFactory<ITraktPersonShowCreditsCrew>
    {
        public ITraktObjectJsonReader<ITraktPersonShowCreditsCrew> CreateObjectReader() => new TraktPersonShowCreditsCrewObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonShowCreditsCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonShowCreditsCrew)} is not supported.");
        }
    }
}
