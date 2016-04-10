namespace TraktApiSharp.Objects.Users
{
    using Newtonsoft.Json;

    public class TraktUserImages
    {
        [JsonProperty(PropertyName = "avatar")]
        public TraktImage Avatar { get; set; }
    }
}
