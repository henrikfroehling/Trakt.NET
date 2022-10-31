namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;

    internal sealed class UserHiddenItemsPostBuilder
        : AHiddenItemsPostBuilder<ITraktUserHiddenItemsPostBuilder, ITraktUserHiddenItemsPost>,
          ITraktUserHiddenItemsPostBuilder
    {
        public override ITraktUserHiddenItemsPost Build()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = new TraktUserHiddenItemsPost();
            AddMovies(userHiddenItemsPost);
            AddShows(userHiddenItemsPost);
            AddSeasons(userHiddenItemsPost);
            AddUsers(userHiddenItemsPost);
            userHiddenItemsPost.Validate();
            return userHiddenItemsPost;
        }

        protected override ITraktUserHiddenItemsPostBuilder GetBuilder() => this;

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
