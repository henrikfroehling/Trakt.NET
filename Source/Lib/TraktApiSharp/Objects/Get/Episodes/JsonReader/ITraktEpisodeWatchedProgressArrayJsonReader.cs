namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;

    internal class ITraktEpisodeWatchedProgressArrayJsonReader : ITraktArrayJsonReader<ITraktEpisodeWatchedProgress>
    {
        public IEnumerable<ITraktEpisodeWatchedProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<ITraktEpisodeWatchedProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeWatchedProgressReader = new ITraktEpisodeWatchedProgressObjectJsonReader();
                var traktEpisodeWatchedProgresses = new List<ITraktEpisodeWatchedProgress>();

                ITraktEpisodeWatchedProgress traktEpisodeWatchedProgress = episodeWatchedProgressReader.ReadObject(jsonReader);

                while (traktEpisodeWatchedProgress != null)
                {
                    traktEpisodeWatchedProgresses.Add(traktEpisodeWatchedProgress);
                    traktEpisodeWatchedProgress = episodeWatchedProgressReader.ReadObject(jsonReader);
                }

                return traktEpisodeWatchedProgresses;
            }

            return null;
        }
    }
}
