namespace TraktNet.Objects.Post.Builder.Implementation
{
    using Helper;
    using Interfaces;
    using Interfaces.Capabilities;
    using Objects.Get.Movies;
    using Objects.Get.Seasons;
    using Objects.Get.Shows;
    using Objects.Post.Users.HiddenItems;
    using System.Collections.Generic;

    public class TraktUserHiddenItemsPostBuilder : ITraktUserHiddenItemsPostBuilder
    {
        private readonly List<ITraktMovie> _movies;
        private readonly List<ITraktShow> _shows;
        private readonly List<ITraktSeason> _seasons;
        private readonly ITraktPostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost> _showsWithSeasons;

        internal TraktUserHiddenItemsPostBuilder()
        {
            _movies = new List<ITraktMovie>();
            _shows = new List<ITraktShow>();
            _seasons = new List<ITraktSeason>();
            _showsWithSeasons = new TraktPostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>(this);
        }

        public ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            _movies.Add(movie);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            _movies.AddRange(movies);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShow(ITraktShow show)
        {
            _shows.Add(show);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            _shows.AddRange(shows);
            return this;
        }

        public ITraktPostBuilderShowAddedSeasons<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost> AddShowAndSeasons(ITraktShow show)
        {
            _showsWithSeasons.SetCurrentShow(show);
            return _showsWithSeasons;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeason season)
        {
            _seasons.Add(season);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            _seasons.AddRange(seasons);
            return this;
        }

        public ITraktUserHiddenItemsPost Build()
        {
            return new TraktUserHiddenItemsPost();
        }
    }
}
