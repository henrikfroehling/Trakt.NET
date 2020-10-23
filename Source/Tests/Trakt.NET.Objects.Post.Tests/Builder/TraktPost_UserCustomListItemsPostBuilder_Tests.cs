namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Users.CustomListItems;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_UserCustomListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_UserCustomListItemsPostBuilder()
        {
            ITraktUserCustomListItemsPostBuilder syncCollectionPostBuilder = TraktPost.NewUserCustomListItemsPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_Empty_Build()
        {
            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost().Build();
            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_WithMovie()
        {
            ITraktMovie movie = new TraktMovie
            {
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie-title",
                    Imdb = "ttmovietitle",
                    Tmdb = 1
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .WithMovie(movie)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserCustomListItemsPostMovie postMovie = userCustomListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);

            userCustomListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_WithMovies()
        {
            var movies = new List<ITraktMovie>
            {
                new TraktMovie
                {
                    Ids = new TraktMovieIds
                    {
                        Trakt = 1,
                        Slug = "movie-1-title",
                        Imdb = "ttmovie1title",
                        Tmdb = 1
                    }
                },
                new TraktMovie
                {
                    Ids = new TraktMovieIds
                    {
                        Trakt = 2,
                        Slug = "movie-2-title",
                        Imdb = "ttmovie2title",
                        Tmdb = 2
                    }
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .WithMovies(movies)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserCustomListItemsPostMovie[] postMovies = userCustomListItemsPost.Movies.ToArray();

            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);

            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);

            userCustomListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_WithShow()
        {
            ITraktShow show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .WithShow(show)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserCustomListItemsPostShow postShow = userCustomListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().BeNull();

            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_WithShows()
        {
            var shows = new List<ITraktShow>
            {
                new TraktShow
                {
                    Ids = new TraktShowIds
                    {
                        Trakt = 1,
                        Slug = "show-1-title",
                        Imdb = "ttshow1title",
                        Tmdb = 1,
                        Tvdb = 1,
                        TvRage = 1
                    }
                },
                new TraktShow
                {
                    Ids = new TraktShowIds
                    {
                        Trakt = 2,
                        Slug = "show-2-title",
                        Imdb = "ttshow2title",
                        Tmdb = 2,
                        Tvdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .WithShows(shows)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserCustomListItemsPostShow[] postShows = userCustomListItemsPost.Shows.ToArray();

            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Seasons.Should().BeNull();

            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_AddShowAndSeasons()
        {
            ITraktShow show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .AddShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserCustomListItemsPostShow postShow = userCustomListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserCustomListItemsPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_AddShowAndSeasonsCollection()
        {
            ITraktShow show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show-title",
                    Imdb = "ttshowtitle",
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            var seasons = new PostSeasons
            {
                1,
                { 2, new PostEpisodes { 1, 2 } }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .AddShowAndSeasonsCollection(show).WithSeasons(seasons)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserCustomListItemsPostShow postShow = userCustomListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserCustomListItemsPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktUserCustomListItemsPostShowEpisode[] showSeasonPeople = showSeasons[1].Episodes.ToArray();

            showSeasonPeople[0].Number.Should().Be(1);
            showSeasonPeople[1].Number.Should().Be(2);

            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_WithPerson()
        {
            ITraktPerson episode = new TraktPerson
            {
                Ids = new TraktPersonIds
                {
                    Trakt = 1,
                    Imdb = "ttpersonname",
                    Tmdb = 1,
                    TvRage = 1
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .WithPerson(episode)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktPerson postPerson = userCustomListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(1U);
            postPerson.Ids.Imdb.Should().Be("ttpersonname");
            postPerson.Ids.Tmdb.Should().Be(1U);
            postPerson.Ids.TvRage.Should().Be(1U);

            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_WithPersons()
        {
            var persons = new List<ITraktPerson>
            {
                new TraktPerson
                {
                    Ids = new TraktPersonIds
                    {
                        Trakt = 1,
                        Imdb = "ttperson1name",
                        Tmdb = 1,
                        TvRage = 1
                    }
                },
                new TraktPerson
                {
                    Ids = new TraktPersonIds
                    {
                        Trakt = 2,
                        Imdb = "ttperson2name",
                        Tmdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost()
                .WithPersons(persons)
                .Build();

            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktPerson[] postPeople = userCustomListItemsPost.People.ToArray();

            postPeople[0].Ids.Should().NotBeNull();
            postPeople[0].Ids.Trakt.Should().Be(1U);
            postPeople[0].Ids.Imdb.Should().Be("ttperson1name");
            postPeople[0].Ids.Tmdb.Should().Be(1U);
            postPeople[0].Ids.TvRage.Should().Be(1U);

            postPeople[1].Ids.Should().NotBeNull();
            postPeople[1].Ids.Trakt.Should().Be(2U);
            postPeople[1].Ids.Imdb.Should().Be("ttperson2name");
            postPeople[1].Ids.Tmdb.Should().Be(2U);
            postPeople[1].Ids.TvRage.Should().Be(2U);

            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }
    }
}
