namespace TraktApiSharp.Objects.JsonReader.Get.Seasons
{
    using Newtonsoft.Json;
    using Objects.Get.Seasons;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktSeasonCollectionProgressArrayJsonReader : ITraktArrayJsonReader<TraktSeasonCollectionProgress>
    {
        public IEnumerable<TraktSeasonCollectionProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktSeasonCollectionProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonCollectionProgressReader = new TraktSeasonCollectionProgressObjectJsonReader();
                var traktSeasonCollectionProgresses = new List<TraktSeasonCollectionProgress>();

                var traktSeasonCollectionProgress = seasonCollectionProgressReader.ReadObject(jsonReader);

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
