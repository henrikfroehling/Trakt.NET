namespace TraktApiSharp.Objects.Users.Lists
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using Users;

    public class TraktList
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "privacy")]
        [JsonConverter(typeof(TraktAccessScopeConverter))]
        public TraktAccessScope Privacy { get; set; }

        [JsonProperty(PropertyName = "display_numbers")]
        public bool? DisplayNumbers { get; set; }

        [JsonProperty(PropertyName = "allow_comments")]
        public bool? AllowComments { get; set; }

        [JsonProperty(PropertyName = "sort_by")]
        public string SortBy { get; set; }

        [JsonProperty(PropertyName = "sort_how")]
        public string SortHow { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "item_count")]
        public int? ItemCount { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int? CommentCount { get; set; }

        [JsonProperty(PropertyName = "likes")]
        public int? Likes { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktListIds Ids { get; set; }

        [JsonProperty(PropertyName = "user")]
        public TraktUser User { get; set; }
    }
}
