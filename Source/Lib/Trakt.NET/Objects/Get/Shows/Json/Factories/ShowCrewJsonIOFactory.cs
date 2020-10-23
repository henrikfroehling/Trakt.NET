namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowCrewJsonIOFactory : IJsonIOFactory<ITraktShowCrew>
    {
        public IObjectJsonReader<ITraktShowCrew> CreateObjectReader() => new ShowCrewObjectJsonReader();

        public IObjectJsonWriter<ITraktShowCrew> CreateObjectWriter() => new ShowCrewObjectJsonWriter();
    }
}
