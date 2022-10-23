namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.PersonalListItems;

    internal sealed class UserPersonalListItemsRemovePostBuilder
        : ATraktRemovePostBuilder<ITraktUserPersonalListItemsRemovePostBuilder, ITraktUserPersonalListItemsRemovePost>,
          ITraktUserPersonalListItemsRemovePostBuilder
    {
        private readonly Lazy<List<ITraktPerson>> _persons;
        private readonly Lazy<List<ITraktPersonIds>> _personIds;

        internal UserPersonalListItemsRemovePostBuilder()
        {
            _persons = new Lazy<List<ITraktPerson>>();
            _personIds = new Lazy<List<ITraktPersonIds>>();
        }

        public ITraktUserPersonalListItemsRemovePostBuilder WithPerson(ITraktPerson person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _persons.Value.Add(person);
            return this;
        }

        public ITraktUserPersonalListItemsRemovePostBuilder WithPerson(ITraktPersonIds personIds)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            _personIds.Value.Add(personIds);
            return this;
        }

        public ITraktUserPersonalListItemsRemovePostBuilder WithPersons(IEnumerable<ITraktPerson> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));

            foreach (ITraktPerson person in persons)
            {
                if (person != null)
                    _persons.Value.Add(person);
            }

            return this;
        }

        public ITraktUserPersonalListItemsRemovePostBuilder WithPersons(IEnumerable<ITraktPersonIds> personIds)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            foreach (ITraktPersonIds personId in personIds)
            {
                if (personId != null)
                    _personIds.Value.Add(personId);
            }

            return this;
        }

        public override ITraktUserPersonalListItemsRemovePost Build()
        {
            ITraktUserPersonalListItemsRemovePost userListItemsRemovePost = new TraktUserPersonalListItemsRemovePost();
            AddMovies(userListItemsRemovePost);
            AddShows(userListItemsRemovePost);
            AddSeasons(userListItemsRemovePost);
            AddEpisodes(userListItemsRemovePost);
            AddPersons(userListItemsRemovePost);
            userListItemsRemovePost.Validate();
            return userListItemsRemovePost;
        }

        protected override ITraktUserPersonalListItemsRemovePostBuilder GetBuilder() => this;

        private void AddMovies(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated)
                return;

            userListItemsRemovePost.Movies ??= new List<ITraktUserPersonalListItemsPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (userListItemsRemovePost.Movies as List<ITraktUserPersonalListItemsPostMovie>)
                        .Add(CreateListItemsPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (userListItemsRemovePost.Movies as List<ITraktUserPersonalListItemsPostMovie>)
                        .Add(CreateListItemsPostMovie(movieIds));
                }
            }
        }

        private void AddShows(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated
                && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated)
            {
                return;
            }

            userListItemsRemovePost.Shows ??= new List<ITraktUserPersonalListItemsPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (userListItemsRemovePost.Shows as List<ITraktUserPersonalListItemsPostShow>)
                        .Add(CreateListItemsPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (userListItemsRemovePost.Shows as List<ITraktUserPersonalListItemsPostShow>)
                        .Add(CreateListItemsPostShow(showIds));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateListItemsPostShowAndSeasons(userListItemsRemovePost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateListItemsPostShowIdsAndSeasons(userListItemsRemovePost, _showIdsAndSeasons.Value);
        }

        private void AddSeasons(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated)
                return;

            userListItemsRemovePost.Seasons ??= new List<ITraktUserPersonalListItemsPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (userListItemsRemovePost.Seasons as List<ITraktUserPersonalListItemsPostSeason>)
                        .Add(CreateListItemsPostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (userListItemsRemovePost.Seasons as List<ITraktUserPersonalListItemsPostSeason>)
                        .Add(CreateListItemsPostSeason(seasonIds));
                }
            }
        }

        private void AddEpisodes(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated)
                return;

            userListItemsRemovePost.Episodes ??= new List<ITraktUserPersonalListItemsPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (userListItemsRemovePost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>)
                        .Add(CreateListItemsPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (userListItemsRemovePost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>)
                        .Add(CreateListItemsPostEpisode(episodeIds));
                }
            }
        }

        private void AddPersons(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost)
        {
            if (!_persons.IsValueCreated && !_personIds.IsValueCreated)
                return;

            userListItemsRemovePost.People ??= new List<ITraktUserPersonalListItemsPostPerson>();

            if (_persons.IsValueCreated && _persons.Value.Any())
            {
                foreach (ITraktPerson person in _persons.Value)
                {
                    (userListItemsRemovePost.People as List<ITraktUserPersonalListItemsPostPerson>)
                        .Add(CreateListItemsPostPerson(person));
                }
            }

            if (_personIds.IsValueCreated && _personIds.Value.Any())
            {
                foreach (ITraktPersonIds personIds in _personIds.Value)
                {
                    (userListItemsRemovePost.People as List<ITraktUserPersonalListItemsPostPerson>)
                        .Add(CreateListItemsPostPerson(personIds));
                }
            }
        }

        private static ITraktUserPersonalListItemsPostMovie CreateListItemsPostMovie(ITraktMovie movie)
            => CreateListItemsPostMovie(movie.Ids);

        private static ITraktUserPersonalListItemsPostMovie CreateListItemsPostMovie(ITraktMovieIds movieIds)
        {
            ITraktUserPersonalListItemsPostMovie userListItemsPostMovie = new TraktUserPersonalListItemsPostMovie
            {
                Ids = movieIds
            };

            return userListItemsPostMovie;
        }

        private static ITraktUserPersonalListItemsPostShow CreateListItemsPostShow(ITraktShow show)
            => CreateListItemsPostShow(show.Ids);

        private static ITraktUserPersonalListItemsPostShow CreateListItemsPostShow(ITraktShowIds showIds)
        {
            ITraktUserPersonalListItemsPostShow userListItemsPostShow = new TraktUserPersonalListItemsPostShow
            {
                Ids = showIds
            };

            return userListItemsPostShow;
        }

        private static void CreateListItemsPostShowAndSeasons(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktUserPersonalListItemsPostShow userListItemsPostShow = CreateListItemsPostShow(showAndSeasons.Object);
                CreateListItemsPostShowSeasons(userListItemsRemovePost, showAndSeasons.Seasons, userListItemsPostShow);
            }
        }

        private static void CreateListItemsPostShowIdsAndSeasons(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktUserPersonalListItemsPostShow userListItemsPostShow = CreateListItemsPostShow(showIdAndSeasons.Object);
                CreateListItemsPostShowSeasons(userListItemsRemovePost, showIdAndSeasons.Seasons, userListItemsPostShow);
            }
        }

        private static void CreateListItemsPostShowSeasons(ITraktUserPersonalListItemsRemovePost userListItemsRemovePost, PostSeasons seasons, ITraktUserPersonalListItemsPostShow userListItemsPostShow)
        {
            if (seasons.Any())
            {
                userListItemsPostShow.Seasons = new List<ITraktUserPersonalListItemsPostShowSeason>();

                foreach (PostSeason season in seasons)
                {
                    ITraktUserPersonalListItemsPostShowSeason userListItemsPostShowSeason = CreateListItemsPostShowSeason(season);

                    if (season.Episodes != null && season.Episodes.Any())
                    {
                        userListItemsPostShowSeason.Episodes = new List<ITraktUserPersonalListItemsPostShowEpisode>();

                        foreach (PostEpisode episode in season.Episodes)
                        {
                            (userListItemsPostShowSeason.Episodes as List<ITraktUserPersonalListItemsPostShowEpisode>)
                                .Add(CreateListItemsPostShowEpisode(episode));
                        }
                    }

                    (userListItemsPostShow.Seasons as List<ITraktUserPersonalListItemsPostShowSeason>).Add(userListItemsPostShowSeason);
                }
            }

            (userListItemsRemovePost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(userListItemsPostShow);
        }

        private static ITraktUserPersonalListItemsPostShowSeason CreateListItemsPostShowSeason(PostSeason season)
            => new TraktUserPersonalListItemsPostShowSeason { Number = season.Number };

        private static ITraktUserPersonalListItemsPostShowEpisode CreateListItemsPostShowEpisode(PostEpisode episode)
            => new TraktUserPersonalListItemsPostShowEpisode { Number = episode.Number };

        private static ITraktUserPersonalListItemsPostSeason CreateListItemsPostSeason(ITraktSeason season)
            => CreateListItemsPostSeason(season.Ids);

        private static ITraktUserPersonalListItemsPostSeason CreateListItemsPostSeason(ITraktSeasonIds seasonIds)
        {
            ITraktUserPersonalListItemsPostSeason userListItemsPostSeason = new TraktUserPersonalListItemsPostSeason
            {
                Ids = seasonIds
            };

            return userListItemsPostSeason;
        }

        private static ITraktUserPersonalListItemsPostEpisode CreateListItemsPostEpisode(ITraktEpisode episode)
            => CreateListItemsPostEpisode(episode.Ids);

        private static ITraktUserPersonalListItemsPostEpisode CreateListItemsPostEpisode(ITraktEpisodeIds episodeIds)
        {
            ITraktUserPersonalListItemsPostEpisode userListItemsPostEpisode = new TraktUserPersonalListItemsPostEpisode
            {
                Ids = episodeIds
            };

            return userListItemsPostEpisode;
        }

        private static ITraktUserPersonalListItemsPostPerson CreateListItemsPostPerson(ITraktPerson person)
            => CreateListItemsPostPerson(person.Ids);

        private static ITraktUserPersonalListItemsPostPerson CreateListItemsPostPerson(ITraktPersonIds personIds)
        {
            ITraktUserPersonalListItemsPostPerson userListItemsPostPerson = new TraktUserPersonalListItemsPostPerson
            {
                Ids = personIds
            };

            return userListItemsPostPerson;
        }
    }
}
