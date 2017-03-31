namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Newtonsoft.Json;
    using Objects.Get.Episodes.Implementations;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktEpisodeTranslationArrayJsonReader : ITraktArrayJsonReader<TraktEpisodeTranslation>
    {
        public IEnumerable<TraktEpisodeTranslation> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<TraktEpisodeTranslation> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeTranslationReader = new TraktEpisodeTranslationObjectJsonReader();
                var traktEpisodeTranslations = new List<TraktEpisodeTranslation>();

                var traktEpisodeTranslation = episodeTranslationReader.ReadObject(jsonReader);

                while (traktEpisodeTranslation != null)
                {
                    traktEpisodeTranslations.Add(traktEpisodeTranslation);
                    traktEpisodeTranslation = episodeTranslationReader.ReadObject(jsonReader);
                }

                return traktEpisodeTranslations;
            }

            return null;
        }
    }
}
