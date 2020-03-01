namespace TraktNet.Objects.Post.Users.CustomListItems
{
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is a helper class to build a <see cref="TraktUserCustomListItemsPost" />.
    /// <para>
    /// It is recommended to use this class to build an user custom list items post.<para /> 
    /// An instance of this class can be obtained with <see cref="TraktUserCustomListItemsPost.Builder()" />.
    /// </para>
    /// </summary>
    public class TraktUserCustomListItemsPostBuilder
    {
        private readonly ITraktUserCustomListItemsPost _listItemsPost;

        /// <summary>Initializes a new instance of the <see cref="TraktUserCustomListItemsPostBuilder" /> class.</summary>
        public TraktUserCustomListItemsPostBuilder()
        {
            _listItemsPost = new TraktUserCustomListItemsPost();
        }

        /// <summary>Adds a <see cref="ITraktMovie" />, which will be added to the user custom list items post.</summary>
        /// <param name="movie">The Trakt movie, which will be added.</param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movie is null.
        /// Thrown, if the given movie ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given movie has no valid ids set.
        /// Thrown, if the given movie has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddMovie(ITraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (!movie.Year.HasValue)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));

            EnsureMoviesListExists();

            var existingMovie = _listItemsPost.Movies.FirstOrDefault(m => m.Ids == movie.Ids);

            if (existingMovie != null)
                return this;

            (_listItemsPost.Movies as List<ITraktUserCustomListItemsPostMovie>)?.Add(
                new TraktUserCustomListItemsPostMovie
                {
                    Ids = movie.Ids
                });

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktMovie" />s, which will be added to the custom list items post.</summary>
        /// <param name="movies">A collection of Trakt movies, which will be added.</param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given movies collection is null.
        /// Thrown, if one of the given movies is null.
        /// Thrown, if one of the given movies' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given movies has no valid ids set.
        /// Thrown, if one of the given movies has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddMovies(IEnumerable<ITraktMovie> movies)
        {
            if (movies == null)
                throw new ArgumentNullException(nameof(movies));

            if (!movies.Any())
                return this;

            foreach (var movie in movies)
                AddMovie(movie);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the user custom list items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddShow(ITraktShow show)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var existingShow = _listItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
                return this;

            (_listItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>)?.Add(
                new TraktUserCustomListItemsPostShow
                {
                    Ids = show.Ids
                });

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktShow" />s, which will be added to the custom list items post.</summary>
        /// <param name="shows">A collection of Trakt shows, which will be added.</param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given shows collection is null.
        /// Thrown, if one of the given shows is null.
        /// Thrown, if one of the given shows' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given shows has no valid ids set.
        /// Thrown, if one of the given shows has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddShows(IEnumerable<ITraktShow> shows)
        {
            if (shows == null)
                throw new ArgumentNullException(nameof(shows));

            if (!shows.Any())
                return this;

            foreach (var show in shows)
                AddShow(show);

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the user custom list items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="season">
        /// A season number for a season in the given show. The complete season will be added to the custom list.
        /// </param>
        /// <param name="seasons">
        /// An optional array of season numbers for seasons in the given show.
        /// The complete seasons will be added to the custom list.
        /// </param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddShow(ITraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<ITraktUserCustomListItemsPostShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUserCustomListItemsPostShowSeason { Number = seasonsToAdd[i] });
            }

            var existingShow = _listItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                (_listItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>)?.Add(
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = show.Ids,
                        Seasons = showSeasons
                    });
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the custom list items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An array of season numbers for seasons in the given show.
        /// All seasons numbers will be added to the custom list items post.
        /// </param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// Thrown, if the given seasons array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers is below zero.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddShow(ITraktShow show, int[] seasons)
        {
            ValidateShow(show);
            EnsureShowsListExists();

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            var showSeasons = new List<ITraktUserCustomListItemsPostShowSeason>();

            for (int i = 0; i < seasons.Length; i++)
            {
                if (seasons[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUserCustomListItemsPostShowSeason { Number = seasons[i] });
            }

            var existingShow = _listItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                (_listItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>)?.Add(
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = show.Ids,

                        Seasons = showSeasons
                    });
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktShow" />, which will be added to the user custom list items post.</summary>
        /// <param name="show">The Trakt show, which will be added.</param>
        /// <param name="seasons">
        /// An <see cref="PostSeasons" /> instance, containing season and episode numbers.<para />
        /// If it contains episode numbers, only the episodes with the given episode numbers will be added to the custom list.
        /// </param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given show is null.
        /// Thrown, if the given show ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given show has no valid ids set.
        /// Thrown, if the given show has an year set, which has more or less than four digits.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if at least one of the given season numbers in <paramref name="seasons" /> is below zero.
        /// Thrown, if at least one of the given episode numbers in <paramref name="seasons" /> is below zero.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddShow(ITraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = new List<ITraktUserCustomListItemsPostShowSeason>();

            foreach (PostSeason season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktUserCustomListItemsPostShowSeason
                {
                    Number = season.Number
                };

                if (season.Episodes?.Count() > 0)
                {
                    var showEpisodes = new List<ITraktUserCustomListItemsPostShowEpisode>();

                    foreach (PostEpisode episode in season.Episodes)
                    {
                        if (episode.Number < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        showEpisodes.Add(new TraktUserCustomListItemsPostShowEpisode
                        {
                            Number = episode.Number
                        });
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            ITraktUserCustomListItemsPostShow existingShow = _listItemsPost.Shows.FirstOrDefault(s => s.Ids == show.Ids);

            if (existingShow != null)
            {
                existingShow.Seasons = showSeasons;
            }
            else
            {
                (_listItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>)?.Add(
                    new TraktUserCustomListItemsPostShow
                    {
                        Ids = show.Ids,
                        Seasons = showSeasons
                    });
            }

            return this;
        }

        /// <summary>Adds a <see cref="ITraktPerson" />, which will be added to the user custom list items post.</summary>
        /// <param name="person">The Trakt person, which will be added.</param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given person is null.
        /// Thrown, if the given person ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if the given person has no valid ids set.
        /// Thrown, if the given person has no name.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddPerson(ITraktPerson person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            if (person.Ids == null)
                throw new ArgumentNullException(nameof(person.Ids));

            if (!person.Ids.HasAnyId)
                throw new ArgumentException("no person ids set or valid", nameof(person.Ids));

            if (string.IsNullOrEmpty(person.Name))
                throw new ArgumentException("person name not valid", nameof(person.Name));

            EnsurePeopleListExists();

            var existingPerson = _listItemsPost.People.FirstOrDefault(p => p == person);

            if (existingPerson != null)
                return this;

            (_listItemsPost.People as List<ITraktPerson>)?.Add(person);

            return this;
        }

        /// <summary>Adds a collection of <see cref="ITraktPerson" />s, which will be added to the custom list items post.</summary>
        /// <param name="persons">A collection of Trakt persons, which will be added.</param>
        /// <returns>The current <see cref="TraktUserCustomListItemsPostBuilder" /> instance.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown, if the given persons collection is null.
        /// Thrown, if one of the given persons is null.
        /// Thrown, if one of the given persons' ids are null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown, if one of the given persons has no valid ids set.
        /// Thrown, if one of the given persons has an year set, which has more or less than four digits.
        /// </exception>
        public TraktUserCustomListItemsPostBuilder AddPersons(IEnumerable<ITraktPerson> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));

            if (!persons.Any())
                return this;

            foreach (var person in persons)
                AddPerson(person);

            return this;
        }

        /// <summary>Removes all already added movies, shows, seasons, episodes and people.</summary>
        public void Reset()
        {
            if (_listItemsPost.Movies != null)
            {
                (_listItemsPost.Movies as List<ITraktUserCustomListItemsPostMovie>)?.Clear();
                _listItemsPost.Movies = null;
            }

            if (_listItemsPost.Shows != null)
            {
                (_listItemsPost.Shows as List<ITraktUserCustomListItemsPostShow>)?.Clear();
                _listItemsPost.Shows = null;
            }

            if (_listItemsPost.People != null)
            {
                (_listItemsPost.People as List<ITraktPerson>)?.Clear();
                _listItemsPost.People = null;
            }
        }

        /// <summary>
        /// Returns an <see cref="ITraktUserCustomListItemsPost" /> instance, which contains all
        /// added movies, shows, seasons, episodes and people.
        /// </summary>
        /// <returns>An <see cref="TraktUserCustomListItemsPost" /> instance.</returns>
        public ITraktUserCustomListItemsPost Build() => _listItemsPost;

        private void ValidateShow(ITraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (!show.Year.HasValue)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        private void EnsureMoviesListExists()
        {
            if (_listItemsPost.Movies == null)
                _listItemsPost.Movies = new List<ITraktUserCustomListItemsPostMovie>();
        }

        private void EnsureShowsListExists()
        {
            if (_listItemsPost.Shows == null)
                _listItemsPost.Shows = new List<ITraktUserCustomListItemsPostShow>();
        }

        private void EnsurePeopleListExists()
        {
            if (_listItemsPost.People == null)
                _listItemsPost.People = new List<ITraktPerson>();
        }
    }
}
