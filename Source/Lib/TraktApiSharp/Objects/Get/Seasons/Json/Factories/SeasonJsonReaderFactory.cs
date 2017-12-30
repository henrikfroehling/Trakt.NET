namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;

    internal class SeasonJsonReaderFactory : IJsonIOFactory<ITraktSeason>
    {
        public IObjectJsonReader<ITraktSeason> CreateObjectReader() => new SeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSeason> CreateArrayReader() => new SeasonArrayJsonReader();

        public IObjectJsonReader<ITraktSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
