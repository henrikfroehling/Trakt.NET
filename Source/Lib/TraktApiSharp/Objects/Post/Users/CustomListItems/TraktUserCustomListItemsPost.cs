namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraktUserCustomListItemsPost
    {
        [JsonProperty(PropertyName = "movies")]
        public IEnumerable<TraktUserCustomListItemsPostMovie> Movies { get; set; }

        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktUserCustomListItemsShow> Shows { get; set; }

        [JsonProperty(PropertyName = "people")]
        public IEnumerable<TraktPerson> People { get; set; }

        public static TraktUserCustomListItemsPostBuilder Builder() => new TraktUserCustomListItemsPostBuilder();
    }

    public class TraktUserCustomListItemsPostBuilder
    {
        private TraktUserCustomListItemsPost _listItemsPost;

        public TraktUserCustomListItemsPostBuilder()
        {
            _listItemsPost = new TraktUserCustomListItemsPost();
        }

        public TraktUserCustomListItemsPostBuilder AddMovie(TraktMovie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (movie.Ids == null)
                throw new ArgumentNullException(nameof(movie.Ids));

            if (!movie.Ids.HasAnyId)
                throw new ArgumentException("no movie ids set or valid", nameof(movie.Ids));

            if (movie.Year.HasValue && movie.Year.Value.ToString().Length != 4)
                throw new ArgumentException("movie year not valid", nameof(movie.Year));

            EnsureMoviesListExists();

            var existingMovie = _listItemsPost.Movies.Where(m => m.Ids == movie.Ids).FirstOrDefault();

            if (existingMovie != null)
                return this;

            (_listItemsPost.Movies as List<TraktUserCustomListItemsPostMovie>).Add(
                new TraktUserCustomListItemsPostMovie
                {
                    Ids = movie.Ids
                });

            return this;
        }

        public TraktUserCustomListItemsPostBuilder AddShow(TraktShow show)
        {
            ValidateShow(show);

            EnsureShowsListExists();

            var existingShow = _listItemsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                return this;

            (_listItemsPost.Shows as List<TraktUserCustomListItemsShow>).Add(
                new TraktUserCustomListItemsShow
                {
                    Ids = show.Ids
                });

            return this;
        }

        public TraktUserCustomListItemsPostBuilder AddShow(TraktShow show, int season, params int[] seasons)
        {
            ValidateShow(show);

            EnsureShowsListExists();

            var seasonsToAdd = new int[seasons.Length + 1];
            seasonsToAdd[0] = season;
            seasons.CopyTo(seasonsToAdd, 1);

            var showSeasons = new List<TraktUserCustomListItemsShowSeason>();

            for (int i = 0; i < seasonsToAdd.Length; i++)
            {
                if (seasonsToAdd[i] < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid");

                showSeasons.Add(new TraktUserCustomListItemsShowSeason { Number = seasonsToAdd[i] });
            }

            var existingShow = _listItemsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var listItemsShow = new TraktUserCustomListItemsShow();
                listItemsShow.Ids = show.Ids;

                listItemsShow.Seasons = showSeasons;
                (_listItemsPost.Shows as List<TraktUserCustomListItemsShow>).Add(listItemsShow);
            }

            return this;
        }

        public TraktUserCustomListItemsPostBuilder AddShow(TraktShow show, PostSeasons seasons)
        {
            ValidateShow(show);

            if (seasons == null)
                throw new ArgumentNullException(nameof(seasons));

            EnsureShowsListExists();

            var showSeasons = new List<TraktUserCustomListItemsShowSeason>();

            foreach (var season in seasons)
            {
                if (season.Number < 0)
                    throw new ArgumentOutOfRangeException("at least one season number not valid", nameof(season));

                var showSingleSeason = new TraktUserCustomListItemsShowSeason { Number = season.Number };

                if (season.Episodes != null && season.Episodes.Count() > 0)
                {
                    var showEpisodes = new List<TraktUserCustomListItemsShowEpisode>();

                    foreach (var episode in season.Episodes)
                    {
                        if (episode < 0)
                            throw new ArgumentOutOfRangeException("at least one episode number not valid", nameof(seasons));

                        showEpisodes.Add(new TraktUserCustomListItemsShowEpisode { Number = episode });
                    }

                    showSingleSeason.Episodes = showEpisodes;
                }

                showSeasons.Add(showSingleSeason);
            }

            var existingShow = _listItemsPost.Shows.Where(s => s.Ids == show.Ids).FirstOrDefault();

            if (existingShow != null)
                existingShow.Seasons = showSeasons;
            else
            {
                var listItemsShow = new TraktUserCustomListItemsShow();
                listItemsShow.Ids = show.Ids;

                listItemsShow.Seasons = showSeasons;
                (_listItemsPost.Shows as List<TraktUserCustomListItemsShow>).Add(listItemsShow);
            }

            return this;
        }

        public TraktUserCustomListItemsPostBuilder AddPerson(TraktPerson person)
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

            var existingPerson = _listItemsPost.People.Where(p => p == person).FirstOrDefault();

            if (existingPerson != null)
                return this;

            (_listItemsPost.People as List<TraktPerson>).Add(person);

            return this;
        }

        public void Reset()
        {
            if (_listItemsPost.Movies != null)
            {
                (_listItemsPost.Movies as List<TraktUserCustomListItemsPostMovie>).Clear();
                _listItemsPost.Movies = null;
            }

            if (_listItemsPost.Shows != null)
            {
                (_listItemsPost.Shows as List<TraktUserCustomListItemsShow>).Clear();
                _listItemsPost.Shows = null;
            }

            if (_listItemsPost.People != null)
            {
                (_listItemsPost.People as List<TraktPerson>).Clear();
                _listItemsPost.People = null;
            }
        }

        public TraktUserCustomListItemsPost Build()
        {
            return _listItemsPost;
        }

        private void ValidateShow(TraktShow show)
        {
            if (show == null)
                throw new ArgumentNullException(nameof(show));

            if (show.Ids == null)
                throw new ArgumentNullException(nameof(show.Ids));

            if (!show.Ids.HasAnyId)
                throw new ArgumentException("no show ids set or valid", nameof(show.Ids));

            if (show.Year.HasValue && show.Year.Value.ToString().Length != 4)
                throw new ArgumentException("show year not valid", nameof(show.Year));
        }

        private void EnsureMoviesListExists()
        {
            if (_listItemsPost.Movies == null)
                _listItemsPost.Movies = new List<TraktUserCustomListItemsPostMovie>();
        }

        private void EnsureShowsListExists()
        {
            if (_listItemsPost.Shows == null)
                _listItemsPost.Shows = new List<TraktUserCustomListItemsShow>();
        }

        private void EnsurePeopleListExists()
        {
            if (_listItemsPost.People == null)
                _listItemsPost.People = new List<TraktPerson>();
        }

    }
}
