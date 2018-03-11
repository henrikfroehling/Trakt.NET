namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Get.Seasons.Json.Writer;
    using Objects.Json;

    internal class SeasonJsonIOFactory : IJsonIOFactory<ITraktSeason>
    {
        public IObjectJsonReader<ITraktSeason> CreateObjectReader() => new SeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSeason> CreateArrayReader() => new SeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktSeason> CreateObjectWriter() => new SeasonObjectJsonWriter();
    }
}
