namespace TraktApiSharp.Objects.Post.Users.ListItems
{
    using Get.People;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktUserListItemsPost : IValidatable
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUserListItemsPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUserListItemsShowItem> Shows { get; set; }

        [JsonProperty(PropertyName = "people")]
        public IEnumerable<TraktPerson> People { get; set; }

        public void Validate()
        {
            var bHasNoMovies = Movies == null || !Movies.Any();
            var bHasNoShows = Shows == null || !Shows.Any();
            var bHasNoPeople = People == null || !People.Any();

            if (bHasNoMovies && bHasNoShows && bHasNoPeople)
                throw new ArgumentException("no items set");
        }
    }
}
