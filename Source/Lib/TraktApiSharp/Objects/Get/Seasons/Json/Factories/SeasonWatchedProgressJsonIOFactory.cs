namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;

    internal class SeasonWatchedProgressJsonIOFactory : IJsonIOFactory<ITraktSeasonWatchedProgress>
    {
        public IObjectJsonReader<ITraktSeasonWatchedProgress> CreateObjectReader() => new SeasonWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonWatchedProgress> CreateArrayReader() => new SeasonWatchedProgressArrayJsonReader();

        public IObjectJsonWriter<ITraktSeasonWatchedProgress> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSeasonWatchedProgress> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
