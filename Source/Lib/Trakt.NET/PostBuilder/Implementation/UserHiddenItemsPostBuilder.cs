namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;

    internal sealed class UserHiddenItemsPostBuilder : ITraktUserHiddenItemsPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<HiddenShowWithSeasons>> _showsWithSeasons;
        private readonly Lazy<List<HiddenShowIdsWithSeasons>> _showIdsWithSeasons;
        private readonly Lazy<List<ITraktSeason>> _seasons;
        private readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        private readonly Lazy<List<ITraktUser>> _users;
        private readonly Lazy<List<ITraktUserIds>> _userIds;

        internal UserHiddenItemsPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsWithSeasons = new Lazy<List<HiddenShowWithSeasons>>();
            _showIdsWithSeasons = new Lazy<List<HiddenShowIdsWithSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _users = new Lazy<List<ITraktUser>>();
            _userIds = new Lazy<List<ITraktUserIds>>();
        }

        public ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            foreach (ITraktMovie movie in movies)
            {
                if (movie != null)
                    _movies.Value.Add(movie);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            foreach (ITraktMovieIds movieId in movieIds)
            {
                if (movieId != null)
                    _movieIds.Value.Add(movieId);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            foreach (ITraktShow show in shows)
            {
                if (show != null)
                    _shows.Value.Add(show);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            foreach (ITraktShowIds showId in showIds)
            {
                if (showId != null)
                    _showIds.Value.Add(showId);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShow show, IEnumerable<int> seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new HiddenShowWithSeasons(show, seasons));
        }

        public ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShow show, int season, params int[] seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            return WithShowAndSeasons(new HiddenShowWithSeasons(show, season, seasons));
        }

        public ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(HiddenShowWithSeasons showWithSeasons)
        {
            if (showWithSeasons == null)
                throw new ArgumentNullException(nameof(showWithSeasons));

            _showsWithSeasons.Value.Add(showWithSeasons);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, IEnumerable<int> seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new HiddenShowIdsWithSeasons(showIds, seasons));
        }

        public ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, int season, params int[] seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            return WithShowAndSeasons(new HiddenShowIdsWithSeasons(showIds, season, seasons));
        }

        public ITraktUserHiddenItemsPostBuilder WithShowAndSeasons(HiddenShowIdsWithSeasons showIdsWithSeasons)
        {
            if (showIdsWithSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithSeasons));

            _showIdsWithSeasons.Value.Add(showIdsWithSeasons);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShowsAndSeasons(IEnumerable<HiddenShowWithSeasons> showsWithSeasons)
        {
            if (showsWithSeasons == null)
                throw new ArgumentNullException(nameof(showsWithSeasons));

            foreach (HiddenShowWithSeasons showWithSeasons in showsWithSeasons)
            {
                if (showWithSeasons != null)
                    _showsWithSeasons.Value.Add(showWithSeasons);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithShowsAndSeasons(IEnumerable<HiddenShowIdsWithSeasons> showIdsWithSeasons)
        {
            if (showIdsWithSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithSeasons));

            foreach (HiddenShowIdsWithSeasons showIdWithSeasons in showIdsWithSeasons)
            {
                if (showIdWithSeasons != null)
                    _showIdsWithSeasons.Value.Add(showIdWithSeasons);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
        {
            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            foreach (ITraktSeason season in seasons)
            {
                if (season != null)
                    _seasons.Value.Add(season);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            foreach (ITraktSeasonIds seasonId in seasonIds)
            {
                if (seasonId != null)
                    _seasonIds.Value.Add(seasonId);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithUser(ITraktUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _users.Value.Add(user);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithUser(ITraktUserIds userIds)
        {
            if (userIds == null)
                throw new ArgumentNullException(nameof(userIds));

            _userIds.Value.Add(userIds);
            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithUsers(IEnumerable<ITraktUser> users)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            foreach (ITraktUser user in users)
            {
                if (user != null)
                    _users.Value.Add(user);
            }

            return this;
        }

        public ITraktUserHiddenItemsPostBuilder WithUsers(IEnumerable<ITraktUserIds> userIds)
        {
            if (userIds == null)
                throw new ArgumentNullException(nameof(userIds));

            foreach (ITraktUserIds userId in userIds)
            {
                if (userId != null)
                    _userIds.Value.Add(userId);
            }

            return this;
        }

        public ITraktUserHiddenItemsPost Build()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = new TraktUserHiddenItemsPost();
            AddMovies(userHiddenItemsPost);
            AddShows(userHiddenItemsPost);
            AddSeasons(userHiddenItemsPost);
            AddUsers(userHiddenItemsPost);
            userHiddenItemsPost.Validate();
            return userHiddenItemsPost;
        }

        private void AddMovies(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            userHiddenItemsPost.Movies ??= new List<ITraktUserHiddenItemsPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (userHiddenItemsPost.Movies as List<ITraktUserHiddenItemsPostMovie>)
                        .Add(CreateHiddenItemsPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (userHiddenItemsPost.Movies as List<ITraktUserHiddenItemsPostMovie>)
                        .Add(CreateHiddenItemsPostMovie(movieIds));
                }
            }
        }

        private void AddShows(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated
                && !_showsWithSeasons.IsValueCreated && !_showIdsWithSeasons.IsValueCreated)
            {
                return;
            }

            userHiddenItemsPost.Shows ??= new List<ITraktUserHiddenItemsPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>)
                        .Add(CreateHiddenItemsPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>)
                        .Add(CreateHiddenItemsPostShow(showIds));
                }
            }

            if (_showsWithSeasons.IsValueCreated && _showsWithSeasons.Value.Any())
                CreateHiddenItemsPostShowWithSeasons(userHiddenItemsPost, _showsWithSeasons.Value);

            if (_showIdsWithSeasons.IsValueCreated && _showIdsWithSeasons.Value.Any())
                CreateHiddenItemsPostShowWithSeasons(userHiddenItemsPost, _showIdsWithSeasons.Value);
        }

        private void AddSeasons(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated)
                return;

            userHiddenItemsPost.Seasons ??= new List<ITraktUserHiddenItemsPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (userHiddenItemsPost.Seasons as List<ITraktUserHiddenItemsPostSeason>)
                        .Add(CreateHiddenItemsPostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (userHiddenItemsPost.Seasons as List<ITraktUserHiddenItemsPostSeason>)
                        .Add(CreateHiddenItemsPostSeason(seasonIds));
                }
            }
        }

        private void AddUsers(ITraktUserHiddenItemsPost userHiddenItemsPost)
        {
            if (!_users.IsValueCreated && !_userIds.IsValueCreated)
                return;

            userHiddenItemsPost.Users ??= new List<ITraktUser>();

            if (_users.IsValueCreated && _users.Value.Any())
            {
                foreach (ITraktUser user in _users.Value)
                    (userHiddenItemsPost.Users as List<ITraktUser>).Add(user);
            }

            if (_userIds.IsValueCreated && _userIds.Value.Any())
            {
                foreach (ITraktUserIds userIds in _userIds.Value)
                {
                    (userHiddenItemsPost.Users as List<ITraktUser>)
                        .Add(new TraktUser
                        {
                            Ids = userIds
                        });
                }
            }
        }

        private static ITraktUserHiddenItemsPostMovie CreateHiddenItemsPostMovie(ITraktMovie movie)
            => new TraktUserHiddenItemsPostMovie
            {
                Ids = movie.Ids,
                Title = movie.Title,
                Year = movie.Year
            };

        private static ITraktUserHiddenItemsPostMovie CreateHiddenItemsPostMovie(ITraktMovieIds movieIds)
            => new TraktUserHiddenItemsPostMovie { Ids = movieIds };

        private static ITraktUserHiddenItemsPostShow CreateHiddenItemsPostShow(ITraktShow show)
            => new TraktUserHiddenItemsPostShow
            {
                Ids = show.Ids,
                Title = show.Title,
                Year = show.Year
            };

        private static ITraktUserHiddenItemsPostShow CreateHiddenItemsPostShow(ITraktShowIds showIds)
            => new TraktUserHiddenItemsPostShow { Ids = showIds };

        private static void CreateHiddenItemsPostShowWithSeasons(ITraktUserHiddenItemsPost userHiddenItemsPost, List<HiddenShowWithSeasons> showsWithSeasons)
        {
            foreach (HiddenShowWithSeasons showWithSeasons in showsWithSeasons)
            {
                ITraktUserHiddenItemsPostShow userHiddenItemsPostShow = CreateHiddenItemsPostShow(showWithSeasons.Object);
                CreateHiddenItemsPostShowSeasons(userHiddenItemsPost, showWithSeasons.Seasons, userHiddenItemsPostShow);
            }
        }

        private static void CreateHiddenItemsPostShowWithSeasons(ITraktUserHiddenItemsPost userHiddenItemsPost, List<HiddenShowIdsWithSeasons> showIdsWithSeasons)
        {
            foreach (HiddenShowIdsWithSeasons showIdWithSeasons in showIdsWithSeasons)
            {
                ITraktUserHiddenItemsPostShow userHiddenItemsPostShow = CreateHiddenItemsPostShow(showIdWithSeasons.Object);
                CreateHiddenItemsPostShowSeasons(userHiddenItemsPost, showIdWithSeasons.Seasons, userHiddenItemsPostShow);
            }
        }

        private static void CreateHiddenItemsPostShowSeasons(ITraktUserHiddenItemsPost userHiddenItemsPost, IEnumerable<int> seasons,
                                                             ITraktUserHiddenItemsPostShow userHiddenItemsPostShow)
        {
            if (seasons.Any())
            {
                userHiddenItemsPostShow.Seasons = new List<ITraktUserHiddenItemsPostShowSeason>();

                foreach (int season in seasons)
                {
                    ITraktUserHiddenItemsPostShowSeason userHiddenItemsPostShowSeason = CreateHiddenItemsPostShowSeason(season);
                    (userHiddenItemsPostShow.Seasons as List<ITraktUserHiddenItemsPostShowSeason>).Add(userHiddenItemsPostShowSeason);
                }
            }

            (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>).Add(userHiddenItemsPostShow);
        }

        private static ITraktUserHiddenItemsPostShowSeason CreateHiddenItemsPostShowSeason(int season)
            => new TraktUserHiddenItemsPostShowSeason { Number = season };

        private static ITraktUserHiddenItemsPostSeason CreateHiddenItemsPostSeason(ITraktSeason season)
            => new TraktUserHiddenItemsPostSeason { Ids = season.Ids };

        private static ITraktUserHiddenItemsPostSeason CreateHiddenItemsPostSeason(ITraktSeasonIds seasonIds)
            => new TraktUserHiddenItemsPostSeason { Ids = seasonIds };
    }
}
