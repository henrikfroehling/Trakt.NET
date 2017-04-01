namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;

    internal class ITraktSeasonCollectionProgressArrayJsonReader : ITraktArrayJsonReader<ITraktSeasonCollectionProgress>
    {
        public IEnumerable<ITraktSeasonCollectionProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<ITraktSeasonCollectionProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonCollectionProgressReader = new ITraktSeasonCollectionProgressObjectJsonReader();
                var traktSeasonCollectionProgresses = new List<ITraktSeasonCollectionProgress>();

                ITraktSeasonCollectionProgress traktSeasonCollectionProgress = seasonCollectionProgressReader.ReadObject(jsonReader);

                while (traktSeasonCollectionProgress != null)
                {
                    traktSeasonCollectionProgresses.Add(traktSeasonCollectionProgress);
                    traktSeasonCollectionProgress = seasonCollectionProgressReader.ReadObject(jsonReader);
                }

                return traktSeasonCollectionProgresses;
            }

            return null;
        }
    }
}
