namespace TraktApiSharp.Objects.JsonReader.Get.Seasons
{
    using Newtonsoft.Json;
    using Objects.Get.Seasons.Implementations;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktSeasonWatchedProgressArrayJsonReader : ITraktArrayJsonReader<TraktSeasonWatchedProgress>
    {
        public IEnumerable<TraktSeasonWatchedProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktSeasonWatchedProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonWatchedProgressReader = new TraktSeasonWatchedProgressObjectJsonReader();
                var traktSeasonWatchedProgresses = new List<TraktSeasonWatchedProgress>();

                var traktSeasonWatchedProgress = seasonWatchedProgressReader.ReadObject(jsonReader);

                while (traktSeasonWatchedProgress != null)
                {
                    traktSeasonWatchedProgresses.Add(traktSeasonWatchedProgress);
                    traktSeasonWatchedProgress = seasonWatchedProgressReader.ReadObject(jsonReader);
                }

                return traktSeasonWatchedProgresses;
            }

            return null;
        }
    }
}
