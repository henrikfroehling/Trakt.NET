namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes.Implementations;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeCollectionProgressArrayJsonReader : ITraktArrayJsonReader<TraktEpisodeCollectionProgress>
    {
        public IEnumerable<TraktEpisodeCollectionProgress> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktEpisodeCollectionProgress> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeCollectionProgressReader = new TraktEpisodeCollectionProgressObjectJsonReader();
                var traktEpisodeCollectionProgresses = new List<TraktEpisodeCollectionProgress>();

                var traktEpisodeCollectionProgress = episodeCollectionProgressReader.ReadObject(jsonReader);

                while (traktEpisodeCollectionProgress != null)
                {
                    traktEpisodeCollectionProgresses.Add(traktEpisodeCollectionProgress);
                    traktEpisodeCollectionProgress = episodeCollectionProgressReader.ReadObject(jsonReader);
                }

                return traktEpisodeCollectionProgresses;
            }

            return null;
        }
    }
}
