using System.Text.Json.Serialization;

namespace TraktNET
{
    public class TraktUserMinimal
    {
        public string? Username { get; set; }

        public bool? Private { get; set; }

        public string? Name { get; set; }

        public bool? VIP { get; set; }

        [JsonPropertyName("vip_ep")]
        public bool? VIPEP { get; set; }

        public TraktUserIds? Ids { get; set; }
    }
}
