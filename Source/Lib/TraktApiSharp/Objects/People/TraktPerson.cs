namespace TraktApiSharp.Objects.People
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public class TraktPerson
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktPersonIds Ids { get; set; }

        [JsonProperty(PropertyName = "images")]
        public TraktPersonImages Images { get; set; }

        [JsonProperty(PropertyName = "biography")]
        public string Biography { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime? Birthday { get; set; }

        [JsonProperty(PropertyName = "death")]
        public DateTime? Death { get; set; }

        public int Age => Birthday.HasValue ? (Death.HasValue ? Birthday.YearsBetween(Death) : Birthday.YearsBetween(DateTime.Now)) : 0;

        [JsonProperty(PropertyName = "birthplace")]
        public string Birthplace { get; set; }

        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        [JsonIgnore]
        public Uri HomepageUri
        {
            get { return !string.IsNullOrEmpty(Homepage) ? new Uri(Homepage) : null; }
            set { Homepage = value.AbsoluteUri; }
        }
    }
}
