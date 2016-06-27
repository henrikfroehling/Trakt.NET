namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Newtonsoft.Json;
    using System;

    public abstract class TraktScrobblePost : IValidatable
    {
        [JsonProperty(PropertyName = "progress")]
        public float Progress { get; set; }

        [JsonProperty(PropertyName = "app_version")]
        public string AppVersion { get; set; }

        [JsonProperty(PropertyName = "app_date")]
        public string AppDate { get; set; }

        public void Validate()
        {
            if (Progress.CompareTo(0.0f) < 0)
                throw new ArgumentException("progress value not valid");

            if (Progress.CompareTo(100.0f) > 0)
                throw new ArgumentException("progress value not valid");
        }
    }
}
