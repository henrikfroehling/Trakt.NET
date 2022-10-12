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

    internal sealed class UserPersonalListItemsPostBuilder : ITraktUserPersonalListItemsPostBuilder
    {
        private readonly Lazy<List<ITraktMovie>> _movies;
        private readonly Lazy<List<ITraktMovieIds>> _movieIds;
        private readonly Lazy<List<MovieWithNotes>> _moviesWithNotes;
        private readonly Lazy<List<MovieIdsWithNotes>> _movieIdsWithNotes;
        private readonly Lazy<List<ITraktShow>> _shows;
        private readonly Lazy<List<ITraktShowIds>> _showIds;
        private readonly Lazy<List<ShowWithNotes>> _showsWithNotes;
        private readonly Lazy<List<ShowIdsWithNotes>> _showIdsWithNotes;
        private readonly Lazy<List<ShowAndSeasons>> _showsAndSeasons;
        private readonly Lazy<List<ShowIdsAndSeasons>> _showIdsAndSeasons;
        private readonly Lazy<List<ShowWithNotesAndSeasons>> _showsWithNotesAndSeasons;
        private readonly Lazy<List<ShowIdsWithNotesAndSeasons>> _showIdsWithNotesAndSeasons;
        private readonly Lazy<List<ITraktSeason>> _seasons;
        private readonly Lazy<List<ITraktSeasonIds>> _seasonIds;
        private readonly Lazy<List<SeasonWithNotes>> _seasonsWithNotes;
        private readonly Lazy<List<SeasonIdsWithNotes>> _seasonIdsWithNotes;
        private readonly Lazy<List<ITraktEpisode>> _episodes;
        private readonly Lazy<List<ITraktEpisodeIds>> _episodeIds;
        private readonly Lazy<List<EpisodeWithNotes>> _episodesWithNotes;
        private readonly Lazy<List<EpisodeIdsWithNotes>> _episodeIdsWithNotes;
        private readonly Lazy<List<ITraktPerson>> _persons;
        private readonly Lazy<List<ITraktPersonIds>> _personIds;
        private readonly Lazy<List<PersonWithNotes>> _personsWithNotes;
        private readonly Lazy<List<PersonIdsWithNotes>> _personIdsWithNotes;

        internal UserPersonalListItemsPostBuilder()
        {
            _movies = new Lazy<List<ITraktMovie>>();
            _movieIds = new Lazy<List<ITraktMovieIds>>();
            _moviesWithNotes = new Lazy<List<MovieWithNotes>>();
            _movieIdsWithNotes = new Lazy<List<MovieIdsWithNotes>>();
            _shows = new Lazy<List<ITraktShow>>();
            _showIds = new Lazy<List<ITraktShowIds>>();
            _showsWithNotes = new Lazy<List<ShowWithNotes>>();
            _showIdsWithNotes = new Lazy<List<ShowIdsWithNotes>>();
            _showsAndSeasons = new Lazy<List<ShowAndSeasons>>();
            _showIdsAndSeasons = new Lazy<List<ShowIdsAndSeasons>>();
            _showsWithNotesAndSeasons = new Lazy<List<ShowWithNotesAndSeasons>>();
            _showIdsWithNotesAndSeasons = new Lazy<List<ShowIdsWithNotesAndSeasons>>();
            _seasons = new Lazy<List<ITraktSeason>>();
            _seasonIds = new Lazy<List<ITraktSeasonIds>>();
            _seasonsWithNotes = new Lazy<List<SeasonWithNotes>>();
            _seasonIdsWithNotes = new Lazy<List<SeasonIdsWithNotes>>();
            _episodes = new Lazy<List<ITraktEpisode>>();
            _episodeIds = new Lazy<List<ITraktEpisodeIds>>();
            _episodesWithNotes = new Lazy<List<EpisodeWithNotes>>();
            _episodeIdsWithNotes = new Lazy<List<EpisodeIdsWithNotes>>();
            _persons = new Lazy<List<ITraktPerson>>();
            _personIds = new Lazy<List<ITraktPersonIds>>();
            _personsWithNotes = new Lazy<List<PersonWithNotes>>();
            _personIdsWithNotes = new Lazy<List<PersonIdsWithNotes>>();
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            _movies.Value.Add(movie);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovie(ITraktMovieIds movieIds)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            _movieIds.Value.Add(movieIds);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            CheckNotes(notes);
            return WithMovieWithNotes(new MovieWithNotes(movie, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(MovieWithNotes movieWithNotes)
        {
            if (movieWithNotes == null)
                throw new ArgumentNullException(nameof(movieWithNotes));

            CheckNotes(movieWithNotes.Notes);
            _moviesWithNotes.Value.Add(movieWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(ITraktMovieIds movieIds, string notes)
        {
            if (movieIds == null)
                throw new ArgumentNullException(nameof(movieIds));

            CheckNotes(notes);
            return WithMovieWithNotes(new MovieIdsWithNotes(movieIds, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovieWithNotes(MovieIdsWithNotes movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            CheckNotes(movieIdsWithNotes.Notes);
            _movieIdsWithNotes.Value.Add(movieIdsWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMovies(IEnumerable<ITraktMovie> movies)
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

        public ITraktUserPersonalListItemsPostBuilder WithMovies(IEnumerable<ITraktMovieIds> movieIds)
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

        public ITraktUserPersonalListItemsPostBuilder WithMoviesWithNotes(IEnumerable<MovieWithNotes> moviesWithNotes)
        {
            if (moviesWithNotes == null)
                throw new ArgumentNullException(nameof(moviesWithNotes));

            foreach (MovieWithNotes movieWithNotes in moviesWithNotes)
            {
                if (movieWithNotes != null)
                {
                    CheckNotes(movieWithNotes.Notes);
                    _moviesWithNotes.Value.Add(movieWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithMoviesWithNotes(IEnumerable<MovieIdsWithNotes> movieIdsWithNotes)
        {
            if (movieIdsWithNotes == null)
                throw new ArgumentNullException(nameof(movieIdsWithNotes));

            foreach (MovieIdsWithNotes movieIdWithNotes in movieIdsWithNotes)
            {
                if (movieIdWithNotes != null)
                {
                    CheckNotes(movieIdWithNotes.Notes);
                    _movieIdsWithNotes.Value.Add(movieIdWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            _shows.Value.Add(show);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShow(ITraktShowIds showIds)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            _showIds.Value.Add(showIds);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ITraktShow show, string notes)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            CheckNotes(notes);
            return WithShowWithNotes(new ShowWithNotes(show, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ShowWithNotes showWithNotes)
        {
            if (showWithNotes == null)
                throw new ArgumentNullException(nameof(showWithNotes));

            CheckNotes(showWithNotes.Notes);
            _showsWithNotes.Value.Add(showWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ITraktShowIds showIds, string notes)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            CheckNotes(notes);
            return WithShowWithNotes(new ShowIdsWithNotes(showIds, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotes(ShowIdsWithNotes showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            CheckNotes(showIdsWithNotes.Notes);
            _showIdsWithNotes.Value.Add(showIdsWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShows(IEnumerable<ITraktShow> shows)
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

        public ITraktUserPersonalListItemsPostBuilder WithShows(IEnumerable<ITraktShowIds> showIds)
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

        public ITraktUserPersonalListItemsPostBuilder WithShowsWithNotes(IEnumerable<ShowWithNotes> showsWithNotes)
        {
            if (showsWithNotes == null)
                throw new ArgumentNullException(nameof(showsWithNotes));

            foreach (ShowWithNotes showWithNotes in showsWithNotes)
            {
                if (showWithNotes != null)
                {
                    CheckNotes(showWithNotes.Notes);
                    _showsWithNotes.Value.Add(showWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowsWithNotes(IEnumerable<ShowIdsWithNotes> showIdsWithNotes)
        {
            if (showIdsWithNotes == null)
                throw new ArgumentNullException(nameof(showIdsWithNotes));

            foreach (ShowIdsWithNotes showIdWithNotes in showIdsWithNotes)
            {
                if (showIdWithNotes != null)
                {
                    CheckNotes(showIdWithNotes.Notes);
                    _showIdsWithNotes.Value.Add(showIdWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShow show, PostSeasons seasons)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowAndSeasons(show, seasons));
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ShowAndSeasons showAndSeasons)
        {
            if (showAndSeasons == null)
                throw new ArgumentNullException(nameof(showAndSeasons));

            _showsAndSeasons.Value.Add(showAndSeasons);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ITraktShowIds showIds, PostSeasons seasons)
        {
            if (showIds == null)
                throw new ArgumentNullException(nameof(showIds));

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            return WithShowAndSeasons(new ShowIdsAndSeasons(showIds, seasons));
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowAndSeasons(ShowIdsAndSeasons showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            _showIdsAndSeasons.Value.Add(showIdsAndSeasons);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotesAndSeasons(ShowWithNotesAndSeasons showWithNotesAndSeasons)
        {
            if (showWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showWithNotesAndSeasons));

            CheckNotes(showWithNotesAndSeasons.Object.Notes);
            _showsWithNotesAndSeasons.Value.Add(showWithNotesAndSeasons);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowWithNotesAndSeasons(ShowIdsWithNotesAndSeasons showIdsWithNotesAndSeasons)
        {
            if (showIdsWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithNotesAndSeasons));

            CheckNotes(showIdsWithNotesAndSeasons.Object.Notes);
            _showIdsWithNotesAndSeasons.Value.Add(showIdsWithNotesAndSeasons);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowsAndSeasons(IEnumerable<ShowAndSeasons> showsAndSeasons)
        {
            if (showsAndSeasons == null)
                throw new ArgumentNullException(nameof(showsAndSeasons));

            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                if (showAndSeasons != null)
                    _showsAndSeasons.Value.Add(showAndSeasons);
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowsAndSeasons(IEnumerable<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            if (showIdsAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsAndSeasons));

            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                if (showIdAndSeasons != null)
                    _showIdsAndSeasons.Value.Add(showIdAndSeasons);
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowWithNotesAndSeasons> showsWithNotesAndSeasons)
        {
            if (showsWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showsWithNotesAndSeasons));

            foreach (ShowWithNotesAndSeasons showWithNotesAndSeasons in showsWithNotesAndSeasons)
            {
                if (showWithNotesAndSeasons != null)
                {
                    CheckNotes(showWithNotesAndSeasons.Object.Notes);
                    _showsWithNotesAndSeasons.Value.Add(showWithNotesAndSeasons);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithShowsWithNotesAndSeasons(IEnumerable<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons)
        {
            if (showIdsWithNotesAndSeasons == null)
                throw new ArgumentNullException(nameof(showIdsWithNotesAndSeasons));

            foreach (ShowIdsWithNotesAndSeasons showIdWithNotesAndSeasons in showIdsWithNotesAndSeasons)
            {
                if (showIdWithNotesAndSeasons != null)
                {
                    CheckNotes(showIdWithNotesAndSeasons.Object.Notes);
                    _showIdsWithNotesAndSeasons.Value.Add(showIdWithNotesAndSeasons);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeason(ITraktSeason season)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            _seasons.Value.Add(season);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeason(ITraktSeasonIds seasonIds)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            _seasonIds.Value.Add(seasonIds);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(ITraktSeason season, string notes)
        {
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            CheckNotes(notes);
            return WithSeasonWithNotes(new SeasonWithNotes(season, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(SeasonWithNotes seasonWithNotes)
        {
            if (seasonWithNotes == null)
                throw new ArgumentNullException(nameof(seasonWithNotes));

            CheckNotes(seasonWithNotes.Notes);
            _seasonsWithNotes.Value.Add(seasonWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(ITraktSeasonIds seasonIds, string notes)
        {
            if (seasonIds == null)
                throw new ArgumentNullException(nameof(seasonIds));

            CheckNotes(notes);
            return WithSeasonWithNotes(new SeasonIdsWithNotes(seasonIds, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeasonWithNotes(SeasonIdsWithNotes seasonIdsWithNotes)
        {
            if (seasonIdsWithNotes == null)
                throw new ArgumentNullException(nameof(seasonIdsWithNotes));

            CheckNotes(seasonIdsWithNotes.Notes);
            _seasonIdsWithNotes.Value.Add(seasonIdsWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeasons(IEnumerable<ITraktSeason> seasons)
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

        public ITraktUserPersonalListItemsPostBuilder WithSeasons(IEnumerable<ITraktSeasonIds> seasonIds)
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

        public ITraktUserPersonalListItemsPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonWithNotes> seasonsWithNotes)
        {
            if (seasonsWithNotes == null)
                throw new ArgumentNullException(nameof(seasonsWithNotes));

            foreach (SeasonWithNotes seasonWithNotes in seasonsWithNotes)
            {
                if (seasonWithNotes != null)
                {
                    CheckNotes(seasonWithNotes.Notes);
                    _seasonsWithNotes.Value.Add(seasonWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithSeasonsWithNotes(IEnumerable<SeasonIdsWithNotes> seasonIdsWithNotes)
        {
            if (seasonIdsWithNotes == null)
                throw new ArgumentNullException(nameof(seasonIdsWithNotes));

            foreach (SeasonIdsWithNotes seasonIdWithNotes in seasonIdsWithNotes)
            {
                if (seasonIdWithNotes != null)
                {
                    CheckNotes(seasonIdWithNotes.Notes);
                    _seasonIdsWithNotes.Value.Add(seasonIdWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisode(ITraktEpisode episode)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            _episodes.Value.Add(episode);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisode(ITraktEpisodeIds episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            _episodeIds.Value.Add(episodeIds);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes)
        {
            if (episode == null)
                throw new ArgumentNullException(nameof(episode));

            CheckNotes(notes);
            return WithEpisodeWithNotes(new EpisodeWithNotes(episode, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(EpisodeWithNotes episodeWithNotes)
        {
            if (episodeWithNotes == null)
                throw new ArgumentNullException(nameof(episodeWithNotes));

            CheckNotes(episodeWithNotes.Notes);
            _episodesWithNotes.Value.Add(episodeWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(ITraktEpisodeIds episodeIds, string notes)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            CheckNotes(notes);
            return WithEpisodeWithNotes(new EpisodeIdsWithNotes(episodeIds, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodeWithNotes(EpisodeIdsWithNotes episodeIdsWithNotes)
        {
            if (episodeIdsWithNotes == null)
                throw new ArgumentNullException(nameof(episodeIdsWithNotes));

            CheckNotes(episodeIdsWithNotes.Notes);
            _episodeIdsWithNotes.Value.Add(episodeIdsWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes)
        {
            if (episodes == null)
                throw new ArgumentNullException(nameof(episodes));

            foreach (ITraktEpisode episode in episodes)
            {
                if (episode != null)
                    _episodes.Value.Add(episode);
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodes(IEnumerable<ITraktEpisodeIds> episodeIds)
        {
            if (episodeIds == null)
                throw new ArgumentNullException(nameof(episodeIds));

            foreach (ITraktEpisodeIds episodeId in episodeIds)
            {
                if (episodeId != null)
                    _episodeIds.Value.Add(episodeId);
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeWithNotes> episodesWithNotes)
        {
            if (episodesWithNotes == null)
                throw new ArgumentNullException(nameof(episodesWithNotes));

            foreach (EpisodeWithNotes episodeWithNotes in episodesWithNotes)
            {
                if (episodeWithNotes != null)
                {
                    CheckNotes(episodeWithNotes.Notes);
                    _episodesWithNotes.Value.Add(episodeWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithEpisodesWithNotes(IEnumerable<EpisodeIdsWithNotes> episodeIdsWithNotes)
        {
            if (episodeIdsWithNotes == null)
                throw new ArgumentNullException(nameof(episodeIdsWithNotes));

            foreach (EpisodeIdsWithNotes episodeIdWithNotes in episodeIdsWithNotes)
            {
                if (episodeIdWithNotes != null)
                {
                    CheckNotes(episodeIdWithNotes.Notes);
                    _episodeIdsWithNotes.Value.Add(episodeIdWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPerson(ITraktPerson person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _persons.Value.Add(person);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPerson(ITraktPersonIds personIds)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            _personIds.Value.Add(personIds);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(ITraktPerson person, string notes)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            CheckNotes(notes);
            return WithPersonWithNotes(new PersonWithNotes(person, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(PersonWithNotes personWithNotes)
        {
            if (personWithNotes == null)
                throw new ArgumentNullException(nameof(personWithNotes));

            CheckNotes(personWithNotes.Notes);
            _personsWithNotes.Value.Add(personWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(ITraktPersonIds personIds, string notes)
        {
            if (personIds == null)
                throw new ArgumentNullException(nameof(personIds));

            CheckNotes(notes);
            return WithPersonWithNotes(new PersonIdsWithNotes(personIds, notes));
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersonWithNotes(PersonIdsWithNotes personIdsWithNotes)
        {
            if (personIdsWithNotes == null)
                throw new ArgumentNullException(nameof(personIdsWithNotes));

            CheckNotes(personIdsWithNotes.Notes);
            _personIdsWithNotes.Value.Add(personIdsWithNotes);
            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersons(IEnumerable<ITraktPerson> persons)
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

        public ITraktUserPersonalListItemsPostBuilder WithPersons(IEnumerable<ITraktPersonIds> personIds)
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

        public ITraktUserPersonalListItemsPostBuilder WithPersonsWithNotes(IEnumerable<PersonWithNotes> personsWithNotes)
        {
            if (personsWithNotes == null)
                throw new ArgumentNullException(nameof(personsWithNotes));

            foreach (PersonWithNotes personWithNotes in personsWithNotes)
            {
                if (personWithNotes != null)
                {
                    CheckNotes(personWithNotes.Notes);
                    _personsWithNotes.Value.Add(personWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPostBuilder WithPersonsWithNotes(IEnumerable<PersonIdsWithNotes> personIdsWithNotes)
        {
            if (personIdsWithNotes == null)
                throw new ArgumentNullException(nameof(personIdsWithNotes));

            foreach (PersonIdsWithNotes personIdWithNotes in personIdsWithNotes)
            {
                if (personIdWithNotes != null)
                {
                    CheckNotes(personIdWithNotes.Notes);
                    _personIdsWithNotes.Value.Add(personIdWithNotes);
                }
            }

            return this;
        }

        public ITraktUserPersonalListItemsPost Build()
        {
            ITraktUserPersonalListItemsPost userListItemsPost = new TraktUserPersonalListItemsPost();
            AddMovies(userListItemsPost);
            AddShows(userListItemsPost);
            AddSeasons(userListItemsPost);
            AddEpisodes(userListItemsPost);
            AddPersons(userListItemsPost);
            userListItemsPost.Validate();
            return userListItemsPost;
        }

        private void AddMovies(ITraktUserPersonalListItemsPost userListItemsPost)
        {
            if (!_movies.IsValueCreated && !_movieIds.IsValueCreated
                && !_moviesWithNotes.IsValueCreated && !_movieIdsWithNotes.IsValueCreated)
            {
                return;
            }

            userListItemsPost.Movies ??= new List<ITraktUserPersonalListItemsPostMovie>();

            if (_movies.IsValueCreated && _movies.Value.Any())
            {
                foreach (ITraktMovie movie in _movies.Value)
                {
                    (userListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>)
                        .Add(CreateListItemsPostMovie(movie));
                }
            }

            if (_movieIds.IsValueCreated && _movieIds.Value.Any())
            {
                foreach (ITraktMovieIds movieIds in _movieIds.Value)
                {
                    (userListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>)
                        .Add(CreateListItemsPostMovie(movieIds));
                }
            }

            if (_moviesWithNotes.IsValueCreated && _moviesWithNotes.Value.Any())
            {
                foreach (MovieWithNotes movieWithNotes in _moviesWithNotes.Value)
                {
                    (userListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>)
                        .Add(CreateListItemsPostMovie(movieWithNotes.Object, movieWithNotes.Notes));
                }
            }

            if (_movieIdsWithNotes.IsValueCreated && _movieIdsWithNotes.Value.Any())
            {
                foreach (MovieIdsWithNotes movieIdsWithNotes in _movieIdsWithNotes.Value)
                {
                    (userListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>)
                        .Add(CreateListItemsPostMovie(movieIdsWithNotes.Object, movieIdsWithNotes.Notes));
                }
            }
        }

        private void AddShows(ITraktUserPersonalListItemsPost userListItemsPost)
        {
            if (!_shows.IsValueCreated && !_showIds.IsValueCreated
                && !_showsWithNotes.IsValueCreated && !_showIdsWithNotes.IsValueCreated
                && !_showsAndSeasons.IsValueCreated && !_showIdsAndSeasons.IsValueCreated
                && !_showsWithNotesAndSeasons.IsValueCreated && !_showIdsWithNotesAndSeasons.IsValueCreated)
            {
                return;
            }

            userListItemsPost.Shows ??= new List<ITraktUserPersonalListItemsPostShow>();

            if (_shows.IsValueCreated && _shows.Value.Any())
            {
                foreach (ITraktShow show in _shows.Value)
                {
                    (userListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>)
                        .Add(CreateListItemsPostShow(show));
                }
            }

            if (_showIds.IsValueCreated && _showIds.Value.Any())
            {
                foreach (ITraktShowIds showIds in _showIds.Value)
                {
                    (userListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>)
                        .Add(CreateListItemsPostShow(showIds));
                }
            }

            if (_showsWithNotes.IsValueCreated && _showsWithNotes.Value.Any())
            {
                foreach (ShowWithNotes showWithNotes in _showsWithNotes.Value)
                {
                    (userListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>)
                        .Add(CreateListItemsPostShow(showWithNotes.Object, showWithNotes.Notes));
                }
            }

            if (_showIdsWithNotes.IsValueCreated && _showIdsWithNotes.Value.Any())
            {
                foreach (ShowIdsWithNotes showIdsWithNotes in _showIdsWithNotes.Value)
                {
                    (userListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>)
                        .Add(CreateListItemsPostShow(showIdsWithNotes.Object, showIdsWithNotes.Notes));
                }
            }

            if (_showsAndSeasons.IsValueCreated && _showsAndSeasons.Value.Any())
                CreateListItemsPostShowAndSeasons(userListItemsPost, _showsAndSeasons.Value);

            if (_showIdsAndSeasons.IsValueCreated && _showIdsAndSeasons.Value.Any())
                CreateListItemsPostShowIdsAndSeasons(userListItemsPost, _showIdsAndSeasons.Value);

            if (_showsWithNotesAndSeasons.IsValueCreated && _showsWithNotesAndSeasons.Value.Any())
                CreateListItemsPostShowAndSeasons(userListItemsPost, _showsWithNotesAndSeasons.Value);

            if (_showIdsWithNotesAndSeasons.IsValueCreated && _showIdsWithNotesAndSeasons.Value.Any())
                CreateListItemsPostShowIdsAndSeasons(userListItemsPost, _showIdsWithNotesAndSeasons.Value);
        }

        private void AddSeasons(ITraktUserPersonalListItemsPost userListItemsPost)
        {
            if (!_seasons.IsValueCreated && !_seasonIds.IsValueCreated
                && !_seasonsWithNotes.IsValueCreated && !_seasonIdsWithNotes.IsValueCreated)
            {
                return;
            }

            userListItemsPost.Seasons ??= new List<ITraktUserPersonalListItemsPostSeason>();

            if (_seasons.IsValueCreated && _seasons.Value.Any())
            {
                foreach (ITraktSeason season in _seasons.Value)
                {
                    (userListItemsPost.Seasons as List<ITraktUserPersonalListItemsPostSeason>)
                        .Add(CreateListItemsPostSeason(season));
                }
            }

            if (_seasonIds.IsValueCreated && _seasonIds.Value.Any())
            {
                foreach (ITraktSeasonIds seasonIds in _seasonIds.Value)
                {
                    (userListItemsPost.Seasons as List<ITraktUserPersonalListItemsPostSeason>)
                        .Add(CreateListItemsPostSeason(seasonIds));
                }
            }

            if (_seasonsWithNotes.IsValueCreated && _seasonsWithNotes.Value.Any())
            {
                foreach (SeasonWithNotes seasonWithNotes in _seasonsWithNotes.Value)
                {
                    (userListItemsPost.Seasons as List<ITraktUserPersonalListItemsPostSeason>)
                        .Add(CreateListItemsPostSeason(seasonWithNotes.Object, seasonWithNotes.Notes));
                }
            }

            if (_seasonIdsWithNotes.IsValueCreated && _seasonIdsWithNotes.Value.Any())
            {
                foreach (SeasonIdsWithNotes seasonIdsWithNotes in _seasonIdsWithNotes.Value)
                {
                    (userListItemsPost.Seasons as List<ITraktUserPersonalListItemsPostSeason>)
                        .Add(CreateListItemsPostSeason(seasonIdsWithNotes.Object, seasonIdsWithNotes.Notes));
                }
            }
        }

        private void AddEpisodes(ITraktUserPersonalListItemsPost userListItemsPost)
        {
            if (!_episodes.IsValueCreated && !_episodeIds.IsValueCreated
                && !_episodesWithNotes.IsValueCreated && !_episodeIdsWithNotes.IsValueCreated)
            {
                return;
            }

            userListItemsPost.Episodes ??= new List<ITraktUserPersonalListItemsPostEpisode>();

            if (_episodes.IsValueCreated && _episodes.Value.Any())
            {
                foreach (ITraktEpisode episode in _episodes.Value)
                {
                    (userListItemsPost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>)
                        .Add(CreateListItemsPostEpisode(episode));
                }
            }

            if (_episodeIds.IsValueCreated && _episodeIds.Value.Any())
            {
                foreach (ITraktEpisodeIds episodeIds in _episodeIds.Value)
                {
                    (userListItemsPost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>)
                        .Add(CreateListItemsPostEpisode(episodeIds));
                }
            }

            if (_episodesWithNotes.IsValueCreated && _episodesWithNotes.Value.Any())
            {
                foreach (EpisodeWithNotes episodeWithNotes in _episodesWithNotes.Value)
                {
                    (userListItemsPost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>)
                        .Add(CreateListItemsPostEpisode(episodeWithNotes.Object, episodeWithNotes.Notes));
                }
            }

            if (_episodeIdsWithNotes.IsValueCreated && _episodeIdsWithNotes.Value.Any())
            {
                foreach (EpisodeIdsWithNotes episodeIdsWithNotes in _episodeIdsWithNotes.Value)
                {
                    (userListItemsPost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>)
                        .Add(CreateListItemsPostEpisode(episodeIdsWithNotes.Object, episodeIdsWithNotes.Notes));
                }
            }
        }

        private void AddPersons(ITraktUserPersonalListItemsPost userListItemsPost)
        {
            if (!_persons.IsValueCreated && !_personIds.IsValueCreated
                && !_personsWithNotes.IsValueCreated && !_personIdsWithNotes.IsValueCreated)
            {
                return;
            }

            userListItemsPost.People ??= new List<ITraktUserPersonalListItemsPostPerson>();

            if (_persons.IsValueCreated && _persons.Value.Any())
            {
                foreach (ITraktPerson person in _persons.Value)
                {
                    (userListItemsPost.People as List<ITraktUserPersonalListItemsPostPerson>)
                        .Add(CreateListItemsPostPerson(person));
                }
            }

            if (_personIds.IsValueCreated && _personIds.Value.Any())
            {
                foreach (ITraktPersonIds personIds in _personIds.Value)
                {
                    (userListItemsPost.People as List<ITraktUserPersonalListItemsPostPerson>)
                        .Add(CreateListItemsPostPerson(personIds));
                }
            }

            if (_personsWithNotes.IsValueCreated && _personsWithNotes.Value.Any())
            {
                foreach (PersonWithNotes personWithNotes in _personsWithNotes.Value)
                {
                    (userListItemsPost.People as List<ITraktUserPersonalListItemsPostPerson>)
                        .Add(CreateListItemsPostPerson(personWithNotes.Object, personWithNotes.Notes));
                }
            }

            if (_personIdsWithNotes.IsValueCreated && _personIdsWithNotes.Value.Any())
            {
                foreach (PersonIdsWithNotes personIdsWithNotes in _personIdsWithNotes.Value)
                {
                    (userListItemsPost.People as List<ITraktUserPersonalListItemsPostPerson>)
                        .Add(CreateListItemsPostPerson(personIdsWithNotes.Object, personIdsWithNotes.Notes));
                }
            }
        }

        private static ITraktUserPersonalListItemsPostMovie CreateListItemsPostMovie(ITraktMovie movie, string notes = null)
            => CreateListItemsPostMovie(movie.Ids, notes);

        private static ITraktUserPersonalListItemsPostMovie CreateListItemsPostMovie(ITraktMovieIds movieIds, string notes = null)
        {
            ITraktUserPersonalListItemsPostMovie userListItemsPostMovie = new TraktUserPersonalListItemsPostMovie
            {
                Ids = movieIds
            };

            if (!string.IsNullOrEmpty(notes))
                userListItemsPostMovie.Notes = notes;

            return userListItemsPostMovie;
        }

        private static ITraktUserPersonalListItemsPostShow CreateListItemsPostShow(ITraktShow show, string notes = null)
            => CreateListItemsPostShow(show.Ids, notes);

        private static ITraktUserPersonalListItemsPostShow CreateListItemsPostShow(ITraktShowIds showIds, string notes = null)
        {
            ITraktUserPersonalListItemsPostShow userListItemsPostShow = new TraktUserPersonalListItemsPostShow
            {
                Ids = showIds
            };

            if (!string.IsNullOrEmpty(notes))
                userListItemsPostShow.Notes = notes;

            return userListItemsPostShow;
        }

        private static void CreateListItemsPostShowAndSeasons(ITraktUserPersonalListItemsPost userListItemsPost, List<ShowAndSeasons> showsAndSeasons)
        {
            foreach (ShowAndSeasons showAndSeasons in showsAndSeasons)
            {
                ITraktUserPersonalListItemsPostShow userListItemsPostShow = CreateListItemsPostShow(showAndSeasons.Object);
                CreateListItemsPostShowSeasons(userListItemsPost, showAndSeasons.Seasons, userListItemsPostShow);
            }
        }

        private static void CreateListItemsPostShowAndSeasons(ITraktUserPersonalListItemsPost userListItemsPost, List<ShowWithNotesAndSeasons> showsWithNotesAndSeasons)
        {
            foreach (ShowWithNotesAndSeasons showWithNotesAndSeasons in showsWithNotesAndSeasons)
            {
                ITraktUserPersonalListItemsPostShow userListItemsPostShow =
                    CreateListItemsPostShow(showWithNotesAndSeasons.Object.Object, showWithNotesAndSeasons.Object.Notes);

                CreateListItemsPostShowSeasons(userListItemsPost, showWithNotesAndSeasons.Seasons, userListItemsPostShow);
            }
        }

        private static void CreateListItemsPostShowIdsAndSeasons(ITraktUserPersonalListItemsPost userListItemsPost, List<ShowIdsAndSeasons> showIdsAndSeasons)
        {
            foreach (ShowIdsAndSeasons showIdAndSeasons in showIdsAndSeasons)
            {
                ITraktUserPersonalListItemsPostShow userListItemsPostShow = CreateListItemsPostShow(showIdAndSeasons.Object);
                CreateListItemsPostShowSeasons(userListItemsPost, showIdAndSeasons.Seasons, userListItemsPostShow);
            }
        }

        private static void CreateListItemsPostShowIdsAndSeasons(ITraktUserPersonalListItemsPost userListItemsPost, List<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons)
        {
            foreach (ShowIdsWithNotesAndSeasons showIdWithNotesAndSeasons in showIdsWithNotesAndSeasons)
            {
                ITraktUserPersonalListItemsPostShow userListItemsPostShow =
                    CreateListItemsPostShow(showIdWithNotesAndSeasons.Object.Object, showIdWithNotesAndSeasons.Object.Notes);

                CreateListItemsPostShowSeasons(userListItemsPost, showIdWithNotesAndSeasons.Seasons, userListItemsPostShow);
            }
        }

        private static void CreateListItemsPostShowSeasons(ITraktUserPersonalListItemsPost userListItemsPost, PostSeasons seasons, ITraktUserPersonalListItemsPostShow userListItemsPostShow)
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

            (userListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(userListItemsPostShow);
        }

        private static ITraktUserPersonalListItemsPostShowSeason CreateListItemsPostShowSeason(PostSeason season)
            => new TraktUserPersonalListItemsPostShowSeason { Number = season.Number };

        private static ITraktUserPersonalListItemsPostShowEpisode CreateListItemsPostShowEpisode(PostEpisode episode)
            => new TraktUserPersonalListItemsPostShowEpisode { Number = episode.Number };

        private static ITraktUserPersonalListItemsPostSeason CreateListItemsPostSeason(ITraktSeason season, string notes = null)
            => CreateListItemsPostSeason(season.Ids, notes);

        private static ITraktUserPersonalListItemsPostSeason CreateListItemsPostSeason(ITraktSeasonIds seasonIds, string notes = null)
        {
            ITraktUserPersonalListItemsPostSeason userListItemsPostSeason = new TraktUserPersonalListItemsPostSeason
            {
                Ids = seasonIds
            };

            if (!string.IsNullOrEmpty(notes))
                userListItemsPostSeason.Notes = notes;

            return userListItemsPostSeason;
        }

        private static ITraktUserPersonalListItemsPostEpisode CreateListItemsPostEpisode(ITraktEpisode episode, string notes = null)
            => CreateListItemsPostEpisode(episode.Ids, notes);

        private static ITraktUserPersonalListItemsPostEpisode CreateListItemsPostEpisode(ITraktEpisodeIds episodeIds, string notes = null)
        {
            ITraktUserPersonalListItemsPostEpisode userListItemsPostEpisode = new TraktUserPersonalListItemsPostEpisode
            {
                Ids = episodeIds
            };

            if (!string.IsNullOrEmpty(notes))
                userListItemsPostEpisode.Notes = notes;

            return userListItemsPostEpisode;
        }

        private static ITraktUserPersonalListItemsPostPerson CreateListItemsPostPerson(ITraktPerson person, string notes = null)
            => CreateListItemsPostPerson(person.Ids, notes);

        private static ITraktUserPersonalListItemsPostPerson CreateListItemsPostPerson(ITraktPersonIds personIds, string notes = null)
        {
            ITraktUserPersonalListItemsPostPerson userListItemsPostPerson = new TraktUserPersonalListItemsPostPerson
            {
                Ids = personIds
            };

            if (!string.IsNullOrEmpty(notes))
                userListItemsPostPerson.Notes = notes;

            return userListItemsPostPerson;
        }

        private static void CheckNotes(string notes)
        {
            if (notes == null)
                throw new ArgumentNullException(nameof(notes));

            if (notes.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(notes));
        }
    }
}
