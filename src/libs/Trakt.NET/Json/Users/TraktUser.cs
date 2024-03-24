using System.Text.Json.Serialization;

namespace TraktNET
{
    public class TraktUser : TraktUserMinimal
    {
        public DateTime? JoinedAt { get; set; }

        public string? Location { get; set; }

        public string? About { get; set; }

        public TraktGender? Gender { get; set; }

        public uint? Age { get; set; }

        public TraktUserImages? Images { get; set; }

        [JsonPropertyName("vip_og")]
        public bool? VIPOG { get; set; }

        public uint? VIPYears { get; set; }

        public string? VIPCoverImage { get; set; }
    }
}
