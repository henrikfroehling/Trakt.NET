namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    public class TraktEpisodeScrobblePost : TraktScrobblePost, IValidatable
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        public void Validate()
        {
            if (Episode == null)
                throw new ArgumentException("episode not set");

            if (Episode.Ids.HasAnyId)
                return;
            else
            {
                if (Show == null)
                    throw new ArgumentException("show not set");

                if (string.IsNullOrEmpty(Show.Title))
                    throw new ArgumentException("show title not set");

                if (Episode.SeasonNumber <= 0)
                    throw new ArgumentException("episode season number not set");

                if (Episode.Number <= 0)
                    throw new ArgumentException("episode number not set");

                throw new ArgumentException("episode ids not set");
            }
        }
    }
}
