namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_UserPersonalListItemsPostBuilder()
        {
            ITraktUserPersonalListItemsPostBuilder syncPersonalListItemsPostBuilder = TraktPost.NewUserPersonalListItemsPost();
            syncPersonalListItemsPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_Empty_Build()
        {
            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost().Build();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovie()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovie(movie)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Notes.Should().BeNull();

            userPersonalListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes()
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

            string notes = "movie notes";

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movie, notes)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(1U);
            postMovie.Ids.Slug.Should().Be("movie-title");
            postMovie.Ids.Imdb.Should().Be("ttmovietitle");
            postMovie.Ids.Tmdb.Should().Be(1U);
            postMovie.Notes.Should().Be(notes);

            userPersonalListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovies()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovies(movies)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie[] postMovies = userPersonalListItemsPost.Movies.ToArray();

            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Notes.Should().BeNull();

            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Notes.Should().BeNull();

            userPersonalListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMoviesWithNotes()
        {
            string notes = "movie notes";

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(new List<Tuple<ITraktMovie, string>>
                {
                    new Tuple<ITraktMovie, string>(new TraktMovie
                        {
                            Ids = new TraktMovieIds
                            {
                                Trakt = 1,
                                Slug = "movie-1-title",
                                Imdb = "ttmovie1title",
                                Tmdb = 1
                            }
                        },
                        notes),
                    new Tuple<ITraktMovie, string>(new TraktMovie
                        {
                            Ids = new TraktMovieIds
                            {
                                Trakt = 2,
                                Slug = "movie-2-title",
                                Imdb = "ttmovie2title",
                                Tmdb = 2
                            }
                        },
                        notes)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie[] postMovies = userPersonalListItemsPost.Movies.ToArray();

            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("movie-1-title");
            postMovies[0].Ids.Imdb.Should().Be("ttmovie1title");
            postMovies[0].Ids.Tmdb.Should().Be(1U);
            postMovies[0].Notes.Should().Be(notes);

            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(2U);
            postMovies[1].Ids.Slug.Should().Be("movie-2-title");
            postMovies[1].Ids.Imdb.Should().Be("ttmovie2title");
            postMovies[1].Ids.Tmdb.Should().Be(2U);
            postMovies[1].Notes.Should().Be(notes);

            userPersonalListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShow()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShow(show)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().BeNull();
            postShow.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotes()
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

            string notes = "show notes";

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotes(show, notes)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().BeNull();
            postShow.Notes.Should().Be(notes);

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShows()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShows(shows)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow[] postShows = userPersonalListItemsPost.Shows.ToArray();

            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Seasons.Should().BeNull();
            postShows[0].Notes.Should().BeNull();

            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Seasons.Should().BeNull();
            postShows[1].Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsWithNotes()
        {
            string notes = "show notes";

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsWithNotes(new List<Tuple<ITraktShow, string>>
                {
                    new Tuple<ITraktShow, string>(new TraktShow
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
                        notes),
                    new Tuple<ITraktShow, string>(new TraktShow
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
                        },
                        notes)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow[] postShows = userPersonalListItemsPost.Shows.ToArray();

            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("show-1-title");
            postShows[0].Ids.Imdb.Should().Be("ttshow1title");
            postShows[0].Ids.Tmdb.Should().Be(1U);
            postShows[0].Ids.Tvdb.Should().Be(1U);
            postShows[0].Ids.TvRage.Should().Be(1U);
            postShows[0].Seasons.Should().BeNull();
            postShows[0].Notes.Should().Be(notes);

            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("show-2-title");
            postShows[1].Ids.Imdb.Should().Be("ttshow2title");
            postShows[1].Ids.Tmdb.Should().Be(2U);
            postShows[1].Ids.Tvdb.Should().Be(2U);
            postShows[1].Ids.TvRage.Should().Be(2U);
            postShows[1].Seasons.Should().BeNull();
            postShows[1].Notes.Should().Be(notes);

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowAndSeasons()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowAndSeasons(show).WithSeasons(1, 2, 3)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);
            postShow.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostShowSeason[] seasons = postShow.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Number.Should().Be(2);
            seasons[1].Episodes.Should().BeNull();

            seasons[2].Number.Should().Be(3);
            seasons[2].Episodes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowAndSeasonsCollection()
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

            var seasons = new PostSeasonsOld
            {
                1,
                { 2, new PostEpisodesOld { 1, 2 } }
            };

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowAndSeasonsCollection(show).WithSeasons(seasons)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(1U);
            postShow.Ids.Slug.Should().Be("show-title");
            postShow.Ids.Imdb.Should().Be("ttshowtitle");
            postShow.Ids.Tmdb.Should().Be(1U);
            postShow.Ids.Tvdb.Should().Be(1U);
            postShow.Ids.TvRage.Should().Be(1U);
            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);
            postShow.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostShowSeason[] showSeasons = postShow.Seasons.ToArray();

            showSeasons[0].Number.Should().Be(1);
            showSeasons[0].Episodes.Should().BeNull();

            showSeasons[1].Number.Should().Be(2);
            showSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowEpisode[] showSeasonPeople = showSeasons[1].Episodes.ToArray();

            showSeasonPeople[0].Number.Should().Be(1);
            showSeasonPeople[1].Number.Should().Be(2);

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPerson()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPerson(episode)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(1);

            ITraktPerson postPerson = userPersonalListItemsPost.People.ToArray()[0];
            postPerson.Ids.Should().NotBeNull();
            postPerson.Ids.Trakt.Should().Be(1U);
            postPerson.Ids.Imdb.Should().Be("ttpersonname");
            postPerson.Ids.Tmdb.Should().Be(1U);
            postPerson.Ids.TvRage.Should().Be(1U);

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithPersons()
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

            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithPersons(persons)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.People.Should().NotBeNull().And.HaveCount(2);

            ITraktPerson[] postPeople = userPersonalListItemsPost.People.ToArray();

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

            userPersonalListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
        }
    }
}
