namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("PostBuilder")]
    public class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_UserHiddenItemsPostBuilder()
        {
            ITraktUserHiddenItemsPostBuilder syncHiddenItemsPostBuilder = TraktPost.NewUserHiddenItemsPost();
            syncHiddenItemsPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_Empty_Build()
        {
            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost().Build();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithMovie()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "movie title",
                Year = 2020,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie-title",
                    Imdb = "ttmovietitle",
                    Tmdb = 1
                }
            };

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithMovie(movie)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostMovie postMovie = userHiddenItemsPost.Movies.ToArray()[0];
            postMovie.Title = "movie title";
            postMovie.Year = 2020;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);

            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithMovies()
        {
            var movies = new List<ITraktMovie>
            {
                new TraktMovie
                {
                    Title = "movie 1 title",
                    Year = 2020,
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
                    Title = "movie 2 title",
                    Year = 2020,
                    Ids = new TraktMovieIds
                    {
                        Trakt = 2,
                        Slug = "movie-2-title",
                        Imdb = "ttmovie2title",
                        Tmdb = 2
                    }
                }
            };

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithMovies(movies)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostMovie[] postMovies = userHiddenItemsPost.Movies.ToArray();

            postMovies[0].Title = "movie 1 title";
            postMovies[0].Year = 2020;
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);

            postMovies[1].Title = "movie 2 title";
            postMovies[1].Year = 2020;
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);

            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShow()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
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

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShow(show)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().BeNull();

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShows()
        {
            var shows = new List<ITraktShow>
            {
                new TraktShow
                {
                    Title = "show 1 title",
                    Year = 2020,
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
                    Title = "show 2 title",
                    Year = 2020,
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

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShows(shows)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostShow[] postShows = userHiddenItemsPost.Shows.ToArray();

            postShows[0].Title = "show 1 title";
            postShows[0].Year = 2020;
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Seasons.Should().BeNull();

            postShows[1].Title = "show 2 title";
            postShows[1].Year = 2020;
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Seasons.Should().BeNull();

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons()
        {
            ITraktShow show = new TraktShow
            {
                Title = "show title",
                Year = 2020,
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

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title = "show title";
            postShow.Year = 2020;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserHiddenItemsPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[1].Number.Should().Be(2);
            seasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithSeason()
        {
            ITraktSeason season = new TraktSeason
            {
                Ids = new TraktSeasonIds
                {
                    Trakt = 1,
                    Tmdb = 1,
                    Tvdb = 1,
                    TvRage = 1
                }
            };

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithSeason(season)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostSeason postSeason = userHiddenItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(1U);
            postSeason.Ids.Tmdb.Should().Be(1U);
            postSeason.Ids.Tvdb.Should().Be(1U);
            postSeason.Ids.TvRage.Should().Be(1U);

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithSeasons()
        {
            var seasons = new List<ITraktSeason>
            {
                new TraktSeason
                {
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 1,
                        Tmdb = 1,
                        Tvdb = 1,
                        TvRage = 1
                    }
                },
                new TraktSeason
                {
                    Ids = new TraktSeasonIds
                    {
                        Trakt = 2,
                        Tmdb = 2,
                        Tvdb = 2,
                        TvRage = 2
                    }
                }
            };

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithSeasons(seasons)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostSeason[] postSeasons = userHiddenItemsPost.Seasons.ToArray();

            postSeasons[0].Ids.Should().NotBeNull();
            postSeasons[0].Ids.Trakt.Should().Be(1U);
            postSeasons[0].Ids.Tmdb.Should().Be(1U);
            postSeasons[0].Ids.Tvdb.Should().Be(1U);
            postSeasons[0].Ids.TvRage.Should().Be(1U);

            postSeasons[1].Ids.Should().NotBeNull();
            postSeasons[1].Ids.Trakt.Should().Be(2U);
            postSeasons[1].Ids.Tmdb.Should().Be(2U);
            postSeasons[1].Ids.Tvdb.Should().Be(2U);
            postSeasons[1].Ids.TvRage.Should().Be(2U);

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithUser()
        {
            ITraktUser user = new TraktUser
            {
                Username = "username1",
                Name = "User Name 1",
                Ids = new TraktUserIds
                {
                    Slug = "username1"
                }
            };

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithUser(user)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Users.Should().NotBeNull().And.HaveCount(1);

            ITraktUser postUser = userHiddenItemsPost.Users.ToArray()[0];
            postUser.Username.Should().Be("username1");
            postUser.Name.Should().Be("User Name 1");
            postUser.Ids.Should().NotBeNull();
            postUser.Ids.Slug.Should().Be("username1");

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithUsers()
        {
            var users = new List<ITraktUser>
            {
                new TraktUser
                {
                    Username = "username1",
                    Name = "User Name 1",
                    Ids = new TraktUserIds
                    {
                        Slug = "username1"
                    }
                },
                new TraktUser
                {
                    Username = "username2",
                    Name = "User Name 2",
                    Ids = new TraktUserIds
                    {
                        Slug = "username2"
                    }
                }
            };

            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithUsers(users)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Users.Should().NotBeNull().And.HaveCount(2);

            ITraktUser[] postUsers = userHiddenItemsPost.Users.ToArray();

            postUsers[0].Ids.Should().NotBeNull();
            postUsers[0].Username.Should().Be("username1");
            postUsers[0].Name.Should().Be("User Name 1");
            postUsers[0].Ids.Should().NotBeNull();
            postUsers[0].Ids.Slug.Should().Be("username1");

            postUsers[1].Ids.Should().NotBeNull();
            postUsers[1].Username.Should().Be("username2");
            postUsers[1].Name.Should().Be("User Name 2");
            postUsers[1].Ids.Should().NotBeNull();
            postUsers[1].Ids.Slug.Should().Be("username2");

            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }
    }
}
