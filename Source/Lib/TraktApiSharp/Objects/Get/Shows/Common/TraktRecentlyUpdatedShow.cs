namespace TraktApiSharp.Objects.Get.Shows.Common
{
    using Newtonsoft.Json;
    using System;

    public class TraktRecentlyUpdatedShow
    {
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}
