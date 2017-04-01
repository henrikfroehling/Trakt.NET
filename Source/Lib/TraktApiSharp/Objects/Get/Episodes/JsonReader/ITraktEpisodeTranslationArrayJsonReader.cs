namespace TraktApiSharp.Objects.Get.Episodes.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;

    internal class ITraktEpisodeTranslationArrayJsonReader : ITraktArrayJsonReader<ITraktEpisodeTranslation>
    {
        public IEnumerable<ITraktEpisodeTranslation> ReadArray(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArray(jsonReader);
            }
        }

        public IEnumerable<ITraktEpisodeTranslation> ReadArray(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeTranslationReader = new ITraktEpisodeTranslationObjectJsonReader();
                var traktEpisodeTranslations = new List<ITraktEpisodeTranslation>();

                ITraktEpisodeTranslation traktEpisodeTranslation = episodeTranslationReader.ReadObject(jsonReader);

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
