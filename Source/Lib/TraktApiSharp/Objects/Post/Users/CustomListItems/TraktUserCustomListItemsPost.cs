namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.People;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktUserCustomListItemsPost : IValidatable
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUserCustomListItemsPostMovieItem> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUserCustomListItemsShowItem> Shows { get; set; }

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
