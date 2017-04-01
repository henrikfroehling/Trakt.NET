namespace TraktApiSharp.Objects.Get.Seasons.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;

    internal class ITraktSeasonWatchedProgressArrayJsonReader : ITraktArrayJsonReader<ITraktSeasonWatchedProgress>
    {
        public IEnumerable<ITraktSeasonWatchedProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<ITraktSeasonWatchedProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonWatchedProgressReader = new ITraktSeasonWatchedProgressObjectJsonReader();
                var traktSeasonWatchedProgresses = new List<ITraktSeasonWatchedProgress>();

                ITraktSeasonWatchedProgress traktSeasonWatchedProgress = seasonWatchedProgressReader.ReadObject(jsonReader);

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
