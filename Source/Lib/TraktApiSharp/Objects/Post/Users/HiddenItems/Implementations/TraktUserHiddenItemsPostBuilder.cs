namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktUserHiddenItemsPostBuilder
    {
        private readonly ITraktUserHiddenItemsPost _hiddenItemsPost;

        public TraktUserHiddenItemsPostBuilder()
        {
            _hiddenItemsPost = new TraktUserHiddenItemsPost();
        }

        public TraktUserHiddenItemsPostBuilder AddMovie(ITraktMovie movie)
        {
            ValidateMovie(movie);
            EnsureMoviesListExists();

            var existingMovie = _hiddenItemsPost.Movies.FirstOrDefault(m => m.Ids == movie.Ids);

            if (existingMovie != null)
                return this;

            (_hiddenItemsPost.Movies as List<TraktUserHiddenItemsPostMovie>)?.Add(
                new TraktUserHiddenItemsPostMovie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Ids = movie.Ids
                });

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (var movie in movies)
                AddMovie(movie);

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddShow(ITraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var existingShow = _hiddenItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
                return this;

            (_hiddenItemsPost.Shows as List<TraktUserHiddenItemsPostShow>)?.Add(
                new TraktUserHiddenItemsPostShow
                {
                    Title = show.Title,
                    Year = show.Year,
                    Ids = show.Ids
                });

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (var show in shows)
                AddShow(show);

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddShow(ITraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktUserHiddenItemsPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUserHiddenItemsPostShowSeason { Number = seasonsToAdd[i] });
            }

            var existingShow = _hiddenItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                (_hiddenItemsPost.Shows as List<TraktUserHiddenItemsPostShow>)?.Add(
                    new TraktUserHiddenItemsPostShow
                    {
                        Title = show.Title,
                        Year = show.Year,
                        Ids = show.Ids,
                        Seasons = showSeasons
                    });
            }

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddShow(ITraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<TraktUserHiddenItemsPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUserHiddenItemsPostShowSeason { Number = seasons[i] });
            }

            var existingShow = _hiddenItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                (_hiddenItemsPost.Shows as List<TraktUserHiddenItemsPostShow>)?.Add(
                    new TraktUserHiddenItemsPostShow
                    {
                        Title = show.Title,
                        Year = show.Year,
                        Ids = show.Ids,
                        Seasons = showSeasons
                    });
            }

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddSeason(ITraktSeason season)
        {
            ValidateSeason(season);
            EnsureSeasonsListExists();

            var existingSeason = _hiddenItemsPost.Movies.FirstOrDefault(s => s.Ids == season.Ids);

            if (existingSeason != null)
                return this;

            (_hiddenItemsPost.Seasons as List<TraktUserHiddenItemsPostSeason>)?.Add(
                new TraktUserHiddenItemsPostSeason
                {
                    Ids = season.Ids
                });

            return this;
        }

        public TraktUserHiddenItemsPostBuilder AddSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            if (!seasons.Any())
                return this;

            foreach (var season in seasons)
                AddSeason(season);

            return this;
        }

        public void Reset()
        {
            if (_hiddenItemsPost.Movies != null)
            {
                (_hiddenItemsPost.Movies as List<TraktUserHiddenItemsPostMovie>)?.Clear();
                _hiddenItemsPost.Movies = null;
            }

            if (_hiddenItemsPost.Shows != null)
            {
                (_hiddenItemsPost.Shows as List<TraktUserHiddenItemsPostShow>)?.Clear();
                _hiddenItemsPost.Shows = null;
            }

            if (_hiddenItemsPost.Seasons != null)
            {
                (_hiddenItemsPost.Seasons as List<TraktUserHiddenItemsPostSeason>)?.Clear();
                _hiddenItemsPost.Seasons = null;
            }
        }

        public ITraktUserHiddenItemsPost Build() => _hiddenItemsPost;

        private void ValidateMovie(ITraktMovie movie)
        {
            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));
        }

        private void ValidateShow(ITraktShow show)
        {
            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));
        }

        private void ValidateSeason(ITraktSeason season)
        {
            if (season.Ids == null)
                throw new ArgumentNullException(nameof(season.Ids));

            if (!season.Ids.HasAnyId)
                throw new ArgumentException("no season ids set or valid", nameof(season.Ids));
        }

        private void EnsureMoviesListExists()
        {
            if (_hiddenItemsPost.Movies == null)
                _hiddenItemsPost.Movies = new List<TraktUserHiddenItemsPostMovie>();
        }

        private void EnsureShowsListExists()
        {
            if (_hiddenItemsPost.Shows == null)
                _hiddenItemsPost.Shows = new List<TraktUserHiddenItemsPostShow>();
        }

        private void EnsureSeasonsListExists()
        {
            if (_hiddenItemsPost.Seasons == null)
                _hiddenItemsPost.Seasons = new List<TraktUserHiddenItemsPostSeason>();
        }
    }
}
