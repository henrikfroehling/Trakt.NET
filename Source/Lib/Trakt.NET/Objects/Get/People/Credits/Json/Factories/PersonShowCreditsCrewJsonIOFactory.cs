namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonShowCreditsCrewJsonIOFactory : IJsonIOFactory<ITraktPersonShowCreditsCrew>
    {
        public IObjectJsonReader<ITraktPersonShowCreditsCrew> CreateObjectReader() => new PersonShowCreditsCrewObjectJsonReader();

        public IObjectJsonWriter<ITraktPersonShowCreditsCrew> CreateObjectWriter() => new PersonShowCreditsCrewObjectJsonWriter();
    }
}
