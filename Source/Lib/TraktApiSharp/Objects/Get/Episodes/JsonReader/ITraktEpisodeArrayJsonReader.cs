namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;

    internal class ITraktEpisodeArrayJsonReader : ITraktArrayJsonReader<ITraktEpisode>
    {
        public IEnumerable<ITraktEpisode> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<ITraktEpisode> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeReader = new ITraktEpisodeObjectJsonReader();
                var traktEpisodes = new List<ITraktEpisode>();

                ITraktEpisode traktEpisode = episodeReader.ReadObject(jsonReader);

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
