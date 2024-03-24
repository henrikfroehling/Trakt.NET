using System.Text.Json.Serialization;

namespace TraktNET
{
    public class TraktUserIds : ITraktIds
    {
        public string? Slug { get; set; }

        [JsonPropertyName("uuid")]
        public string? UUID { get; set; }

        [JsonIgnore]
        public bool HasAnyID => !string.IsNullOrWhiteSpace(Slug) || !string.IsNullOrWhiteSpace(UUID);

        [JsonIgnore]
        public string BestID
        {
            get
            {
                if (!HasAnyID)
                    return string.Empty;

                if (!string.IsNullOrWhiteSpace(Slug))
                    return Slug!;

                if (!string.IsNullOrWhiteSpace(UUID))
                    return UUID!;

                return string.Empty;
            }
        }
    }
}
