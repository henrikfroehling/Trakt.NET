namespace TraktApiSharp.Objects.Post.Checkins
{
    using Get.Movies;
    using Newtonsoft.Json;
    using System;

    public class TraktMovieCheckinPost : TraktCheckinPost, IValidatable
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        public void Validate()
        {
            if (Movie == null)
                throw new ArgumentException("movie not set");

            if (string.IsNullOrEmpty(Movie.Title))
                throw new ArgumentException("movie title not set");

            if (Movie.Year <= 0)
                throw new ArgumentException("movie year not set");

            if (Movie.Ids == null || !Movie.Ids.HasAnyId)
                throw new ArgumentException("movie ids not set");
        }
    }
}
