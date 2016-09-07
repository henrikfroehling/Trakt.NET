namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Basic;
    using Objects.Get.Movies;
    using System.Collections.ObjectModel;

    public class Movie : TraktMovie
    {
        public ObservableCollection<TraktMovieAlias> Aliases { get; set; }

        public ObservableCollection<TraktMovieRelease> Releases { get; set; }

        public ObservableCollection<TraktMovieTranslation> Translations { get; set; }

        public TraktRating MovieRating { get; set; }

        public TraktStatistics Statistics { get; set; }
    }
}
