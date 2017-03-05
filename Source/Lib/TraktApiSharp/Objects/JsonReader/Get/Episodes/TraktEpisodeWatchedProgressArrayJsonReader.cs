namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeWatchedProgressArrayJsonReader : ITraktArrayJsonReader<TraktEpisodeWatchedProgress>
    {
        public IEnumerable<TraktEpisodeWatchedProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktEpisodeWatchedProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeWatchedProgressReader = new TraktEpisodeWatchedProgressObjectJsonReader();
                var traktEpisodeWatchedProgresses = new List<TraktEpisodeWatchedProgress>();

                var traktEpisodeWatchedProgress = episodeWatchedProgressReader.ReadObject(jsonReader);

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
