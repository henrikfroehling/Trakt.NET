namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Get.Shows;
    using Get.Shows.Episodes;
    using Newtonsoft.Json;
    using System;

    public class TraktEpisodeScrobblePost : TraktScrobblePost
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (Episode == null)
                throw new ArgumentException("episode not set");

            if (Episode.Ids == null)
            {
                if (Show == null)
                    throw new ArgumentException("show not set");

                if (string.IsNullOrEmpty(Show.Title))
                    throw new ArgumentException("show title not set");

                if (Episode.SeasonNumber < 0)
                    throw new ArgumentException("episode season number not set");

                if (Episode.Number <= 0)
                    throw new ArgumentException("episode number not set");
            }
            else
            {
                if (!Episode.Ids.HasAnyId)
                {
                    if (Show == null)
                        throw new ArgumentException("show not set");

                    if (string.IsNullOrEmpty(Show.Title))
                        throw new ArgumentException("show title not set");

                    if (Episode.SeasonNumber < 0)
                        throw new ArgumentException("episode season number not set");

                    if (Episode.Number <= 0)
                        throw new ArgumentException("episode number not set");
                }
            }
        }
    }
}
