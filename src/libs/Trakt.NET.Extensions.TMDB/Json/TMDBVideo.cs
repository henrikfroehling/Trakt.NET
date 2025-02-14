using System.Text.Json.Serialization;

namespace TraktNET
{
    public record class TMDBVideo
    {
        public string? Name { get; set; }

        public string? Site { get; set; }

        public string? Id { get; set; }

        public string? Key { get; set; }

        public bool? Official { get; set; }

        public TMDBVideoType? Type { get; set; }

        public uint? Size { get; set; }

        public DateTime? PublishedAt { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string? ISO6391 { get; set; }

        [JsonPropertyName("iso_3166_1")]
        public string? ISO31661 { get; set; }
    }
}
