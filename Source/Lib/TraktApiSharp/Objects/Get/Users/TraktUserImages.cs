namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Newtonsoft.Json;

    public class TraktUserImages
    {
        [JsonProperty(PropertyName = "avatar")]
        public TraktImage Avatar { get; set; }
    }
}
