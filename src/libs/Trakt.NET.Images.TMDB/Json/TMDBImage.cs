using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TMDBImage
    {
        public string? FilePath { get; set; }

        public uint? Width { get; set; }

        public uint? Height { get; set; }

        public float? AspectRatio { get; set; }

        public uint? VoteCount { get; set; }

        public float? VoteAverage { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string? ISO6391 { get; set; }
    }
}
