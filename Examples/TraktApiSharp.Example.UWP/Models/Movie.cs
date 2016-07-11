namespace TraktApiSharp.Example.UWP.Models
{
    using Objects.Basic;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    public class Movie : TraktMovie
    {
        public IEnumerable<TraktMovieAlias> Aliases { get; set; }

        public IEnumerable<TraktMovieRelease> Releases { get; set; }

        public IEnumerable<TraktMovieTranslation> Translations { get; set; }

        public TraktRating MovieRating { get; set; }

        public TraktStatistics Statistics { get; set; }
    }
}
