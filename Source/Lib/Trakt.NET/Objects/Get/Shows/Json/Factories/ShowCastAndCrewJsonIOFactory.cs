namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowCastAndCrewJsonIOFactory : IJsonIOFactory<ITraktShowCastAndCrew>
    {
        public IObjectJsonReader<ITraktShowCastAndCrew> CreateObjectReader() => new ShowCastAndCrewObjectJsonReader();

        public IArrayJsonReader<ITraktShowCastAndCrew> CreateArrayReader() => new ShowCastAndCrewArrayJsonReader();

        public IObjectJsonWriter<ITraktShowCastAndCrew> CreateObjectWriter() => new ShowCastAndCrewObjectJsonWriter();
    }
}
