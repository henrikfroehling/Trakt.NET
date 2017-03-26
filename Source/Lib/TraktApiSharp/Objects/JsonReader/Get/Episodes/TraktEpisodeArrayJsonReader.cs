namespace TraktApiSharp.Objects.JsonReader.Get.Episodes
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes.Implementations;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeArrayJsonReader : ITraktArrayJsonReader<TraktEpisode>
    {
        public IEnumerable<TraktEpisode> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktEpisode> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeReader = new TraktEpisodeObjectJsonReader();
                var traktEpisodes = new List<TraktEpisode>();

                var traktEpisode = episodeReader.ReadObject(jsonReader);

                while (traktEpisode != null)
                {
                    traktEpisodes.Add(traktEpisode);
                    traktEpisode = episodeReader.ReadObject(jsonReader);
                }

                return traktEpisodes;
            }

            return null;
        }
    }
}
